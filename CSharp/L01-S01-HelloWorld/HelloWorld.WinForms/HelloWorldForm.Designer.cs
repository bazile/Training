namespace HelloWorld.WinForms
{
	partial class HelloWorldForm
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
			this.buttonHelloEng = new System.Windows.Forms.Button();
			this.buttonHelloRus = new System.Windows.Forms.Button();
			this.buttonHelloJpn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// buttonHelloEng
			// 
			this.buttonHelloEng.Location = new System.Drawing.Point(135, 50);
			this.buttonHelloEng.Name = "buttonHelloEng";
			this.buttonHelloEng.Size = new System.Drawing.Size(122, 53);
			this.buttonHelloEng.TabIndex = 0;
			this.buttonHelloEng.Text = "Hello World";
			this.buttonHelloEng.UseVisualStyleBackColor = true;
			this.buttonHelloEng.Click += new System.EventHandler(this.OnButtonHelloClick);
			// 
			// buttonHelloRus
			// 
			this.buttonHelloRus.Location = new System.Drawing.Point(135, 109);
			this.buttonHelloRus.Name = "buttonHelloRus";
			this.buttonHelloRus.Size = new System.Drawing.Size(122, 53);
			this.buttonHelloRus.TabIndex = 1;
			this.buttonHelloRus.Text = "Привет мир";
			this.buttonHelloRus.UseVisualStyleBackColor = true;
			this.buttonHelloRus.Click += new System.EventHandler(this.OnButtonHelloClick);
			// 
			// buttonHelloJpn
			// 
			this.buttonHelloJpn.Location = new System.Drawing.Point(135, 168);
			this.buttonHelloJpn.Name = "buttonHelloJpn";
			this.buttonHelloJpn.Size = new System.Drawing.Size(122, 53);
			this.buttonHelloJpn.TabIndex = 2;
			this.buttonHelloJpn.Text = "こんにちは世界";
			this.buttonHelloJpn.UseVisualStyleBackColor = true;
			this.buttonHelloJpn.Click += new System.EventHandler(this.OnButtonHelloClick);
			// 
			// HelloWorldForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(392, 270);
			this.Controls.Add(this.buttonHelloJpn);
			this.Controls.Add(this.buttonHelloRus);
			this.Controls.Add(this.buttonHelloEng);
			this.MinimumSize = new System.Drawing.Size(400, 300);
			this.Name = "HelloWorldForm";
			this.Text = "Hello World";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonHelloEng;
		private System.Windows.Forms.Button buttonHelloRus;
		private System.Windows.Forms.Button buttonHelloJpn;
	}
}

