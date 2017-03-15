namespace TrainingCenter.Windows.Forms
{
    partial class NumericTextBoxForm
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
            this.numericTextBox1 = new TrainingCenter.Windows.Forms.Controls.NumericTextBox();
            this.SuspendLayout();
            // 
            // numericTextBox1
            // 
            this.numericTextBox1.Location = new System.Drawing.Point(12, 12);
            this.numericTextBox1.Name = "numericTextBox1";
            this.numericTextBox1.Size = new System.Drawing.Size(167, 20);
            this.numericTextBox1.TabIndex = 0;
            // 
            // NumericTextBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.numericTextBox1);
            this.Name = "NumericTextBoxForm";
            this.Text = "NumericTextBoxForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.NumericTextBox numericTextBox1;
    }
}
