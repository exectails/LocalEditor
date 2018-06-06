using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocalEditor
{
	/// <summary>
	/// Provides a textbox to enter a search text.
	/// </summary>
	public partial class FrmSearch : Form
	{
		/// <summary>
		/// The entered search text.
		/// </summary>
		public string SearchText { get; private set; }

		/// <summary>
		/// Creates new instance.
		/// </summary>
		public FrmSearch()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Closes form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnSearch_Click(object sender, EventArgs e)
		{
			this.SearchText = this.TxtSearchText.Text;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}

		/// <summary>
		/// Closes form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnCancel_Click(object sender, EventArgs e)
		{
			this.DialogResult = DialogResult.Cancel;
			this.Close();
		}
	}
}
