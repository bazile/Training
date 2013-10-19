namespace Belhard.Training.MutexDemo
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnExit = new System.Windows.Forms.Button();
			this.textBoxMsg = new System.Windows.Forms.TextBox();
			this.btnRun = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnExit
			// 
			resources.ApplyResources(this.btnExit, "btnExit");
			this.btnExit.Name = "btnExit";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.OnExitButtonClick);
			// 
			// textBoxMsg
			// 
			resources.ApplyResources(this.textBoxMsg, "textBoxMsg");
			this.textBoxMsg.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxMsg.Name = "textBoxMsg";
			this.textBoxMsg.ReadOnly = true;
			this.textBoxMsg.TabStop = false;
			// 
			// btnRun
			// 
			resources.ApplyResources(this.btnRun, "btnRun");
			this.btnRun.Name = "btnRun";
			this.btnRun.UseVisualStyleBackColor = true;
			this.btnRun.Click += new System.EventHandler(this.OnRunButtonClick);
			// 
			// MainForm
			// 
			resources.ApplyResources(this, "$this");
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnRun);
			this.Controls.Add(this.textBoxMsg);
			this.Controls.Add(this.btnExit);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.TextBox textBoxMsg;
		private System.Windows.Forms.Button btnRun;
	}
}

