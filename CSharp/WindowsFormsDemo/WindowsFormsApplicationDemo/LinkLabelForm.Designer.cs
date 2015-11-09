namespace BelhardTraining.Windows.Forms
{
    partial class LinkLabelForm
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
            this.lnkWeb = new System.Windows.Forms.LinkLabel();
            this.lnkLongText = new System.Windows.Forms.LinkLabel();
            this.lnkEmail = new System.Windows.Forms.LinkLabel();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // lnkWeb
            // 
            this.lnkWeb.AutoSize = true;
            this.lnkWeb.Location = new System.Drawing.Point(12, 72);
            this.lnkWeb.Name = "lnkWeb";
            this.lnkWeb.Size = new System.Drawing.Size(108, 13);
            this.lnkWeb.TabIndex = 0;
            this.lnkWeb.TabStop = true;
            this.lnkWeb.Text = "http://tc.belhard.com";
            this.lnkWeb.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // lnkLongText
            // 
            this.lnkLongText.AutoSize = true;
            this.lnkLongText.LinkArea = new System.Windows.Forms.LinkArea(0, 0);
            this.lnkLongText.Location = new System.Drawing.Point(12, 168);
            this.lnkLongText.Name = "lnkLongText";
            this.lnkLongText.Size = new System.Drawing.Size(256, 13);
            this.lnkLongText.TabIndex = 1;
            this.lnkLongText.Text = "Учебный центр Белхард предлагает курсы по C#";
            this.toolTip1.SetToolTip(this.lnkLongText, "xyz");
            this.lnkLongText.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLongText_LinkClicked);
            // 
            // lnkEmail
            // 
            this.lnkEmail.AutoSize = true;
            this.lnkEmail.Location = new System.Drawing.Point(12, 125);
            this.lnkEmail.Name = "lnkEmail";
            this.lnkEmail.Size = new System.Drawing.Size(105, 13);
            this.lnkEmail.TabIndex = 2;
            this.lnkEmail.TabStop = true;
            this.lnkEmail.Text = "inbox@example.com";
            this.lnkEmail.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkEmail_LinkClicked);
            // 
            // tbDescription
            // 
            this.tbDescription.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbDescription.Location = new System.Drawing.Point(12, 12);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ReadOnly = true;
            this.tbDescription.Size = new System.Drawing.Size(479, 37);
            this.tbDescription.TabIndex = 4;
            this.tbDescription.Text = "Элемент управления LinkLabel позволяет отображать текст в виде гиперссылки с возм" +
    "ожностью выполнения произвольного действия";
            // 
            // LinkLabelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 305);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.lnkEmail);
            this.Controls.Add(this.lnkLongText);
            this.Controls.Add(this.lnkWeb);
            this.Name = "LinkLabelForm";
            this.Text = "Элемент управления LinkLabel";
            this.Load += new System.EventHandler(this.HandleFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.LinkLabel lnkWeb;
        private System.Windows.Forms.LinkLabel lnkLongText;
        private System.Windows.Forms.LinkLabel lnkEmail;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}