namespace ProcessesDemo
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
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.infoToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.panelForProcessList = new System.Windows.Forms.Panel();
			this.processListView = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderThreadCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.mainMenuStrip.SuspendLayout();
			this.mainStatusStrip.SuspendLayout();
			this.panelForProcessList.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(755, 24);
			this.mainMenuStrip.TabIndex = 1;
			this.mainMenuStrip.Text = "menuStrip1";
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.runToolStripMenuItem.Text = "&Run ...";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.OnRunToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
			// 
			// refreshTimer
			// 
			this.refreshTimer.Interval = 5000;
			this.refreshTimer.Tick += new System.EventHandler(this.OnRefreshTimerTick);
			// 
			// mainStatusStrip
			// 
			this.mainStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.infoToolStripStatusLabel});
			this.mainStatusStrip.Location = new System.Drawing.Point(0, 362);
			this.mainStatusStrip.Name = "mainStatusStrip";
			this.mainStatusStrip.Size = new System.Drawing.Size(755, 22);
			this.mainStatusStrip.TabIndex = 2;
			this.mainStatusStrip.Text = "statusStrip1";
			// 
			// infoToolStripStatusLabel
			// 
			this.infoToolStripStatusLabel.Name = "infoToolStripStatusLabel";
			this.infoToolStripStatusLabel.Size = new System.Drawing.Size(138, 17);
			this.infoToolStripStatusLabel.Text = "Processes - ?. Threads - ?";
			// 
			// panelForProcessList
			// 
			this.panelForProcessList.Controls.Add(this.processListView);
			this.panelForProcessList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelForProcessList.Location = new System.Drawing.Point(0, 24);
			this.panelForProcessList.Name = "panelForProcessList";
			this.panelForProcessList.Size = new System.Drawing.Size(755, 338);
			this.panelForProcessList.TabIndex = 3;
			// 
			// processListView
			// 
			this.processListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderName,
            this.columnHeaderThreadCount});
			this.processListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.processListView.FullRowSelect = true;
			this.processListView.GridLines = true;
			this.processListView.Location = new System.Drawing.Point(0, 0);
			this.processListView.MultiSelect = false;
			this.processListView.Name = "processListView";
			this.processListView.Size = new System.Drawing.Size(755, 338);
			this.processListView.TabIndex = 3;
			this.processListView.UseCompatibleStateImageBehavior = false;
			this.processListView.View = System.Windows.Forms.View.Details;
			this.processListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnProcessListViewColumnClick);
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "PID";
			this.columnHeaderId.Width = 120;
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 250;
			// 
			// columnHeaderThreadCount
			// 
			this.columnHeaderThreadCount.Text = "# of Threads";
			this.columnHeaderThreadCount.Width = 120;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(755, 384);
			this.Controls.Add(this.panelForProcessList);
			this.Controls.Add(this.mainStatusStrip);
			this.Controls.Add(this.mainMenuStrip);
			this.MainMenuStrip = this.mainMenuStrip;
			this.Name = "MainForm";
			this.Text = "Process Demo";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.OnMainFormClosing);
			this.Load += new System.EventHandler(this.OnMainFormLoad);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.mainStatusStrip.ResumeLayout(false);
			this.mainStatusStrip.PerformLayout();
			this.panelForProcessList.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.Timer refreshTimer;
		private System.Windows.Forms.StatusStrip mainStatusStrip;
		private System.Windows.Forms.ToolStripStatusLabel infoToolStripStatusLabel;
		private System.Windows.Forms.Panel panelForProcessList;
		private System.Windows.Forms.ListView processListView;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderThreadCount;
	}
}

