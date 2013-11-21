namespace BelhardTraining.Downloader
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
            this.btnDownload = new System.Windows.Forms.Button();
            this.cboxFiles = new System.Windows.Forms.ComboBox();
            this.lblFiles = new System.Windows.Forms.Label();
            this.progressDownload = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // btnDownload
            // 
            this.btnDownload.Location = new System.Drawing.Point(89, 171);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(75, 23);
            this.btnDownload.TabIndex = 0;
            this.btnDownload.Text = "Скачать";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.OnButtonDownloadClick);
            // 
            // cboxFiles
            // 
            this.cboxFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxFiles.FormattingEnabled = true;
            this.cboxFiles.Location = new System.Drawing.Point(89, 93);
            this.cboxFiles.Name = "cboxFiles";
            this.cboxFiles.Size = new System.Drawing.Size(221, 21);
            this.cboxFiles.TabIndex = 1;
            // 
            // lblFiles
            // 
            this.lblFiles.AutoSize = true;
            this.lblFiles.Location = new System.Drawing.Point(86, 77);
            this.lblFiles.Name = "lblFiles";
            this.lblFiles.Size = new System.Drawing.Size(106, 13);
            this.lblFiles.TabIndex = 2;
            this.lblFiles.Text = "Файл для загрузки";
            // 
            // progressDownload
            // 
            this.progressDownload.Location = new System.Drawing.Point(89, 133);
            this.progressDownload.Maximum = 1000;
            this.progressDownload.Name = "progressDownload";
            this.progressDownload.Size = new System.Drawing.Size(221, 23);
            this.progressDownload.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(397, 270);
            this.Controls.Add(this.progressDownload);
            this.Controls.Add(this.lblFiles);
            this.Controls.Add(this.cboxFiles);
            this.Controls.Add(this.btnDownload);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Демонстрация EAP через WebClient";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.ComboBox cboxFiles;
        private System.Windows.Forms.Label lblFiles;
        private System.Windows.Forms.ProgressBar progressDownload;

    }
}

