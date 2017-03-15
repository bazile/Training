namespace TrainingCenter.LessonIO.WindowsSearchDemo
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
			this.cbSearchPath = new System.Windows.Forms.ComboBox();
			this.btnSearch = new System.Windows.Forms.Button();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbSearchPath
			// 
			this.cbSearchPath.FormattingEnabled = true;
			this.cbSearchPath.Location = new System.Drawing.Point(12, 12);
			this.cbSearchPath.Name = "cbSearchPath";
			this.cbSearchPath.Size = new System.Drawing.Size(343, 21);
			this.cbSearchPath.TabIndex = 0;
			this.cbSearchPath.SelectedValueChanged += new System.EventHandler(this.cbSearchPath_SelectedValueChanged);
			this.cbSearchPath.TextChanged += new System.EventHandler(this.cbSearchPath_TextChanged);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(12, 51);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 1;
			this.btnSearch.Text = "Поиск";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(12, 93);
			this.listBox1.Name = "listBox1";
			this.listBox1.Size = new System.Drawing.Size(401, 95);
			this.listBox1.TabIndex = 2;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(375, 13);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 3;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(487, 262);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.btnSearch);
			this.Controls.Add(this.cbSearchPath);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ComboBox cbSearchPath;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button button1;
	}
}

