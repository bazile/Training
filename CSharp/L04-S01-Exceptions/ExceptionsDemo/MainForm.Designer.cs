namespace ExceptionsDemo
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
			this.textBoxX = new System.Windows.Forms.TextBox();
			this.textBoxY = new System.Windows.Forms.TextBox();
			this.buttonCalculate = new System.Windows.Forms.Button();
			this.labelDivide = new System.Windows.Forms.Label();
			this.labelEquals = new System.Windows.Forms.Label();
			this.labelResult = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// textBoxX
			// 
			this.textBoxX.Location = new System.Drawing.Point(12, 22);
			this.textBoxX.Name = "textBoxX";
			this.textBoxX.Size = new System.Drawing.Size(100, 20);
			this.textBoxX.TabIndex = 0;
			// 
			// textBoxY
			// 
			this.textBoxY.Location = new System.Drawing.Point(135, 22);
			this.textBoxY.Name = "textBoxY";
			this.textBoxY.Size = new System.Drawing.Size(100, 20);
			this.textBoxY.TabIndex = 1;
			// 
			// buttonCalculate
			// 
			this.buttonCalculate.Location = new System.Drawing.Point(12, 58);
			this.buttonCalculate.Name = "buttonCalculate";
			this.buttonCalculate.Size = new System.Drawing.Size(223, 23);
			this.buttonCalculate.TabIndex = 2;
			this.buttonCalculate.Text = "Расчет";
			this.buttonCalculate.UseVisualStyleBackColor = true;
			this.buttonCalculate.Click += new System.EventHandler(this.OnButtonCalculateClick);
			// 
			// labelDivide
			// 
			this.labelDivide.AutoSize = true;
			this.labelDivide.Location = new System.Drawing.Point(117, 25);
			this.labelDivide.Name = "labelDivide";
			this.labelDivide.Size = new System.Drawing.Size(12, 13);
			this.labelDivide.TabIndex = 3;
			this.labelDivide.Text = "/";
			// 
			// labelEquals
			// 
			this.labelEquals.AutoSize = true;
			this.labelEquals.Location = new System.Drawing.Point(241, 25);
			this.labelEquals.Name = "labelEquals";
			this.labelEquals.Size = new System.Drawing.Size(13, 13);
			this.labelEquals.TabIndex = 4;
			this.labelEquals.Text = "=";
			// 
			// labelResult
			// 
			this.labelResult.AutoSize = true;
			this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.labelResult.Location = new System.Drawing.Point(260, 17);
			this.labelResult.Name = "labelResult";
			this.labelResult.Size = new System.Drawing.Size(25, 29);
			this.labelResult.TabIndex = 5;
			this.labelResult.Text = "?";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(317, 122);
			this.Controls.Add(this.labelResult);
			this.Controls.Add(this.labelEquals);
			this.Controls.Add(this.labelDivide);
			this.Controls.Add(this.buttonCalculate);
			this.Controls.Add(this.textBoxY);
			this.Controls.Add(this.textBoxX);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Deep Thought";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox textBoxX;
		private System.Windows.Forms.TextBox textBoxY;
		private System.Windows.Forms.Button buttonCalculate;
		private System.Windows.Forms.Label labelDivide;
		private System.Windows.Forms.Label labelEquals;
		private System.Windows.Forms.Label labelResult;
	}
}

