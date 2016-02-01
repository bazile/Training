namespace AssemblyAsResourceDemo
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
			this.listBoxMsg = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// listBoxMsg
			// 
			this.listBoxMsg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listBoxMsg.FormattingEnabled = true;
			this.listBoxMsg.Location = new System.Drawing.Point(0, 0);
			this.listBoxMsg.Margin = new System.Windows.Forms.Padding(0);
			this.listBoxMsg.Name = "listBoxMsg";
			this.listBoxMsg.Size = new System.Drawing.Size(660, 291);
			this.listBoxMsg.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(660, 291);
			this.Controls.Add(this.listBoxMsg);
			this.Name = "MainForm";
			this.Text = "Демо. Загрузка сборки из ресурсов";
			this.Load += new System.EventHandler(this.OnLoad);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListBox listBoxMsg;
	}
}

