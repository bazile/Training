namespace TrainingCenter.Windows.Forms
{
	partial class ElevateButtonForm
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
			this.elevateButton1 = new TrainingCenter.Windows.Forms.Controls.ElevateButton();
			this.SuspendLayout();
			// 
			// elevateButton1
			// 
			this.elevateButton1.Location = new System.Drawing.Point(67, 61);
			this.elevateButton1.Name = "elevateButton1";
			this.elevateButton1.Size = new System.Drawing.Size(145, 23);
			this.elevateButton1.TabIndex = 0;
			this.elevateButton1.Text = "elevateButton1";
			this.elevateButton1.UseVisualStyleBackColor = true;
			// 
			// FormWithElevateButton
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 262);
			this.Controls.Add(this.elevateButton1);
			this.Name = "ElevateButtonForm";
			this.Text = "FormWithElevateButton";
			this.ResumeLayout(false);

		}

		#endregion

		private Controls.ElevateButton elevateButton1;
	}
}