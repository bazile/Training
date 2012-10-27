namespace CultureExplorer.WinForms
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
			this.statusStrip = new System.Windows.Forms.StatusStrip();
			this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.panel = new System.Windows.Forms.Panel();
			this.splitContainer = new System.Windows.Forms.SplitContainer();
			this.treeViewCultures = new System.Windows.Forms.TreeView();
			this.mainMenu = new System.Windows.Forms.MenuStrip();
			this.menuItemExplorer = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
			this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
			this.cultureInfoControl = new CultureExplorer.WinForms.CultureInfoControl();
			this.statusStrip.SuspendLayout();
			this.panel.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
			this.splitContainer.Panel1.SuspendLayout();
			this.splitContainer.Panel2.SuspendLayout();
			this.splitContainer.SuspendLayout();
			this.mainMenu.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip
			// 
			this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
			this.statusStrip.Location = new System.Drawing.Point(0, 323);
			this.statusStrip.Name = "statusStrip";
			this.statusStrip.Size = new System.Drawing.Size(440, 22);
			this.statusStrip.TabIndex = 0;
			this.statusStrip.Text = "statusStrip1";
			// 
			// statusLabel
			// 
			this.statusLabel.Name = "statusLabel";
			this.statusLabel.Size = new System.Drawing.Size(121, 17);
			this.statusLabel.Text = "Number of cultures: ?";
			// 
			// panel
			// 
			this.panel.Controls.Add(this.splitContainer);
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Location = new System.Drawing.Point(0, 24);
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(440, 299);
			this.panel.TabIndex = 1;
			// 
			// splitContainer
			// 
			this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer.Location = new System.Drawing.Point(0, 0);
			this.splitContainer.Name = "splitContainer";
			// 
			// splitContainer.Panel1
			// 
			this.splitContainer.Panel1.Controls.Add(this.treeViewCultures);
			this.splitContainer.Panel1MinSize = 150;
			// 
			// splitContainer.Panel2
			// 
			this.splitContainer.Panel2.Controls.Add(this.cultureInfoControl);
			this.splitContainer.Size = new System.Drawing.Size(440, 299);
			this.splitContainer.SplitterDistance = 150;
			this.splitContainer.TabIndex = 0;
			// 
			// treeViewCultures
			// 
			this.treeViewCultures.Dock = System.Windows.Forms.DockStyle.Fill;
			this.treeViewCultures.Location = new System.Drawing.Point(0, 0);
			this.treeViewCultures.Name = "treeViewCultures";
			this.treeViewCultures.Size = new System.Drawing.Size(150, 299);
			this.treeViewCultures.TabIndex = 0;
			this.treeViewCultures.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnCulturesTreeViewAfterSelect);
			// 
			// mainMenu
			// 
			this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExplorer,
            this.menuItemView});
			this.mainMenu.Location = new System.Drawing.Point(0, 0);
			this.mainMenu.Name = "mainMenu";
			this.mainMenu.Size = new System.Drawing.Size(440, 24);
			this.mainMenu.TabIndex = 2;
			this.mainMenu.Text = "menuStrip1";
			// 
			// menuItemExplorer
			// 
			this.menuItemExplorer.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExit});
			this.menuItemExplorer.Name = "menuItemExplorer";
			this.menuItemExplorer.Size = new System.Drawing.Size(61, 20);
			this.menuItemExplorer.Text = "&Explorer";
			// 
			// menuItemExit
			// 
			this.menuItemExit.Name = "menuItemExit";
			this.menuItemExit.Size = new System.Drawing.Size(92, 22);
			this.menuItemExit.Text = "E&xit";
			this.menuItemExit.Click += new System.EventHandler(this.OnExitMenuItemClick);
			// 
			// menuItemView
			// 
			this.menuItemView.Name = "menuItemView";
			this.menuItemView.Size = new System.Drawing.Size(44, 20);
			this.menuItemView.Text = "&View";
			// 
			// cultureInfoControl
			// 
			this.cultureInfoControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cultureInfoControl.Location = new System.Drawing.Point(0, 0);
			this.cultureInfoControl.Name = "cultureInfoControl";
			this.cultureInfoControl.Size = new System.Drawing.Size(286, 299);
			this.cultureInfoControl.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(440, 345);
			this.Controls.Add(this.panel);
			this.Controls.Add(this.statusStrip);
			this.Controls.Add(this.mainMenu);
			this.Name = "MainForm";
			this.Text = "CultureExplorer";
			this.Load += new System.EventHandler(this.OnMainFormLoad);
			this.statusStrip.ResumeLayout(false);
			this.statusStrip.PerformLayout();
			this.panel.ResumeLayout(false);
			this.splitContainer.Panel1.ResumeLayout(false);
			this.splitContainer.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
			this.splitContainer.ResumeLayout(false);
			this.mainMenu.ResumeLayout(false);
			this.mainMenu.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip;
		private System.Windows.Forms.Panel panel;
		private System.Windows.Forms.SplitContainer splitContainer;
		private System.Windows.Forms.TreeView treeViewCultures;
		private System.Windows.Forms.MenuStrip mainMenu;
		private System.Windows.Forms.ToolStripMenuItem menuItemExplorer;
		private System.Windows.Forms.ToolStripMenuItem menuItemExit;
		private System.Windows.Forms.ToolStripMenuItem menuItemView;
		private System.Windows.Forms.ToolStripStatusLabel statusLabel;
		private CultureInfoControl cultureInfoControl;
	}
}

