namespace BelhardTraining.Windows.Forms
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpageCommon = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btnLinkLabel = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpageCommon.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpageCommon);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(490, 462);
            this.tabControl1.TabIndex = 1;
            // 
            // tpageCommon
            // 
            this.tpageCommon.Controls.Add(this.btnLinkLabel);
            this.tpageCommon.Location = new System.Drawing.Point(4, 22);
            this.tpageCommon.Name = "tpageCommon";
            this.tpageCommon.Padding = new System.Windows.Forms.Padding(3);
            this.tpageCommon.Size = new System.Drawing.Size(482, 436);
            this.tpageCommon.TabIndex = 0;
            this.tpageCommon.Text = "Стандартные элементы";
            this.tpageCommon.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(482, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(146, 207);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(190, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Elevate button demo";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnLinkLabel
            // 
            this.btnLinkLabel.Location = new System.Drawing.Point(105, 88);
            this.btnLinkLabel.Name = "btnLinkLabel";
            this.btnLinkLabel.Size = new System.Drawing.Size(75, 23);
            this.btnLinkLabel.TabIndex = 0;
            this.btnLinkLabel.Text = "LinkLabel";
            this.btnLinkLabel.UseVisualStyleBackColor = true;
            this.btnLinkLabel.Click += new System.EventHandler(this.btnLinkLabel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 462);
            this.Controls.Add(this.tabControl1);
            this.Name = "MainForm";
            this.Text = "Демонстрация возможностей Windows Forms";
            this.tabControl1.ResumeLayout(false);
            this.tpageCommon.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpageCommon;
        private System.Windows.Forms.Button btnLinkLabel;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button1;

    }
}

