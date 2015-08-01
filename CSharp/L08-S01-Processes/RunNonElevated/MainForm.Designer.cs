namespace RunNonElevated
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
            this.panelAdmin = new System.Windows.Forms.Panel();
            this.lblArguments = new System.Windows.Forms.Label();
            this.tbArguments = new System.Windows.Forms.TextBox();
            this.lblFileName = new System.Windows.Forms.Label();
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.btnRun = new System.Windows.Forms.Button();
            this.panelNonAdmin = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.btnRunSelf = new System.Windows.Forms.Button();
            this.panelAdminNonElevated = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.panelAdmin.SuspendLayout();
            this.panelNonAdmin.SuspendLayout();
            this.panelAdminNonElevated.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelAdmin
            // 
            this.panelAdmin.Controls.Add(this.lblFileName);
            this.panelAdmin.Controls.Add(this.tbFileName);
            this.panelAdmin.Controls.Add(this.lblArguments);
            this.panelAdmin.Controls.Add(this.tbArguments);
            this.panelAdmin.Controls.Add(this.btnRun);
            this.panelAdmin.Controls.Add(this.btnRunSelf);
            this.panelAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdmin.Location = new System.Drawing.Point(0, 0);
            this.panelAdmin.Name = "panelAdmin";
            this.panelAdmin.Padding = new System.Windows.Forms.Padding(10);
            this.panelAdmin.Size = new System.Drawing.Size(355, 294);
            this.panelAdmin.TabIndex = 0;
            // 
            // lblArguments
            // 
            this.lblArguments.AutoSize = true;
            this.lblArguments.Location = new System.Drawing.Point(12, 64);
            this.lblArguments.Name = "lblArguments";
            this.lblArguments.Size = new System.Drawing.Size(63, 13);
            this.lblArguments.TabIndex = 2;
            this.lblArguments.Text = "Аргументы";
            // 
            // tbArguments
            // 
            this.tbArguments.Location = new System.Drawing.Point(15, 80);
            this.tbArguments.Name = "tbArguments";
            this.tbArguments.Size = new System.Drawing.Size(327, 20);
            this.tbArguments.TabIndex = 3;
            // 
            // lblFileName
            // 
            this.lblFileName.AutoSize = true;
            this.lblFileName.Location = new System.Drawing.Point(12, 10);
            this.lblFileName.Name = "lblFileName";
            this.lblFileName.Size = new System.Drawing.Size(74, 13);
            this.lblFileName.TabIndex = 0;
            this.lblFileName.Text = "Путь к файлу";
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(12, 26);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(331, 20);
            this.tbFileName.TabIndex = 1;
            // 
            // btnRun
            // 
            this.btnRun.Location = new System.Drawing.Point(30, 151);
            this.btnRun.Name = "btnRun";
            this.btnRun.Size = new System.Drawing.Size(75, 23);
            this.btnRun.TabIndex = 4;
            this.btnRun.Text = "button1";
            this.btnRun.UseVisualStyleBackColor = true;
            this.btnRun.Click += new System.EventHandler(this.btnRun_Click);
            // 
            // panelNonAdmin
            // 
            this.panelNonAdmin.Controls.Add(this.label3);
            this.panelNonAdmin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelNonAdmin.Location = new System.Drawing.Point(0, 0);
            this.panelNonAdmin.Name = "panelNonAdmin";
            this.panelNonAdmin.Size = new System.Drawing.Size(355, 294);
            this.panelNonAdmin.TabIndex = 10;
            this.panelNonAdmin.Visible = false;
            // 
            // label3
            // 
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(355, 294);
            this.label3.TabIndex = 0;
            this.label3.Text = "Запустите программу от имени администратора";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnRunSelf
            // 
            this.btnRunSelf.Location = new System.Drawing.Point(133, 151);
            this.btnRunSelf.Name = "btnRunSelf";
            this.btnRunSelf.Size = new System.Drawing.Size(139, 23);
            this.btnRunSelf.TabIndex = 5;
            this.btnRunSelf.Text = "Запустить свою копию";
            this.btnRunSelf.UseVisualStyleBackColor = true;
            this.btnRunSelf.Click += new System.EventHandler(this.btnRunSelf_Click);
            // 
            // panelAdminNonElevated
            // 
            this.panelAdminNonElevated.Controls.Add(this.label4);
            this.panelAdminNonElevated.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelAdminNonElevated.Location = new System.Drawing.Point(0, 0);
            this.panelAdminNonElevated.Name = "panelAdminNonElevated";
            this.panelAdminNonElevated.Size = new System.Drawing.Size(355, 294);
            this.panelAdminNonElevated.TabIndex = 11;
            this.panelAdminNonElevated.Visible = false;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(355, 294);
            this.label4.TabIndex = 0;
            this.label4.Text = "Программа работает от имени учетной записи имеющий привилегии администратора, одн" +
    "ако была запущена без elevated привилегий.";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 294);
            this.Controls.Add(this.panelAdmin);
            this.Controls.Add(this.panelAdminNonElevated);
            this.Controls.Add(this.panelNonAdmin);
            this.Name = "MainForm";
            this.Text = "Демо запуска без elevated привилегий";
            this.panelAdmin.ResumeLayout(false);
            this.panelAdmin.PerformLayout();
            this.panelNonAdmin.ResumeLayout(false);
            this.panelAdminNonElevated.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelAdmin;
        private System.Windows.Forms.Label lblArguments;
        private System.Windows.Forms.TextBox tbArguments;
        private System.Windows.Forms.Label lblFileName;
        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Button btnRun;
        private System.Windows.Forms.Panel panelNonAdmin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnRunSelf;
        private System.Windows.Forms.Panel panelAdminNonElevated;
        private System.Windows.Forms.Label label4;

    }
}

