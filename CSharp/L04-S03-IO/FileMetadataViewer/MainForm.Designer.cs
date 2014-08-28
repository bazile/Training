namespace BelhardTraining.LessonIO
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
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.btnBrowse = new System.Windows.Forms.Button();
			this.cbRecentFiles = new System.Windows.Forms.ComboBox();
			this.lvProperties = new System.Windows.Forms.ListView();
			this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
			this.tableLayoutPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Иображения|*.jpg;*.png|Все файлы|*.*";
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(684, 3);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(34, 21);
			this.btnBrowse.TabIndex = 1;
			this.btnBrowse.Text = "...";
			this.toolTip.SetToolTip(this.btnBrowse, "Выбор файла");
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.OnButtonBrowse_Click);
			// 
			// cbRecentFiles
			// 
			this.cbRecentFiles.Dock = System.Windows.Forms.DockStyle.Fill;
			this.cbRecentFiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRecentFiles.FormattingEnabled = true;
			this.cbRecentFiles.Location = new System.Drawing.Point(3, 3);
			this.cbRecentFiles.Name = "cbRecentFiles";
			this.cbRecentFiles.Size = new System.Drawing.Size(675, 21);
			this.cbRecentFiles.TabIndex = 0;
			this.cbRecentFiles.SelectedIndexChanged += new System.EventHandler(this.OnRecentFiles_SelectedIndexChanged);
			// 
			// lvProperties
			// 
			this.lvProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
			this.tableLayoutPanel.SetColumnSpan(this.lvProperties, 2);
			this.lvProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvProperties.FullRowSelect = true;
			this.lvProperties.GridLines = true;
			this.lvProperties.Location = new System.Drawing.Point(3, 33);
			this.lvProperties.Name = "lvProperties";
			this.lvProperties.Size = new System.Drawing.Size(715, 367);
			this.lvProperties.TabIndex = 2;
			this.lvProperties.UseCompatibleStateImageBehavior = false;
			this.lvProperties.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = " Свойство";
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Значение";
			// 
			// tableLayoutPanel
			// 
			this.tableLayoutPanel.ColumnCount = 2;
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel.Controls.Add(this.cbRecentFiles, 0, 0);
			this.tableLayoutPanel.Controls.Add(this.lvProperties, 0, 1);
			this.tableLayoutPanel.Controls.Add(this.btnBrowse, 1, 0);
			this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel.Name = "tableLayoutPanel";
			this.tableLayoutPanel.RowCount = 2;
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel.Size = new System.Drawing.Size(721, 403);
			this.tableLayoutPanel.TabIndex = 9;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(721, 403);
			this.Controls.Add(this.tableLayoutPanel);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.Text = "Просмотр метаданных файла";
			this.Load += new System.EventHandler(this.OnLoad);
			this.tableLayoutPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.ComboBox cbRecentFiles;
		private System.Windows.Forms.ListView lvProperties;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
	}
}

