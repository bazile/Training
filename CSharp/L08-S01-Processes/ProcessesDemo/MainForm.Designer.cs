namespace TrainingCenter.LessonMultithreading
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
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.runElevatedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoRefreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.refreshTimer = new System.Windows.Forms.Timer(this.components);
			this.mainStatusStrip = new System.Windows.Forms.StatusStrip();
			this.infoToolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.panelForProcessList = new System.Windows.Forms.Panel();
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.processListView = new System.Windows.Forms.ListView();
			this.columnHeaderId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderThreadCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderWorkingSet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeaderSessionId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.imageListIcons = new System.Windows.Forms.ImageList(this.components);
			this.mainToolStrip = new System.Windows.Forms.ToolStrip();
			this.autoRefreshToolStripButton = new System.Windows.Forms.ToolStripButton();
			this.mainMenuStrip.SuspendLayout();
			this.mainStatusStrip.SuspendLayout();
			this.panelForProcessList.SuspendLayout();
			this.tableLayoutPanel.SuspendLayout();
			this.mainToolStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runToolStripMenuItem,
            this.runElevatedToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(755, 24);
			this.mainMenuStrip.TabIndex = 1;
			// 
			// runToolStripMenuItem
			// 
			this.runToolStripMenuItem.Name = "runToolStripMenuItem";
			this.runToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
			this.runToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.runToolStripMenuItem.Text = "&Run ...";
			this.runToolStripMenuItem.Click += new System.EventHandler(this.OnRunToolStripMenuItemClick);
			// 
			// runElevatedToolStripMenuItem
			// 
			this.runElevatedToolStripMenuItem.Name = "runElevatedToolStripMenuItem";
			this.runElevatedToolStripMenuItem.Size = new System.Drawing.Size(99, 20);
			this.runElevatedToolStripMenuItem.Text = "Run &elevated ...";
			this.runElevatedToolStripMenuItem.Click += new System.EventHandler(this.OnRunElevatedToolStripMenuItemClick);
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoRefreshToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// autoRefreshToolStripMenuItem
			// 
			this.autoRefreshToolStripMenuItem.Checked = true;
			this.autoRefreshToolStripMenuItem.CheckOnClick = true;
			this.autoRefreshToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoRefreshToolStripMenuItem.Name = "autoRefreshToolStripMenuItem";
			this.autoRefreshToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
			this.autoRefreshToolStripMenuItem.Text = "Auto &refresh";
			this.autoRefreshToolStripMenuItem.CheckedChanged += new System.EventHandler(this.OnAutoRefreshToolStripMenuItemCheckedChanged);
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
			this.infoToolStripStatusLabel.Size = new System.Drawing.Size(188, 17);
			this.infoToolStripStatusLabel.Text = "CPUs - ?, Processes - ?. Threads - ?";
			// 
			// panelForProcessList
			// 
			this.panelForProcessList.Controls.Add(this.tableLayoutPanel);
			this.panelForProcessList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelForProcessList.Location = new System.Drawing.Point(0, 24);
			this.panelForProcessList.Name = "panelForProcessList";
			this.panelForProcessList.Size = new System.Drawing.Size(755, 338);
			this.panelForProcessList.TabIndex = 3;
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 1;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.Controls.Add(this.processListView, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.mainToolStrip, 0, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 2;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(755, 338);
			this.tableLayoutPanel.TabIndex = 4;
			// 
			// processListView
			// 
			this.processListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderId,
            this.columnHeaderName,
            this.columnHeaderThreadCount,
            this.columnHeaderWorkingSet,
            this.columnHeaderSessionId});
			this.processListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.processListView.FullRowSelect = true;
			this.processListView.GridLines = true;
			this.processListView.Location = new System.Drawing.Point(3, 28);
			this.processListView.MultiSelect = false;
			this.processListView.Name = "processListView";
			this.processListView.Size = new System.Drawing.Size(749, 307);
			this.processListView.SmallImageList = this.imageListIcons;
			this.processListView.TabIndex = 4;
			this.processListView.UseCompatibleStateImageBehavior = false;
			this.processListView.View = System.Windows.Forms.View.Details;
			this.processListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.OnProcessListViewColumnClick);
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Tag = "number";
			this.columnHeaderId.Text = "PID";
			this.columnHeaderId.Width = 120;
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Процесс";
			this.columnHeaderName.Width = 250;
			// 
			// columnHeaderThreadCount
			// 
			this.columnHeaderThreadCount.Tag = "number";
			this.columnHeaderThreadCount.Text = "Кол-во потоков";
			this.columnHeaderThreadCount.Width = 120;
			// 
			// columnHeaderWorkingSet
			// 
			this.columnHeaderWorkingSet.Tag = "number";
			this.columnHeaderWorkingSet.Text = "Working Set";
			this.columnHeaderWorkingSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeaderWorkingSet.Width = 80;
			// 
			// columnHeaderSessionId
			// 
			this.columnHeaderSessionId.Tag = "number";
			this.columnHeaderSessionId.Text = "Сессия";
			this.columnHeaderSessionId.Width = 100;
			// 
			// imageListIcons
			// 
			this.imageListIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
			this.imageListIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListIcons.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// mainToolStrip
			// 
			this.mainToolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoRefreshToolStripButton});
			this.mainToolStrip.Location = new System.Drawing.Point(0, 0);
			this.mainToolStrip.Name = "mainToolStrip";
			this.mainToolStrip.Size = new System.Drawing.Size(755, 25);
			this.mainToolStrip.TabIndex = 5;
			// 
			// autoRefreshToolStripButton
			// 
			this.autoRefreshToolStripButton.Checked = true;
			this.autoRefreshToolStripButton.CheckOnClick = true;
			this.autoRefreshToolStripButton.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoRefreshToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
			this.autoRefreshToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("autoRefreshToolStripButton.Image")));
			this.autoRefreshToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.autoRefreshToolStripButton.Name = "autoRefreshToolStripButton";
			this.autoRefreshToolStripButton.Size = new System.Drawing.Size(23, 22);
			this.autoRefreshToolStripButton.Text = "Auto refresh";
			this.autoRefreshToolStripButton.CheckStateChanged += new System.EventHandler(this.OnAutoRefreshToolStripButtonCheckStateChanged);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(755, 384);
			this.Controls.Add(this.panelForProcessList);
			this.Controls.Add(this.mainStatusStrip);
			this.Controls.Add(this.mainMenuStrip);
			this.DoubleBuffered = true;
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
			this.tableLayoutPanel.ResumeLayout(false);
			this.tableLayoutPanel.PerformLayout();
			this.mainToolStrip.ResumeLayout(false);
			this.mainToolStrip.PerformLayout();
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
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem autoRefreshToolStripMenuItem;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
		private System.Windows.Forms.ListView processListView;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderThreadCount;
		private System.Windows.Forms.ToolStrip mainToolStrip;
		private System.Windows.Forms.ToolStripButton autoRefreshToolStripButton;
		private System.Windows.Forms.ColumnHeader columnHeaderSessionId;
		private System.Windows.Forms.ColumnHeader columnHeaderWorkingSet;
		private System.Windows.Forms.ToolStripMenuItem runElevatedToolStripMenuItem;
		private System.Windows.Forms.ImageList imageListIcons;
	}
}
