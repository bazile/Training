namespace BelhardTraining.ControlInvokeDeadlock
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
			this.bigButton = new System.Windows.Forms.Button();
			this.statusLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// bigButton
			// 
			this.bigButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.bigButton.Location = new System.Drawing.Point(105, 76);
			this.bigButton.Name = "bigButton";
			this.bigButton.Size = new System.Drawing.Size(175, 137);
			this.bigButton.TabIndex = 0;
			this.bigButton.Text = "Нажми меня!";
			this.bigButton.UseVisualStyleBackColor = true;
			this.bigButton.Click += new System.EventHandler(this.bigButton_Click);
			// 
			// statusLabel
			// 
			this.statusLabel.AutoSize = true;
			this.statusLabel.Location = new System.Drawing.Point(170, 50);
			this.statusLabel.Margin = new System.Windows.Forms.Padding(10);
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(35, 13);
			this.statusLabel.TabIndex = 1;
			this.statusLabel.Text = "label1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 262);
			this.Controls.Add(this.statusLabel);
			this.Controls.Add(this.bigButton);
			this.Name = "MainForm";
			this.Text = "Демонстрация взаимоблокировки";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button bigButton;
		private System.Windows.Forms.Label statusLabel;
	}
}

