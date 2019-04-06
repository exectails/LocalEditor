using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace LocalEditor
{
	/// <summary>
	/// About Window.
	/// </summary>
	public partial class FrmAbout : Form
	{
		/// <summary>
		/// Creates new instance.
		/// </summary>
		public FrmAbout()
		{
			this.InitializeComponent();
		}

		/// <summary>
		/// Opens the link in the control's Tag.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Link_Click(object sender, EventArgs e)
		{
			var tag = ((sender as Control)?.Tag as string);
			if (tag != null)
				Process.Start(tag);
		}

		/// <summary>
		/// Called when the OK button is clicked, closes the form.
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void BtnOK_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
