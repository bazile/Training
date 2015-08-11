namespace BelhardTraining.PiCalc
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
			this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
			this.cbUseBackgroundWorker = new System.Windows.Forms.CheckBox();
			this.lblIterations = new System.Windows.Forms.Label();
			this.udIterations = new System.Windows.Forms.NumericUpDown();
			this.tbResult = new System.Windows.Forms.TextBox();
			this.lblProgress = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.progressBar = new System.Windows.Forms.ProgressBar();
			this.btnStart = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.udIterations)).BeginInit();
			this.SuspendLayout();
			// 
			// backgroundWorker
			// 
			this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.OnDoWork);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.OnWorkProgressChanged);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.OnWorkCompleted);
			// 
			// cbUseBackgroundWorker
			// 
			this.cbUseBackgroundWorker.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cbUseBackgroundWorker.AutoSize = true;
			this.cbUseBackgroundWorker.Checked = true;
			this.cbUseBackgroundWorker.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbUseBackgroundWorker.Location = new System.Drawing.Point(253, 175);
			this.cbUseBackgroundWorker.Name = "cbUseBackgroundWorker";
			this.cbUseBackgroundWorker.Size = new System.Drawing.Size(195, 17);
			this.cbUseBackgroundWorker.TabIndex = 25;
			this.cbUseBackgroundWorker.Text = "Использовать BackgroundWorker";
			this.cbUseBackgroundWorker.UseVisualStyleBackColor = true;
			// 
			// lblIterations
			// 
			this.lblIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblIterations.AutoSize = true;
			this.lblIterations.Location = new System.Drawing.Point(13, 158);
			this.lblIterations.Name = "lblIterations";
			this.lblIterations.Size = new System.Drawing.Size(91, 13);
			this.lblIterations.TabIndex = 24;
			this.lblIterations.Text = "Кол-во итераций";
			// 
			// udIterations
			// 
			this.udIterations.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.udIterations.Increment = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.udIterations.Location = new System.Drawing.Point(16, 174);
			this.udIterations.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
			this.udIterations.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
			this.udIterations.Name = "udIterations";
			this.udIterations.Size = new System.Drawing.Size(120, 20);
			this.udIterations.TabIndex = 23;
			this.udIterations.ThousandsSeparator = true;
			this.udIterations.Value = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
			// 
			// tbResult
			// 
			this.tbResult.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tbResult.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.tbResult.Location = new System.Drawing.Point(13, 62);
			this.tbResult.Multiline = true;
			this.tbResult.Name = "tbResult";
			this.tbResult.ReadOnly = true;
			this.tbResult.Size = new System.Drawing.Size(422, 48);
			this.tbResult.TabIndex = 22;
			this.tbResult.Text = "3.???????????????";
			this.tbResult.Visible = false;
			// 
			// lblProgress
			// 
			this.lblProgress.AutoSize = true;
			this.lblProgress.Location = new System.Drawing.Point(13, 9);
			this.lblProgress.Name = "lblProgress";
			this.lblProgress.Size = new System.Drawing.Size(109, 13);
			this.lblProgress.TabIndex = 21;
			this.lblProgress.Tag = "";
			this.lblProgress.Text = "Идет вычисление PI";
			this.lblProgress.Visible = false;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCancel.Location = new System.Drawing.Point(94, 116);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 23);
			this.btnCancel.TabIndex = 20;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Visible = false;
			this.btnCancel.Click += new System.EventHandler(this.OnCancelClick);
			// 
			// progressBar
			// 
			this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.progressBar.Location = new System.Drawing.Point(13, 28);
			this.progressBar.Name = "progressBar";
			this.progressBar.Size = new System.Drawing.Size(427, 23);
			this.progressBar.TabIndex = 18;
			// 
			// btnStart
			// 
			this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnStart.Location = new System.Drawing.Point(13, 116);
			this.btnStart.Name = "btnStart";
			this.btnStart.Size = new System.Drawing.Size(75, 23);
			this.btnStart.TabIndex = 19;
			this.btnStart.Text = "Старт";
			this.btnStart.UseVisualStyleBackColor = true;
			this.btnStart.Click += new System.EventHandler(this.OnStartClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(460, 200);
			this.Controls.Add(this.cbUseBackgroundWorker);
			this.Controls.Add(this.lblIterations);
			this.Controls.Add(this.udIterations);
			this.Controls.Add(this.tbResult);
			this.Controls.Add(this.lblProgress);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.progressBar);
			this.Controls.Add(this.btnStart);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Демонстрация BackgroundWorker";
			((System.ComponentModel.ISupportInitialize)(this.udIterations)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

		private System.ComponentModel.BackgroundWorker backgroundWorker;
		private System.Windows.Forms.CheckBox cbUseBackgroundWorker;
		private System.Windows.Forms.Label lblIterations;
		private System.Windows.Forms.NumericUpDown udIterations;
		private System.Windows.Forms.TextBox tbResult;
		private System.Windows.Forms.Label lblProgress;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button btnStart;
    }
}

