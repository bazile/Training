namespace EnvironmentInformation
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
            System.Windows.Forms.ColumnHeader columnHeaderVarName;
            System.Windows.Forms.ColumnHeader columnHeaderVarValue;
            System.Windows.Forms.ColumnHeader columnHeaderProperty;
            System.Windows.Forms.ColumnHeader columnHeaderPropertyValue;
            System.Windows.Forms.ContextMenuStrip contextMenuForSysInfo;
            System.Windows.Forms.ToolStripMenuItem menuItemMsdnEng;
            System.Windows.Forms.ToolStripMenuItem menuItemMsdnRus;
            System.Windows.Forms.ContextMenuStrip contextMenuForEnvVars;
            System.Windows.Forms.ToolStripMenuItem menuItemOpenEnvVarDialog;
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("Класс System.Environment", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("Класс System.Windows.Forms.SystemInformation", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ColumnHeader columnHeaderSpecialName;
            System.Windows.Forms.ColumnHeader columnHeaderSpecialPath;
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageSysInfo = new System.Windows.Forms.TabPage();
            this.listViewSysInfo = new System.Windows.Forms.ListView();
            this.tabPageEnv = new System.Windows.Forms.TabPage();
            this.listViewVars = new System.Windows.Forms.ListView();
            this.tabPagePaths = new System.Windows.Forms.TabPage();
            this.listViewPaths = new System.Windows.Forms.ListView();
            columnHeaderVarName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderVarValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderProperty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderPropertyValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            contextMenuForSysInfo = new System.Windows.Forms.ContextMenuStrip(this.components);
            menuItemMsdnEng = new System.Windows.Forms.ToolStripMenuItem();
            menuItemMsdnRus = new System.Windows.Forms.ToolStripMenuItem();
            contextMenuForEnvVars = new System.Windows.Forms.ContextMenuStrip(this.components);
            menuItemOpenEnvVarDialog = new System.Windows.Forms.ToolStripMenuItem();
            columnHeaderSpecialName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            columnHeaderSpecialPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            contextMenuForSysInfo.SuspendLayout();
            contextMenuForEnvVars.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageSysInfo.SuspendLayout();
            this.tabPageEnv.SuspendLayout();
            this.tabPagePaths.SuspendLayout();
            this.SuspendLayout();
            // 
            // columnHeaderVarName
            // 
            columnHeaderVarName.Text = "Имя переменной";
            columnHeaderVarName.Width = 105;
            // 
            // columnHeaderVarValue
            // 
            columnHeaderVarValue.Text = "Значение";
            columnHeaderVarValue.Width = 110;
            // 
            // columnHeaderProperty
            // 
            columnHeaderProperty.Text = "Свойство";
            // 
            // columnHeaderPropertyValue
            // 
            columnHeaderPropertyValue.Text = "Значение";
            // 
            // contextMenuForSysInfo
            // 
            contextMenuForSysInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuItemMsdnEng,
            menuItemMsdnRus});
            contextMenuForSysInfo.Name = "contextMenuForSysInfo";
            contextMenuForSysInfo.ShowImageMargin = false;
            contextMenuForSysInfo.Size = new System.Drawing.Size(274, 48);
            // 
            // menuItemMsdnEng
            // 
            menuItemMsdnEng.Name = "menuItemMsdnEng";
            menuItemMsdnEng.Size = new System.Drawing.Size(273, 22);
            menuItemMsdnEng.Tag = "EN-US";
            menuItemMsdnEng.Text = "Открыть справку MSDN на англиийском";
            menuItemMsdnEng.Click += new System.EventHandler(this.OnSysInfoContextItem_Click);
            // 
            // menuItemMsdnRus
            // 
            menuItemMsdnRus.Name = "menuItemMsdnRus";
            menuItemMsdnRus.Size = new System.Drawing.Size(273, 22);
            menuItemMsdnRus.Tag = "RU-RU";
            menuItemMsdnRus.Text = "Открыть справку MSDN на русском";
            menuItemMsdnRus.Click += new System.EventHandler(this.OnSysInfoContextItem_Click);
            // 
            // contextMenuForEnvVars
            // 
            contextMenuForEnvVars.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            menuItemOpenEnvVarDialog});
            contextMenuForEnvVars.Name = "contextMenuForEnvVars";
            contextMenuForEnvVars.ShowImageMargin = false;
            contextMenuForEnvVars.Size = new System.Drawing.Size(302, 26);
            // 
            // menuItemOpenEnvVarDialog
            // 
            menuItemOpenEnvVarDialog.Name = "menuItemOpenEnvVarDialog";
            menuItemOpenEnvVarDialog.Size = new System.Drawing.Size(301, 22);
            menuItemOpenEnvVarDialog.Text = "Открыть диалог редактирования переменных";
            menuItemOpenEnvVarDialog.Click += new System.EventHandler(this.OnOpenEnvVarDialogItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageSysInfo);
            this.tabControl.Controls.Add(this.tabPageEnv);
            this.tabControl.Controls.Add(this.tabPagePaths);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(623, 319);
            this.tabControl.TabIndex = 0;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tabPageSysInfo
            // 
            this.tabPageSysInfo.Controls.Add(this.listViewSysInfo);
            this.tabPageSysInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPageSysInfo.Name = "tabPageSysInfo";
            this.tabPageSysInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSysInfo.Size = new System.Drawing.Size(615, 293);
            this.tabPageSysInfo.TabIndex = 0;
            this.tabPageSysInfo.Text = "Системная информация";
            this.tabPageSysInfo.UseVisualStyleBackColor = true;
            // 
            // listViewSysInfo
            // 
            this.listViewSysInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeaderProperty,
            columnHeaderPropertyValue});
            this.listViewSysInfo.ContextMenuStrip = contextMenuForSysInfo;
            this.listViewSysInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewSysInfo.FullRowSelect = true;
            this.listViewSysInfo.GridLines = true;
            listViewGroup1.Header = "Класс System.Environment";
            listViewGroup1.Name = "Environment";
            listViewGroup2.Header = "Класс System.Windows.Forms.SystemInformation";
            listViewGroup2.Name = "SysInfo";
            this.listViewSysInfo.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2});
            this.listViewSysInfo.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.listViewSysInfo.Location = new System.Drawing.Point(3, 3);
            this.listViewSysInfo.Name = "listViewSysInfo";
            this.listViewSysInfo.Size = new System.Drawing.Size(609, 287);
            this.listViewSysInfo.TabIndex = 0;
            this.listViewSysInfo.UseCompatibleStateImageBehavior = false;
            this.listViewSysInfo.View = System.Windows.Forms.View.Details;
            // 
            // tabPageEnv
            // 
            this.tabPageEnv.Controls.Add(this.listViewVars);
            this.tabPageEnv.Location = new System.Drawing.Point(4, 22);
            this.tabPageEnv.Name = "tabPageEnv";
            this.tabPageEnv.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageEnv.Size = new System.Drawing.Size(615, 293);
            this.tabPageEnv.TabIndex = 1;
            this.tabPageEnv.Text = "Переменные окружения";
            this.tabPageEnv.UseVisualStyleBackColor = true;
            // 
            // listViewVars
            // 
            this.listViewVars.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeaderVarName,
            columnHeaderVarValue});
            this.listViewVars.ContextMenuStrip = contextMenuForEnvVars;
            this.listViewVars.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewVars.FullRowSelect = true;
            this.listViewVars.GridLines = true;
            this.listViewVars.Location = new System.Drawing.Point(3, 3);
            this.listViewVars.Name = "listViewVars";
            this.listViewVars.Size = new System.Drawing.Size(609, 287);
            this.listViewVars.TabIndex = 0;
            this.listViewVars.UseCompatibleStateImageBehavior = false;
            this.listViewVars.View = System.Windows.Forms.View.Details;
            // 
            // tabPagePaths
            // 
            this.tabPagePaths.Controls.Add(this.listViewPaths);
            this.tabPagePaths.Location = new System.Drawing.Point(4, 22);
            this.tabPagePaths.Name = "tabPagePaths";
            this.tabPagePaths.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePaths.Size = new System.Drawing.Size(615, 293);
            this.tabPagePaths.TabIndex = 2;
            this.tabPagePaths.Text = "Пути";
            this.tabPagePaths.UseVisualStyleBackColor = true;
            // 
            // listViewPaths
            // 
            this.listViewPaths.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            columnHeaderSpecialName,
            columnHeaderSpecialPath});
            this.listViewPaths.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listViewPaths.FullRowSelect = true;
            this.listViewPaths.GridLines = true;
            this.listViewPaths.Location = new System.Drawing.Point(3, 3);
            this.listViewPaths.Name = "listViewPaths";
            this.listViewPaths.Size = new System.Drawing.Size(609, 287);
            this.listViewPaths.TabIndex = 0;
            this.listViewPaths.UseCompatibleStateImageBehavior = false;
            this.listViewPaths.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderSpecialName
            // 
            columnHeaderSpecialName.Text = "SpecialFolder";
            // 
            // columnHeaderSpecialPath
            // 
            columnHeaderSpecialPath.Text = "Путь";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 319);
            this.Controls.Add(this.tabControl);
            this.Name = "MainForm";
            this.Text = "Информация об окружении процесса";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OnLoad);
            contextMenuForSysInfo.ResumeLayout(false);
            contextMenuForEnvVars.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageSysInfo.ResumeLayout(false);
            this.tabPageEnv.ResumeLayout(false);
            this.tabPagePaths.ResumeLayout(false);
            this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl;
		private System.Windows.Forms.TabPage tabPageSysInfo;
		private System.Windows.Forms.TabPage tabPageEnv;
		private System.Windows.Forms.ListView listViewVars;
		private System.Windows.Forms.ListView listViewSysInfo;
        private System.Windows.Forms.TabPage tabPagePaths;
        private System.Windows.Forms.ListView listViewPaths;
	}
}

