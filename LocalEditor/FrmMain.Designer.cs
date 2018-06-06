namespace LocalEditor
{
	partial class FrmMain
	{
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Verwendete Ressourcen bereinigen.
		/// </summary>
		/// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code

		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung.
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
			this.TxtTranslatedLine = new System.Windows.Forms.TextBox();
			this.TxtOriginalLine = new System.Windows.Forms.TextBox();
			this.LblOriginal = new System.Windows.Forms.Label();
			this.LblElements = new System.Windows.Forms.Label();
			this.LblTranslation = new System.Windows.Forms.Label();
			this.Elements = new System.Windows.Forms.FlowLayoutPanel();
			this.TxtTranslateElement = new System.Windows.Forms.TextBox();
			this.ToolStrip = new System.Windows.Forms.ToolStrip();
			this.BtnOpenOriginal = new System.Windows.Forms.ToolStripButton();
			this.BtnOpenTranslated = new System.Windows.Forms.ToolStripButton();
			this.BtnSaveAs = new System.Windows.Forms.ToolStripButton();
			this.LblSeperator1 = new System.Windows.Forms.ToolStripSeparator();
			this.BtnEnableTabNextLine = new System.Windows.Forms.ToolStripButton();
			this.OfdOpen = new System.Windows.Forms.OpenFileDialog();
			this.SfdSave = new System.Windows.Forms.SaveFileDialog();
			this.LstLines = new System.Windows.Forms.ListView();
			this.ColKey = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.StatusStrip = new System.Windows.Forms.StatusStrip();
			this.LblTranslatedCount = new System.Windows.Forms.ToolStripStatusLabel();
			this.BtnSearch = new System.Windows.Forms.ToolStripButton();
			this.LblSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.ToolStrip.SuspendLayout();
			this.StatusStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// TxtTranslatedLine
			// 
			this.TxtTranslatedLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtTranslatedLine.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtTranslatedLine.Location = new System.Drawing.Point(252, 228);
			this.TxtTranslatedLine.Multiline = true;
			this.TxtTranslatedLine.Name = "TxtTranslatedLine";
			this.TxtTranslatedLine.ReadOnly = true;
			this.TxtTranslatedLine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtTranslatedLine.Size = new System.Drawing.Size(755, 160);
			this.TxtTranslatedLine.TabIndex = 4;
			// 
			// TxtOriginalLine
			// 
			this.TxtOriginalLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtOriginalLine.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtOriginalLine.Location = new System.Drawing.Point(252, 49);
			this.TxtOriginalLine.Multiline = true;
			this.TxtOriginalLine.Name = "TxtOriginalLine";
			this.TxtOriginalLine.ReadOnly = true;
			this.TxtOriginalLine.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.TxtOriginalLine.Size = new System.Drawing.Size(755, 160);
			this.TxtOriginalLine.TabIndex = 5;
			// 
			// LblOriginal
			// 
			this.LblOriginal.AutoSize = true;
			this.LblOriginal.Location = new System.Drawing.Point(252, 33);
			this.LblOriginal.Name = "LblOriginal";
			this.LblOriginal.Size = new System.Drawing.Size(65, 13);
			this.LblOriginal.TabIndex = 3;
			this.LblOriginal.Text = "Original Line";
			// 
			// LblElements
			// 
			this.LblElements.AutoSize = true;
			this.LblElements.Location = new System.Drawing.Point(252, 391);
			this.LblElements.Name = "LblElements";
			this.LblElements.Size = new System.Drawing.Size(111, 13);
			this.LblElements.TabIndex = 4;
			this.LblElements.Text = "Translatable Elements";
			// 
			// LblTranslation
			// 
			this.LblTranslation.AutoSize = true;
			this.LblTranslation.Location = new System.Drawing.Point(252, 212);
			this.LblTranslation.Name = "LblTranslation";
			this.LblTranslation.Size = new System.Drawing.Size(59, 13);
			this.LblTranslation.TabIndex = 5;
			this.LblTranslation.Text = "Translation";
			// 
			// Elements
			// 
			this.Elements.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.Elements.AutoScroll = true;
			this.Elements.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Elements.Location = new System.Drawing.Point(252, 407);
			this.Elements.Name = "Elements";
			this.Elements.Size = new System.Drawing.Size(755, 65);
			this.Elements.TabIndex = 3;
			// 
			// TxtTranslateElement
			// 
			this.TxtTranslateElement.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.TxtTranslateElement.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.TxtTranslateElement.Location = new System.Drawing.Point(252, 478);
			this.TxtTranslateElement.Multiline = true;
			this.TxtTranslateElement.Name = "TxtTranslateElement";
			this.TxtTranslateElement.Size = new System.Drawing.Size(755, 163);
			this.TxtTranslateElement.TabIndex = 2;
			this.TxtTranslateElement.TextChanged += new System.EventHandler(this.TxtTranslate_TextChanged);
			// 
			// ToolStrip
			// 
			this.ToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
			this.ToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.BtnOpenOriginal,
            this.BtnOpenTranslated,
            this.BtnSaveAs,
            this.LblSeperator1,
            this.BtnSearch,
            this.LblSeparator2,
            this.BtnEnableTabNextLine});
			this.ToolStrip.Location = new System.Drawing.Point(0, 0);
			this.ToolStrip.Name = "ToolStrip";
			this.ToolStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
			this.ToolStrip.Size = new System.Drawing.Size(1019, 25);
			this.ToolStrip.TabIndex = 8;
			this.ToolStrip.Text = "toolStrip1";
			// 
			// BtnOpenOriginal
			// 
			this.BtnOpenOriginal.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnOpenOriginal.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpenOriginal.Image")));
			this.BtnOpenOriginal.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnOpenOriginal.Name = "BtnOpenOriginal";
			this.BtnOpenOriginal.Size = new System.Drawing.Size(23, 22);
			this.BtnOpenOriginal.Text = "Open Original...";
			this.BtnOpenOriginal.Click += new System.EventHandler(this.BtnOpenOriginal_Click);
			// 
			// BtnOpenTranslated
			// 
			this.BtnOpenTranslated.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnOpenTranslated.Image = ((System.Drawing.Image)(resources.GetObject("BtnOpenTranslated.Image")));
			this.BtnOpenTranslated.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnOpenTranslated.Name = "BtnOpenTranslated";
			this.BtnOpenTranslated.Size = new System.Drawing.Size(23, 22);
			this.BtnOpenTranslated.Text = "Open Translated...";
			this.BtnOpenTranslated.Click += new System.EventHandler(this.BtnOpenTranslated_Click);
			// 
			// BtnSaveAs
			// 
			this.BtnSaveAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnSaveAs.Image = ((System.Drawing.Image)(resources.GetObject("BtnSaveAs.Image")));
			this.BtnSaveAs.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnSaveAs.Name = "BtnSaveAs";
			this.BtnSaveAs.Size = new System.Drawing.Size(23, 22);
			this.BtnSaveAs.Text = "Save As...";
			this.BtnSaveAs.Click += new System.EventHandler(this.BtnSaveAs_Click);
			// 
			// LblSeperator1
			// 
			this.LblSeperator1.Name = "LblSeperator1";
			this.LblSeperator1.Size = new System.Drawing.Size(6, 25);
			// 
			// BtnEnableTabNextLine
			// 
			this.BtnEnableTabNextLine.Checked = true;
			this.BtnEnableTabNextLine.CheckOnClick = true;
			this.BtnEnableTabNextLine.CheckState = System.Windows.Forms.CheckState.Checked;
			this.BtnEnableTabNextLine.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnEnableTabNextLine.Image = ((System.Drawing.Image)(resources.GetObject("BtnEnableTabNextLine.Image")));
			this.BtnEnableTabNextLine.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnEnableTabNextLine.Name = "BtnEnableTabNextLine";
			this.BtnEnableTabNextLine.Size = new System.Drawing.Size(23, 22);
			this.BtnEnableTabNextLine.Text = "Jump to next line after the last element?";
			// 
			// OfdOpen
			// 
			this.OfdOpen.Filter = "Text Files|*.txt";
			// 
			// SfdSave
			// 
			this.SfdSave.Filter = "Text Files|*.txt";
			// 
			// LstLines
			// 
			this.LstLines.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
			this.LstLines.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColKey});
			this.LstLines.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.LstLines.FullRowSelect = true;
			this.LstLines.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.LstLines.HideSelection = false;
			this.LstLines.Location = new System.Drawing.Point(12, 33);
			this.LstLines.MultiSelect = false;
			this.LstLines.Name = "LstLines";
			this.LstLines.Size = new System.Drawing.Size(234, 608);
			this.LstLines.TabIndex = 1;
			this.LstLines.UseCompatibleStateImageBehavior = false;
			this.LstLines.View = System.Windows.Forms.View.Details;
			this.LstLines.SelectedIndexChanged += new System.EventHandler(this.LstLines_SelectedIndexChanged);
			this.LstLines.MouseUp += new System.Windows.Forms.MouseEventHandler(this.LstLines_MouseUp);
			// 
			// ColKey
			// 
			this.ColKey.Text = "Lines";
			this.ColKey.Width = 199;
			// 
			// StatusStrip
			// 
			this.StatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LblTranslatedCount});
			this.StatusStrip.Location = new System.Drawing.Point(0, 649);
			this.StatusStrip.Name = "StatusStrip";
			this.StatusStrip.Size = new System.Drawing.Size(1019, 22);
			this.StatusStrip.TabIndex = 10;
			this.StatusStrip.Text = "statusStrip1";
			// 
			// LblTranslatedCount
			// 
			this.LblTranslatedCount.Name = "LblTranslatedCount";
			this.LblTranslatedCount.Size = new System.Drawing.Size(0, 17);
			// 
			// BtnSearch
			// 
			this.BtnSearch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.BtnSearch.Image = ((System.Drawing.Image)(resources.GetObject("BtnSearch.Image")));
			this.BtnSearch.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.BtnSearch.Name = "BtnSearch";
			this.BtnSearch.Size = new System.Drawing.Size(23, 22);
			this.BtnSearch.Text = "Search...";
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// LblSeparator2
			// 
			this.LblSeparator2.Name = "LblSeparator2";
			this.LblSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// FrmMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1019, 671);
			this.Controls.Add(this.StatusStrip);
			this.Controls.Add(this.LstLines);
			this.Controls.Add(this.ToolStrip);
			this.Controls.Add(this.TxtTranslateElement);
			this.Controls.Add(this.Elements);
			this.Controls.Add(this.LblTranslation);
			this.Controls.Add(this.LblElements);
			this.Controls.Add(this.LblOriginal);
			this.Controls.Add(this.TxtOriginalLine);
			this.Controls.Add(this.TxtTranslatedLine);
			this.DoubleBuffered = true;
			this.KeyPreview = true;
			this.Name = "FrmMain";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Local Editor";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
			this.ToolStrip.ResumeLayout(false);
			this.ToolStrip.PerformLayout();
			this.StatusStrip.ResumeLayout(false);
			this.StatusStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.TextBox TxtTranslatedLine;
		private System.Windows.Forms.TextBox TxtOriginalLine;
		private System.Windows.Forms.Label LblOriginal;
		private System.Windows.Forms.Label LblElements;
		private System.Windows.Forms.Label LblTranslation;
		private System.Windows.Forms.FlowLayoutPanel Elements;
		private System.Windows.Forms.TextBox TxtTranslateElement;
		private System.Windows.Forms.ToolStrip ToolStrip;
		private System.Windows.Forms.ToolStripButton BtnOpenOriginal;
		private System.Windows.Forms.ToolStripButton BtnOpenTranslated;
		private System.Windows.Forms.ToolStripButton BtnSaveAs;
		private System.Windows.Forms.OpenFileDialog OfdOpen;
		private System.Windows.Forms.SaveFileDialog SfdSave;
		private System.Windows.Forms.ListView LstLines;
		private System.Windows.Forms.ColumnHeader ColKey;
		private System.Windows.Forms.StatusStrip StatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel LblTranslatedCount;
		private System.Windows.Forms.ToolStripSeparator LblSeperator1;
		private System.Windows.Forms.ToolStripButton BtnEnableTabNextLine;
		private System.Windows.Forms.ToolStripButton BtnSearch;
		private System.Windows.Forms.ToolStripSeparator LblSeparator2;
	}
}

