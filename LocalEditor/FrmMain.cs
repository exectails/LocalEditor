using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace LocalEditor
{
	/// <summary>
	/// Main form.
	/// </summary>
	public partial class FrmMain : Form
	{
		private static readonly Color DefaultColor = Color.Black;
		private static readonly Color HighlightColor = Color.OrangeRed;
		private static readonly Color TranslatedColor = Color.LightGray;

		private string _openOriginalFilePath;
		private Dictionary<string, string> _originalLines = new Dictionary<string, string>();
		private Dictionary<string, string> _translatedLines = new Dictionary<string, string>();
		private List<string> _lineKeys = new List<string>();

		private bool _loading = false;
		private HtmlDocument _currentDoc;
		private TranslatableElement _currentElement;
		private Dictionary<Button, TranslatableElement> _elementButtons = new Dictionary<Button, TranslatableElement>();
		private List<TranslatableElement> _translatableElements = new List<TranslatableElement>();
		private ListViewItem _selectedListViewItem;
		private string _searchText;

		/// <summary>
		/// Creates new instance.
		/// </summary>
		public FrmMain()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Initializes form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			this.ToolStrip.Renderer = new ToolStripRendererNL();

			var args = Environment.GetCommandLineArgs();
			if (args.Length > 1)
				this.OpenOriginal(args[1]);
		}

		/// <summary>
		/// Opens the given file as original file.
		/// </summary>
		/// <param name="filePath"></param>
		private void OpenOriginal(string filePath)
		{
			if (!File.Exists(filePath))
			{
				MessageBox.Show(this, "File not found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			try
			{
				using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
				using (var sr = new StreamReader(fs))
				{
					// Clear variables once we have access to the file
					_openOriginalFilePath = filePath;
					_originalLines.Clear();
					_translatedLines.Clear();
					_lineKeys.Clear();
					_loading = false;
					_currentDoc = null;
					_currentElement = null;
					_elementButtons.Clear();
					_translatableElements.Clear();
					_selectedListViewItem = null;

					this.LstLines.Items.Clear();
					this.LstLines.BeginUpdate();

					// Load lines
					string line;
					while ((line = sr.ReadLine()) != null)
					{
						var index = line.IndexOf('\t');
						if (index == -1)
							continue;

						var key = line.Substring(0, index);
						var value = line.Substring(index + 1);

						value = Regex.Replace(value, "<br ?/>", Environment.NewLine);

						_originalLines[key] = value;
						_lineKeys.Add(key);

						var lvi = this.LstLines.Items.Add(key);
						lvi.Tag = key;
					}

					this.LstLines.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
					this.LstLines.EndUpdate();

					this.ResetTranslationControls();
					this.UpdateTranslatedCount();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Failed to open file. Error: " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Opens list of translated lines.
		/// </summary>
		/// <param name="filePath"></param>
		private void OpenTranslated(string filePath)
		{
			try
			{
				using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
				using (var sr = new StreamReader(fs))
				{
					_translatedLines.Clear();
					this.LstLines.BeginUpdate();

					string line;
					while ((line = sr.ReadLine()) != null)
					{
						var index = line.IndexOf('\t');
						if (index == -1)
							continue;

						var key = line.Substring(0, index);
						var value = line.Substring(index + 1);

						value = Regex.Replace(value, "<br ?/>", Environment.NewLine);

						if (!_originalLines.TryGetValue(key, out var originalValue) || originalValue == value)
							continue;

						_translatedLines[key] = value;
					}

					this.UpdateAllListItems();
					this.LstLines.EndUpdate();
					this.UpdateTranslatedCount();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show(this, "Failed to open file. Error: " + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		/// <summary>
		/// Updates the translation count in the status bar.
		/// </summary>
		private void UpdateTranslatedCount()
		{
			var total = _originalLines.Count;
			var translated = _originalLines.Where(a => this.IsTranslated(a.Key)).Count();

			this.LblTranslatedCount.Text = string.Format("Translated: {0}/{1}", translated, total);
		}

		/// <summary>
		/// Returns true if the line was translated, based on whether it
		/// was changed at all.
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
		private bool IsTranslated(string key)
		{
			if (!_originalLines.TryGetValue(key, out var originalValue))
				throw new ArgumentException("Key not found.");

			if (!_translatedLines.TryGetValue(key, out var translatedValue) || originalValue == translatedValue)
				return false;

			return true;
		}

		/// <summary>
		/// Clears the translation texts and elements, does not clear
		/// file list.
		/// </summary>
		private void ResetTranslationControls()
		{
			_loading = true;
			this.TxtOriginalLine.Text = "";
			this.TxtTranslatedLine.Text = "";
			this.TxtTranslateElement.Text = "";
			this.Elements.Controls.Clear();
			_loading = false;
		}

		/// <summary>
		/// Loads given HTML string and returns the document.
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		private HtmlDocument GetDoc(string str)
		{
			var doc = new HtmlDocument();
			doc.LoadHtml(str);

			return doc;
		}

		/// <summary>
		/// Loads a line to be translated by key. If the line doesn't
		/// exist or the key is null the translation elements will be reset.
		/// </summary>
		/// <param name="key"></param>
		private void LoadLine(string key)
		{
			this.UpdateSelectedListItem();
			this.UpdateTranslatedCount();

			// Reset it null or unknown key
			if (key == null || !_originalLines.TryGetValue(key, out var originalValue))
			{
				this.ResetTranslationControls();
				return;
			}

			if (!_translatedLines.TryGetValue(key, out var translatedValue))
				translatedValue = originalValue;

			// Prepare doc
			var doc = this.GetDoc(translatedValue);

			// Get translatable elements from document
			var elements = new List<TranslatableElement>();
			foreach (var node in doc.DocumentNode.ChildNodes)
				elements.AddRange(this.GetElements(key, node));

			// Create buttons
			this.Elements.Controls.Clear();
			foreach (var element in elements)
			{
				var button = new Button();
				button.Text = element.Name;
				button.Tag = element;
				button.Click += this.Element_Click;

				this.Elements.Controls.Add(button);
			}

			// Save current objects
			_currentDoc = doc;
			_currentElement = null;

			// Initialize input
			_loading = true;
			this.TxtOriginalLine.Text = originalValue;
			this.TxtTranslatedLine.Text = translatedValue;
			this.TxtTranslateElement.Text = "";
			_loading = false;
		}

		/// <summary>
		/// Updates the font of the selected list view item based on whether
		/// it's been translated or not.
		/// </summary>
		private void UpdateSelectedListItem()
		{
			if (_selectedListViewItem != null)
				this.UpdateListItem(_selectedListViewItem);
		}

		/// <summary>
		/// Updates the font of all list view items based on whether
		/// they've been translated or not.
		/// </summary>
		private void UpdateAllListItems()
		{
			foreach (ListViewItem lvi in this.LstLines.Items)
				this.UpdateListItem(lvi);
		}

		/// <summary>
		/// Updates the font of the list view item based on whether
		/// it's been translated or not.
		/// </summary>
		/// <param name="lvi"></param>
		private void UpdateListItem(ListViewItem lvi)
		{
			var key = lvi.Tag as string;

			if (!_originalLines.TryGetValue(key, out var _))
				return;

			if (this.IsTranslated(key))
				lvi.ForeColor = TranslatedColor;
			else
				lvi.ForeColor = DefaultColor;
		}

		/// <summary>
		/// Loads the selected line to be translated.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LstLines_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.LstLines.SelectedItems.Count == 0)
			{
				this.LoadLine(null);
				return;
			}

			// Load line from key in tag
			var selectedItem = this.LstLines.SelectedItems[0];
			var key = (string)selectedItem.Tag;
			this.LoadLine(key);

			// Remember the selected item so we can update it when we
			// change it on the next select.
			_selectedListViewItem = selectedItem;

			// Select the first element
			this.ClickFirstElement();
		}

		/// <summary>
		/// Focuses translation box after the mouse was let go of.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void LstLines_MouseUp(object sender, MouseEventArgs e)
		{
			if (this.LstLines.SelectedItems.Count == 0)
				return;

			this.ClickFirstElement();
		}

		/// <summary>
		/// Performs a click on the first element without triggering
		/// a text change.
		/// </summary>
		private void ClickFirstElement()
		{
			_loading = true;

			if (this.Elements.Controls.Count > 0)
				(this.Elements.Controls[0] as Button)?.PerformClick();

			_loading = false;
		}

		/// <summary>
		/// Generates translatable elements from node.
		/// </summary>
		/// <param name="node"></param>
		/// <param name="lineKey"></param>
		/// <returns></returns>
		private List<TranslatableElement> GetElements(string lineKey, HtmlNode node)
		{
			var result = new List<TranslatableElement>();

			switch (node.Name)
			{
				default:
					break;

				case "#text":
					result.Add(new TranslatableElement(lineKey, node, null));
					break;

				case "title":
					if (node.GetAttributeValue("name", "") != "NONE")
						result.Add(new TranslatableElement(lineKey, node, "name"));
					break;

				case "inputbox":
				case "selectitem":
					if (node.GetAttributeValue("title", null) != null)
						result.Add(new TranslatableElement(lineKey, node, "title"));
					if (node.GetAttributeValue("caption", null) != null)
						result.Add(new TranslatableElement(lineKey, node, "caption"));
					break;

				case "listbox":
					result.Add(new TranslatableElement(lineKey, node, "title"));
					break;

				case "button":
					result.Add(new TranslatableElement(lineKey, node, "title"));
					break;
			}

			return result;
		}

		/// <summary>
		/// Returns the code for the current doc.
		/// </summary>
		/// <returns></returns>
		private string GetCurrentCode()
		{
			var code = _currentDoc.DocumentNode.OuterHtml;

			// Fix changes by the parser
			code = code.Replace("<br>", "<br/>");
			code = Regex.Replace(code, "<brt></brt>", "<brt/>");
			code = Regex.Replace(code, "<bt></bt>", "<bt/>");
			code = Regex.Replace(code, "<button(.*?)></button>", "<button$1/>");
			code = Regex.Replace(code, "<cecil></cecil>", "<cecil/>");
			code = Regex.Replace(code, "<face(.*?)></face>", "<face$1/>");
			code = Regex.Replace(code, "<ferghus(.*?)></ferghus>", "<ferghus$1/>");
			code = Regex.Replace(code, "<hotkey(.*?)></hotkey>", "<hotkey$1/>");
			code = Regex.Replace(code, "<image(.*?)></image>", "<image$1/>");
			code = Regex.Replace(code, "<inputbox(.*?)></inputbox>", "<inputbox$1/>");
			code = Regex.Replace(code, "<job_select(.*?)></job_select>", "<job_select$1/>");
			code = Regex.Replace(code, "<mina></mina>", "<mina/>");
			code = Regex.Replace(code, "<music(.*?)></music>", "<music$1/>");
			code = Regex.Replace(code, "<npcportrait(.*?)></npcportrait>", "<npcportrait$1/>");
			code = Regex.Replace(code, "<none></none>", "<none/>");
			code = code.Replace("<p>", "<p/>");
			code = Regex.Replace(code, "<picture_puzzle(.*?)></picture_puzzle>", "<picture_puzzle$1/>");
			code = Regex.Replace(code, "<repair(.*?)></repair>", "<repair$1/>");
			code = Regex.Replace(code, "<selectitem(.*?)></selectitem>", "<selectitem$1/>");
			code = Regex.Replace(code, "<show_dir(.*?)></show_dir>", "<show_dir$1/>");
			code = Regex.Replace(code, "<talent_select(.*?)></talent_select>", "<talent_select$1/>");
			code = Regex.Replace(code, "<upgrade(.*?)></upgrade>", "<upgrade$1/>");
			code = Regex.Replace(code, "<useername></useername>", "<useername/>");
			code = Regex.Replace(code, "<useranme></useranme>", "<useranme/>");
			code = Regex.Replace(code, "<usermame></usermame>", "<usermame/>");
			code = Regex.Replace(code, "<username></username>", "<username/>");
			code = Regex.Replace(code, "<usrename></usrename>", "<usrename/>");
			code = Regex.Replace(code, "<title(.*?)></title>", "<title$1/>");
			code = Regex.Replace(code, "<yuki></yuki>", "<yuki/>");

			return code;
		}

		/// <summary>
		/// Loads the clicked element to be translated.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Element_Click(object sender, EventArgs e)
		{
			var button = (sender as Button);
			var element = (button.Tag as TranslatableElement);

			foreach (Button control in this.Elements.Controls)
				control.ForeColor = DefaultColor;

			button.ForeColor = HighlightColor;
			_currentElement = element;

			this.TxtTranslateElement.Text = element.Text;
			this.TxtTranslateElement.SelectAll();
			this.TxtTranslateElement.Select();
		}

		/// <summary>
		/// Updates the current element with the changed text.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void TxtTranslate_TextChanged(object sender, EventArgs e)
		{
			if (_loading || _currentElement == null)
				return;

			var element = _currentElement;
			var key = element.LineKey;

			element.Text = this.TxtTranslateElement.Text;

			var code = this.GetCurrentCode();

			_translatedLines[key] = code;
			this.TxtTranslatedLine.Text = code;
		}

		/// <summary>
		/// Catches tab key and calls _KeyDown for it.
		/// </summary>
		/// <param name="msg"></param>
		/// <param name="keyData"></param>
		/// <returns></returns>
		protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
		{
			var keys = (Keys)msg.WParam.ToInt32();
			if (keys == Keys.Tab)
			{
				this.FrmMain_KeyDown(this, new KeyEventArgs(keys));
				return true;
			}

			return base.ProcessCmdKey(ref msg, keyData);
		}

		/// <summary>
		/// Handles hotkeys.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMain_KeyDown(object sender, KeyEventArgs e)
		{
			// PageUp/Down: Select next line
			if (e.KeyCode == Keys.PageUp || e.KeyCode == Keys.PageDown)
			{
				this.SelectNextLine(e.KeyCode == Keys.PageDown);
				e.Handled = true;
			}
			// Tab: Select next element
			else if (e.KeyCode == Keys.Tab)
			{
				this.SelectNextElement(ModifierKeys != Keys.Shift);
				e.Handled = true;
			}
			// Ctrl+F: Search
			else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.F)
			{
				this.BtnSearch_Click(null, null);
			}
			// F3: Search Next
			else if (e.KeyCode == Keys.F3)
			{
				if (!string.IsNullOrWhiteSpace(_searchText))
					this.SearchNext(_searchText);
			}
		}

		/// <summary>
		/// Selects the next line.
		/// </summary>
		/// <param name="forward"></param>
		private void SelectNextLine(bool forward)
		{
			var selectedIndex = (this.LstLines.SelectedIndices.Count > 0 ? this.LstLines.SelectedIndices[0] : -1);
			var modifier = (forward ? 1 : -1);
			var index = (selectedIndex + modifier);

			if (index < 0)
				index = this.LstLines.Items.Count - 1;
			else if (index > this.LstLines.Items.Count - 1)
				index = 0;

			this.LstLines.Items[index].Selected = true;
			this.LstLines.Items[index].EnsureVisible();
		}

		/// <summary>
		/// Selects the next element.
		/// </summary>
		/// <param name="forward"></param>
		private void SelectNextElement(bool forward)
		{
			var count = this.Elements.Controls.Count;
			var index = -1;

			for (var i = 0; i < count; ++i)
			{
				if (this.Elements.Controls[i].Tag == _currentElement)
					index = i;
			}

			if (this.BtnEnableTabNextLine.Checked && ((forward && index == count - 1) || (!forward && index == 0)))
			{
				this.SelectNextLine(forward);
				return;
			}

			if (index != -1)
			{
				var modifier = (forward ? 1 : -1);

				index += modifier;
				if (index < 0)
					index = count - 1;
				else if (index > count - 1)
					index = 0;

				(this.Elements.Controls[index] as Button)?.PerformClick();
			}
		}

		/// <summary>
		/// Opens an original file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOpenOriginal_Click(object sender, EventArgs e)
		{
			var result = this.OfdOpen.ShowDialog();
			if (result != DialogResult.OK)
				return;

			this.OpenOriginal(this.OfdOpen.FileName);
		}

		/// <summary>
		/// Opens a translated file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOpenTranslated_Click(object sender, EventArgs e)
		{
			var result = this.OfdOpen.ShowDialog();
			if (result != DialogResult.OK)
				return;

			this.OpenTranslated(this.OfdOpen.FileName);
		}

		/// <summary>
		/// Saves the original lines in a new file, replacing all lines
		/// that were translated.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSaveAs_Click(object sender, EventArgs e)
		{
			var result = this.SfdSave.ShowDialog();
			if (result != DialogResult.OK)
				return;

			using (var fs = new FileStream(this.SfdSave.FileName, FileMode.CreateNew, FileAccess.Write, FileShare.None))
			using (var sw = new StreamWriter(fs, Encoding.Unicode))
			{
				foreach (var key in _lineKeys)
				{
					if (!_originalLines.TryGetValue(key, out var originalLine))
						continue;

					if (!_translatedLines.TryGetValue(key, out var translatedLine))
						translatedLine = originalLine;

					var value = Regex.Replace(translatedLine, "\r?\n", "<br/>");

					sw.WriteLine(key + "\t" + translatedLine);
				}
			}
		}

		/// <summary>
		/// Opens search form and goes to the first found list item.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSearch_Click(object sender, EventArgs e)
		{
			var form = new FrmSearch();
			var result = form.ShowDialog();
			if (result != DialogResult.OK || this.LstLines.Items.Count == 0)
				return;

			var searchText = form.SearchText;
			if (string.IsNullOrWhiteSpace(searchText))
				return;

			this.SearchNext(searchText);

			_searchText = searchText;
		}

		/// <summary>
		/// Jumps to next line key that contains the text.
		/// </summary>
		private void SearchNext(string searchText)
		{
			var selectedIndex = 0;
			var count = this.LstLines.Items.Count;

			if (this.LstLines.SelectedIndices.Count > 0)
				selectedIndex = this.LstLines.SelectedIndices[0];

			ListViewItem foundItem = null;
			ListViewItem firstItem = null;

			for (var i = 0; i < count; ++i)
			{
				var item = this.LstLines.Items[i];
				var key = (item.Tag as string);

				if (key == null)
					continue;

				if (key.Contains(searchText))
				{
					foundItem = item;

					if (firstItem == null)
						firstItem = item;

					if (i > selectedIndex)
						break;
				}
			}

			if (foundItem == null)
			{
				MessageBox.Show("No matches found.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			// Loop back to first item 
			if (foundItem == this.LstLines.Items[selectedIndex])
				foundItem = firstItem;

			foundItem.Selected = true;
			foundItem.EnsureVisible();
		}

		/// <summary>
		/// Enables drag.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMain_DragEnter(object sender, DragEventArgs e)
		{
			e.Effect = (e.Data.GetDataPresent(DataFormats.FileDrop) ? DragDropEffects.Copy : DragDropEffects.None);
		}

		/// <summary>
		/// Opens dragged file.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void FrmMain_DragDrop(object sender, DragEventArgs e)
		{
			var filePaths = e.Data.GetData(DataFormats.FileDrop) as string[];
			if (filePaths.Length == 0)
				return;

			this.OpenOriginal(filePaths[0]);
		}
	}
}
