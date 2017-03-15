namespace TrainingCenter.Windows.Forms
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
            this.btnLinkLabel = new System.Windows.Forms.Button();
            this.tpageCustom = new System.Windows.Forms.TabPage();
            this.btlPlaceholderTextBox = new System.Windows.Forms.Button();
            this.btnElevateButton = new System.Windows.Forms.Button();
            this.btnNumericTextBox = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tpageCommon.SuspendLayout();
            this.tpageCustom.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpageCommon);
            this.tabControl1.Controls.Add(this.tpageCustom);
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
            // tpageCustom
            // 
            this.tpageCustom.Controls.Add(this.btnNumericTextBox);
            this.tpageCustom.Controls.Add(this.btlPlaceholderTextBox);
            this.tpageCustom.Controls.Add(this.btnElevateButton);
            this.tpageCustom.Location = new System.Drawing.Point(4, 22);
            this.tpageCustom.Name = "tpageCustom";
            this.tpageCustom.Padding = new System.Windows.Forms.Padding(3);
            this.tpageCustom.Size = new System.Drawing.Size(482, 436);
            this.tpageCustom.TabIndex = 1;
            this.tpageCustom.Text = "Нестандартные";
            this.tpageCustom.UseVisualStyleBackColor = true;
            // 
            // btlPlaceholderTextBox
            // 
            this.btlPlaceholderTextBox.Location = new System.Drawing.Point(108, 96);
            this.btlPlaceholderTextBox.Name = "btlPlaceholderTextBox";
            this.btlPlaceholderTextBox.Size = new System.Drawing.Size(190, 23);
            this.btlPlaceholderTextBox.TabIndex = 3;
            this.btlPlaceholderTextBox.Text = "PlaceholderTextBox";
            this.btlPlaceholderTextBox.UseVisualStyleBackColor = true;
            this.btlPlaceholderTextBox.Click += new System.EventHandler(this.btlPlaceholderTextBox_Click);
            // 
            // btnElevateButton
            // 
            this.btnElevateButton.Location = new System.Drawing.Point(108, 193);
            this.btnElevateButton.Name = "btnElevateButton";
            this.btnElevateButton.Size = new System.Drawing.Size(190, 23);
            this.btnElevateButton.TabIndex = 2;
            this.btnElevateButton.Text = "Elevate button demo";
            this.btnElevateButton.UseVisualStyleBackColor = true;
            // 
            // btnNumericTextBox
            // 
            this.btnNumericTextBox.Location = new System.Drawing.Point(108, 125);
            this.btnNumericTextBox.Name = "btnNumericTextBox";
            this.btnNumericTextBox.Size = new System.Drawing.Size(190, 23);
            this.btnNumericTextBox.TabIndex = 4;
            this.btnNumericTextBox.Text = "NumericTextBox";
            this.btnNumericTextBox.UseVisualStyleBackColor = true;
            this.btnNumericTextBox.Click += new System.EventHandler(this.btnNumericTextBox_Click);
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
            this.tpageCustom.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tpageCommon;
        private System.Windows.Forms.Button btnLinkLabel;
        private System.Windows.Forms.TabPage tpageCustom;
        private System.Windows.Forms.Button btnElevateButton;
        private System.Windows.Forms.Button btlPlaceholderTextBox;
        private System.Windows.Forms.Button btnNumericTextBox;

    }
}

