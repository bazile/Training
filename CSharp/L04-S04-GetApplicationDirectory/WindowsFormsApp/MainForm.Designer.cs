namespace BelhardTraining.LessonIO
{
	partial class MainForm
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
			System.Windows.Forms.ColumnHeader columnHeaderSrc;
			System.Windows.Forms.ColumnHeader columnHeaderVal;
			this.listViewInfo = new System.Windows.Forms.ListView();
			columnHeaderSrc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			columnHeaderVal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.SuspendLayout();
			// 
			// listViewInfo
			// 
			this.listViewInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeaderSrc,
            columnHeaderVal});
			this.listViewInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewInfo.FullRowSelect = true;
			this.listViewInfo.GridLines = true;
			this.listViewInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewInfo.Location = new System.Drawing.Point(0, 0);
			this.listViewInfo.Name = "listViewInfo";
			this.listViewInfo.Size = new System.Drawing.Size(884, 262);
			this.listViewInfo.TabIndex = 0;
			this.listViewInfo.UseCompatibleStateImageBehavior = false;
			this.listViewInfo.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderSrc
			// 
			columnHeaderSrc.Text = "Источник";
			// 
			// columnHeaderVal
			// 
			columnHeaderVal.Text = "Значение";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(884, 262);
			this.Controls.Add(this.listViewInfo);
			this.Name = "MainForm";
			this.Text = "Папка приложения";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView listViewInfo;
	}
}

