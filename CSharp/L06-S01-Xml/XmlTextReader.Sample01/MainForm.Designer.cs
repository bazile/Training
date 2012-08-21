namespace XmlSamples.Sample01
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
			System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Country", System.Windows.Forms.HorizontalAlignment.Left);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.customersListView = new System.Windows.Forms.ListView();
			this.customerIdColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.companyNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.mainMenuStrip = new System.Windows.Forms.MenuStrip();
			this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.showGroupsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.mainMenuStrip.SuspendLayout();
			this.SuspendLayout();
			// 
			// customersListView
			// 
			this.customersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.customerIdColumnHeader,
            this.companyNameColumnHeader});
			this.customersListView.Dock = System.Windows.Forms.DockStyle.Fill;
			this.customersListView.FullRowSelect = true;
			this.customersListView.GridLines = true;
			listViewGroup1.Header = "Country";
			listViewGroup1.Name = "countryListViewGroup";
			this.customersListView.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1});
			this.customersListView.Location = new System.Drawing.Point(0, 24);
			this.customersListView.Name = "customersListView";
			this.customersListView.Size = new System.Drawing.Size(551, 284);
			this.customersListView.TabIndex = 0;
			this.customersListView.UseCompatibleStateImageBehavior = false;
			this.customersListView.View = System.Windows.Forms.View.Details;
			// 
			// customerIdColumnHeader
			// 
			this.customerIdColumnHeader.Text = "Customer Id";
			this.customerIdColumnHeader.Width = 100;
			// 
			// companyNameColumnHeader
			// 
			this.companyNameColumnHeader.Text = "Company Name";
			this.companyNameColumnHeader.Width = 300;
			// 
			// mainMenuStrip
			// 
			this.mainMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewToolStripMenuItem,
            this.exitToolStripMenuItem});
			this.mainMenuStrip.Location = new System.Drawing.Point(0, 0);
			this.mainMenuStrip.Name = "mainMenuStrip";
			this.mainMenuStrip.Size = new System.Drawing.Size(551, 24);
			this.mainMenuStrip.TabIndex = 1;
			this.mainMenuStrip.Text = "mainMenuStrip";
			// 
			// viewToolStripMenuItem
			// 
			this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showGroupsToolStripMenuItem});
			this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
			this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
			this.viewToolStripMenuItem.Text = "&View";
			// 
			// showGroupsToolStripMenuItem
			// 
			this.showGroupsToolStripMenuItem.Checked = true;
			this.showGroupsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.showGroupsToolStripMenuItem.Name = "showGroupsToolStripMenuItem";
			this.showGroupsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.showGroupsToolStripMenuItem.Text = "Show &groups";
			this.showGroupsToolStripMenuItem.Click += new System.EventHandler(this.OnShowGroupsToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.exitToolStripMenuItem.Text = "E&xit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.OnExitToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(551, 308);
			this.Controls.Add(this.customersListView);
			this.Controls.Add(this.mainMenuStrip);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.mainMenuStrip;
			this.Name = "MainForm";
			this.Text = "Customers";
			this.Load += new System.EventHandler(this.OnMainFormLoad);
			this.mainMenuStrip.ResumeLayout(false);
			this.mainMenuStrip.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ListView customersListView;
		private System.Windows.Forms.ColumnHeader customerIdColumnHeader;
		private System.Windows.Forms.ColumnHeader companyNameColumnHeader;
		private System.Windows.Forms.MenuStrip mainMenuStrip;
		private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showGroupsToolStripMenuItem;
	}
}

