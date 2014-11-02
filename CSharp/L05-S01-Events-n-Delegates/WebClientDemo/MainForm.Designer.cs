namespace WebClientDemo
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.btnDownloadZip = new System.Windows.Forms.Button();
			this.progressBarDownload = new System.Windows.Forms.ProgressBar();
			this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
			this.pictureBoxServerStatus = new System.Windows.Forms.PictureBox();
			this.linkLabelServer = new System.Windows.Forms.LinkLabel();
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxServerStatus)).BeginInit();
			this.SuspendLayout();
			// 
			// btnDownloadZip
			// 
			this.btnDownloadZip.Location = new System.Drawing.Point(164, 43);
			this.btnDownloadZip.Name = "btnDownloadZip";
			this.btnDownloadZip.Size = new System.Drawing.Size(139, 23);
			this.btnDownloadZip.TabIndex = 0;
			this.btnDownloadZip.Text = "Скачать ZIP файл";
			this.btnDownloadZip.UseVisualStyleBackColor = true;
			this.btnDownloadZip.Click += new System.EventHandler(this.HandleDownloadZipButtonClick);
			// 
			// progressBarDownload
			// 
			this.progressBarDownload.Location = new System.Drawing.Point(164, 72);
			this.progressBarDownload.Name = "progressBarDownload";
			this.progressBarDownload.Size = new System.Drawing.Size(273, 23);
			this.progressBarDownload.TabIndex = 1;
			this.progressBarDownload.Visible = false;
			// 
			// imageListIcons
			// 
			this.imageListIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListIcons.ImageStream")));
			this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
			this.imageListIcons.Images.SetKeyName(0, "server-stopped");
			this.imageListIcons.Images.SetKeyName(1, "server-started");
			// 
			// pictureBoxServerStatus
			// 
			this.pictureBoxServerStatus.Location = new System.Drawing.Point(30, 43);
			this.pictureBoxServerStatus.Name = "pictureBoxServerStatus";
			this.pictureBoxServerStatus.Size = new System.Drawing.Size(128, 128);
			this.pictureBoxServerStatus.TabIndex = 2;
			this.pictureBoxServerStatus.TabStop = false;
			// 
			// linkLabelServer
			// 
			this.linkLabelServer.AutoSize = true;
			this.linkLabelServer.Location = new System.Drawing.Point(27, 174);
			this.linkLabelServer.Name = "linkLabelServer";
			this.linkLabelServer.Size = new System.Drawing.Size(109, 13);
			this.linkLabelServer.TabIndex = 3;
			this.linkLabelServer.TabStop = true;
			this.linkLabelServer.Text = "http://localhost:XXX/";
			this.linkLabelServer.Visible = false;
			this.linkLabelServer.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabelServer_LinkClicked);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(465, 231);
			this.Controls.Add(this.linkLabelServer);
			this.Controls.Add(this.pictureBoxServerStatus);
			this.Controls.Add(this.progressBarDownload);
			this.Controls.Add(this.btnDownloadZip);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.Text = "Демонстрация событий WebClient";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HandleFormClosing);
			((System.ComponentModel.ISupportInitialize)(this.pictureBoxServerStatus)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnDownloadZip;
		private System.Windows.Forms.ProgressBar progressBarDownload;
		private System.Windows.Forms.ImageList imageListIcons;
		private System.Windows.Forms.PictureBox pictureBoxServerStatus;
		private System.Windows.Forms.LinkLabel linkLabelServer;
	}
}

