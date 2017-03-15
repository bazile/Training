namespace TrainingCenter.Windows.Forms
{
    partial class PlaceholderTextBoxForm
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
            this.tbUserName = new TrainingCenter.Windows.Forms.Controls.PlaceholderTextBox();
            this.tbPassword = new TrainingCenter.Windows.Forms.Controls.PlaceholderTextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbUserName
            // 
            this.tbUserName.Location = new System.Drawing.Point(48, 70);
            this.tbUserName.Name = "tbUserName";
            this.tbUserName.PlaceholderText = "Имя пользователя";
            this.tbUserName.Size = new System.Drawing.Size(135, 20);
            this.tbUserName.TabIndex = 0;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(48, 106);
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PlaceholderText = "Пароль";
            this.tbPassword.Size = new System.Drawing.Size(135, 20);
            this.tbPassword.TabIndex = 1;
            this.tbPassword.UseSystemPasswordChar = true;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(48, 156);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(86, 23);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Вход";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // PlaceholderTextBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 262);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.tbPassword);
            this.Controls.Add(this.tbUserName);
            this.Name = "PlaceholderTextBoxForm";
            this.Text = "PlaceholderTextBoxForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.PlaceholderTextBox tbUserName;
        private Controls.PlaceholderTextBox tbPassword;
        private System.Windows.Forms.Button btnLogin;
    }
}