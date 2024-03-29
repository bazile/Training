﻿namespace CultureExplorer.WinForms
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
            System.Windows.Forms.ToolStripSeparator separator1;
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.panel = new System.Windows.Forms.Panel();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.treeViewCultures = new System.Windows.Forms.TreeView();
            this.propertyGridCulture = new System.Windows.Forms.PropertyGrid();
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.menuItemExplorer = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGroupLang = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGroupCountry = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGroupCalendar = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGroupAnsi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGroupOem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemGroupMac = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemGroupEbcdic = new System.Windows.Forms.ToolStripMenuItem();
            separator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip.SuspendLayout();
            this.panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.mainMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // separator1
            // 
            separator1.Name = "separator1";
            separator1.Size = new System.Drawing.Size(221, 6);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.statusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 625);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(828, 22);
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
            this.panel.Size = new System.Drawing.Size(828, 601);
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
            this.splitContainer.Panel2.Controls.Add(this.propertyGridCulture);
            this.splitContainer.Size = new System.Drawing.Size(828, 601);
            this.splitContainer.SplitterDistance = 282;
            this.splitContainer.TabIndex = 0;
            // 
            // treeViewCultures
            // 
            this.treeViewCultures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeViewCultures.Location = new System.Drawing.Point(0, 0);
            this.treeViewCultures.Name = "treeViewCultures";
            this.treeViewCultures.Size = new System.Drawing.Size(282, 601);
            this.treeViewCultures.TabIndex = 0;
            this.treeViewCultures.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.OnCulturesTreeView_AfterSelect);
            // 
            // propertyGridCulture
            // 
            this.propertyGridCulture.CommandsVisibleIfAvailable = false;
            this.propertyGridCulture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.propertyGridCulture.HelpVisible = false;
            this.propertyGridCulture.Location = new System.Drawing.Point(0, 0);
            this.propertyGridCulture.Name = "propertyGridCulture";
            this.propertyGridCulture.PropertySort = System.Windows.Forms.PropertySort.Alphabetical;
            this.propertyGridCulture.Size = new System.Drawing.Size(542, 601);
            this.propertyGridCulture.TabIndex = 2;
            this.propertyGridCulture.ToolbarVisible = false;
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExplorer,
            this.menuItemView});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(828, 24);
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
            this.menuItemExit.Size = new System.Drawing.Size(152, 22);
            this.menuItemExit.Text = "E&xit";
            this.menuItemExit.Click += new System.EventHandler(this.OnExitMenuItem_Click);
            // 
            // menuItemView
            // 
            this.menuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemGroupLang,
            this.menuItemGroupCountry,
            this.menuItemGroupCalendar,
            separator1,
            this.menuItemGroupAnsi,
            this.menuItemGroupEbcdic,
            this.menuItemGroupMac,
            this.menuItemGroupOem,
            this.toolStripSeparator1});
            this.menuItemView.Name = "menuItemView";
            this.menuItemView.Size = new System.Drawing.Size(44, 20);
            this.menuItemView.Text = "&View";
            // 
            // menuItemGroupLang
            // 
            this.menuItemGroupLang.Checked = true;
            this.menuItemGroupLang.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuItemGroupLang.Name = "menuItemGroupLang";
            this.menuItemGroupLang.Size = new System.Drawing.Size(224, 22);
            this.menuItemGroupLang.Text = "Group by language";
            this.menuItemGroupLang.Click += new System.EventHandler(this.OnGroupByMenuItem_Click);
            // 
            // menuItemGroupCountry
            // 
            this.menuItemGroupCountry.Name = "menuItemGroupCountry";
            this.menuItemGroupCountry.Size = new System.Drawing.Size(224, 22);
            this.menuItemGroupCountry.Text = "Group by country";
            this.menuItemGroupCountry.Click += new System.EventHandler(this.OnGroupByMenuItem_Click);
            // 
            // menuItemGroupCalendar
            // 
            this.menuItemGroupCalendar.Name = "menuItemGroupCalendar";
            this.menuItemGroupCalendar.Size = new System.Drawing.Size(224, 22);
            this.menuItemGroupCalendar.Text = "Group by calendar";
            this.menuItemGroupCalendar.Click += new System.EventHandler(this.OnGroupByMenuItem_Click);
            // 
            // menuItemGroupAnsi
            // 
            this.menuItemGroupAnsi.Name = "menuItemGroupAnsi";
            this.menuItemGroupAnsi.Size = new System.Drawing.Size(224, 22);
            this.menuItemGroupAnsi.Text = "Group by ANSI code page";
            this.menuItemGroupAnsi.Click += new System.EventHandler(this.OnGroupByMenuItem_Click);
            // 
            // menuItemGroupOem
            // 
            this.menuItemGroupOem.Name = "menuItemGroupOem";
            this.menuItemGroupOem.Size = new System.Drawing.Size(224, 22);
            this.menuItemGroupOem.Text = "Group by OEM code page";
            this.menuItemGroupOem.Click += new System.EventHandler(this.OnGroupByMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(221, 6);
            // 
            // menuItemGroupMac
            // 
            this.menuItemGroupMac.Name = "menuItemGroupMac";
            this.menuItemGroupMac.Size = new System.Drawing.Size(224, 22);
            this.menuItemGroupMac.Text = "Group by Mac code page";
            this.menuItemGroupMac.Visible = false;
            this.menuItemGroupMac.Click += new System.EventHandler(this.OnGroupByMenuItem_Click);
            // 
            // menuItemGroupEbcdic
            // 
            this.menuItemGroupEbcdic.Name = "menuItemGroupEbcdic";
            this.menuItemGroupEbcdic.Size = new System.Drawing.Size(224, 22);
            this.menuItemGroupEbcdic.Text = "Group by EBCDIC code page";
            this.menuItemGroupEbcdic.Visible = false;
            this.menuItemGroupEbcdic.Click += new System.EventHandler(this.OnGroupByMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 647);
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
        private System.Windows.Forms.PropertyGrid propertyGridCulture;
        private System.Windows.Forms.ToolStripMenuItem menuItemGroupLang;
        private System.Windows.Forms.ToolStripMenuItem menuItemGroupCountry;
        private System.Windows.Forms.ToolStripMenuItem menuItemGroupCalendar;
        private System.Windows.Forms.ToolStripMenuItem menuItemGroupAnsi;
        private System.Windows.Forms.ToolStripMenuItem menuItemGroupOem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuItemGroupMac;
        private System.Windows.Forms.ToolStripMenuItem menuItemGroupEbcdic;
    }
}

