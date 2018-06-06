namespace LocalEditor
{
	partial class FrmSearch
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.TxtSearchText = new System.Windows.Forms.TextBox();
			this.BtnSearch = new System.Windows.Forms.Button();
			this.LblSearch = new System.Windows.Forms.Label();
			this.BtnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// TxtSearchText
			// 
			this.TxtSearchText.Location = new System.Drawing.Point(12, 25);
			this.TxtSearchText.Name = "TxtSearchText";
			this.TxtSearchText.Size = new System.Drawing.Size(398, 20);
			this.TxtSearchText.TabIndex = 1;
			// 
			// BtnSearch
			// 
			this.BtnSearch.Location = new System.Drawing.Point(254, 51);
			this.BtnSearch.Name = "BtnSearch";
			this.BtnSearch.Size = new System.Drawing.Size(75, 23);
			this.BtnSearch.TabIndex = 2;
			this.BtnSearch.Text = "Search";
			this.BtnSearch.UseVisualStyleBackColor = true;
			this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
			// 
			// LblSearch
			// 
			this.LblSearch.AutoSize = true;
			this.LblSearch.Location = new System.Drawing.Point(12, 9);
			this.LblSearch.Name = "LblSearch";
			this.LblSearch.Size = new System.Drawing.Size(56, 13);
			this.LblSearch.TabIndex = 2;
			this.LblSearch.Text = "Search for";
			// 
			// BtnCancel
			// 
			this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.BtnCancel.Location = new System.Drawing.Point(335, 51);
			this.BtnCancel.Name = "BtnCancel";
			this.BtnCancel.Size = new System.Drawing.Size(75, 23);
			this.BtnCancel.TabIndex = 3;
			this.BtnCancel.Text = "Cancel";
			this.BtnCancel.UseVisualStyleBackColor = true;
			this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
			// 
			// FrmSearch
			// 
			this.AcceptButton = this.BtnSearch;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.BtnCancel;
			this.ClientSize = new System.Drawing.Size(422, 84);
			this.Controls.Add(this.BtnCancel);
			this.Controls.Add(this.LblSearch);
			this.Controls.Add(this.BtnSearch);
			this.Controls.Add(this.TxtSearchText);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FrmSearch";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Search";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox TxtSearchText;
		private System.Windows.Forms.Button BtnSearch;
		private System.Windows.Forms.Label LblSearch;
		private System.Windows.Forms.Button BtnCancel;
	}
}