namespace BelhardTraining.EncodingViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.labelEncoding = new System.Windows.Forms.Label();
            this.comboBoxEncoding = new System.Windows.Forms.ComboBox();
            this.checkBoxShowAllEncodings = new System.Windows.Forms.CheckBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeaderChar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderBytes = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // labelEncoding
            // 
            resources.ApplyResources(this.labelEncoding, "labelEncoding");
            this.labelEncoding.Name = "labelEncoding";
            // 
            // comboBoxEncoding
            // 
            this.comboBoxEncoding.DisplayMember = "DisplayName";
            this.comboBoxEncoding.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxEncoding.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxEncoding, "comboBoxEncoding");
            this.comboBoxEncoding.Name = "comboBoxEncoding";
            this.comboBoxEncoding.SelectedIndexChanged += new System.EventHandler(this.OnComboBoxEncodingSelectedIndexChanged);
            // 
            // checkBoxShowAllEncodings
            // 
            resources.ApplyResources(this.checkBoxShowAllEncodings, "checkBoxShowAllEncodings");
            this.checkBoxShowAllEncodings.Name = "checkBoxShowAllEncodings";
            this.checkBoxShowAllEncodings.UseVisualStyleBackColor = true;
            this.checkBoxShowAllEncodings.CheckedChanged += new System.EventHandler(this.OnCheckBoxShowAllEncodingsCheckedChanged);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderChar,
            this.columnHeaderBytes});
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            resources.ApplyResources(this.listView1, "listView1");
            this.listView1.Name = "listView1";
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderChar
            // 
            resources.ApplyResources(this.columnHeaderChar, "columnHeaderChar");
            // 
            // columnHeaderBytes
            // 
            resources.ApplyResources(this.columnHeaderBytes, "columnHeaderBytes");
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.checkBoxShowAllEncodings);
            this.Controls.Add(this.comboBoxEncoding);
            this.Controls.Add(this.labelEncoding);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.OnLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelEncoding;
        private System.Windows.Forms.ComboBox comboBoxEncoding;
        private System.Windows.Forms.CheckBox checkBoxShowAllEncodings;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeaderChar;
        private System.Windows.Forms.ColumnHeader columnHeaderBytes;


    }
}

