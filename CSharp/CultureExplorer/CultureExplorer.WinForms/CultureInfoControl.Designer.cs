namespace CultureExplorer.WinForms
{
	partial class CultureInfoControl
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.labelName = new System.Windows.Forms.Label();
			this.labelNameValue = new System.Windows.Forms.Label();
			this.labelNativeName = new System.Windows.Forms.Label();
			this.labelNativeNameValue = new System.Windows.Forms.Label();
			this.labelEnglishNameValue = new System.Windows.Forms.Label();
			this.labelEnglishName = new System.Windows.Forms.Label();
			this.labelCalendarTypeValue = new System.Windows.Forms.Label();
			this.labelCalendarType = new System.Windows.Forms.Label();
			this.calendarAlgTypeValue = new System.Windows.Forms.Label();
			this.calendarAlgType = new System.Windows.Forms.Label();
			this.labelMonthsInYearValue = new System.Windows.Forms.Label();
			this.labelMonthsInYear = new System.Windows.Forms.Label();
			this.labelDisplayNameValue = new System.Windows.Forms.Label();
			this.labelDisplayName = new System.Windows.Forms.Label();
			this.labelLCIDValue = new System.Windows.Forms.Label();
			this.labelLCID = new System.Windows.Forms.Label();
			this.labelDatePatternValue = new System.Windows.Forms.Label();
			this.labelDatePattern = new System.Windows.Forms.Label();
			this.cultureInfoViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.labelNativeDigitsValue = new System.Windows.Forms.Label();
			this.labelNativeDigits = new System.Windows.Forms.Label();
			this.labelMonthNamesValue = new System.Windows.Forms.Label();
			this.labelMonthNames = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.cultureInfoViewModelBindingSource)).BeginInit();
			this.SuspendLayout();
			// 
			// labelName
			// 
			this.labelName.AutoSize = true;
			this.labelName.Location = new System.Drawing.Point(3, 3);
			this.labelName.Margin = new System.Windows.Forms.Padding(3);
			this.labelName.Name = "labelName";
			this.labelName.Size = new System.Drawing.Size(38, 13);
			this.labelName.TabIndex = 0;
			this.labelName.Text = "Name:";
			// 
			// labelNameValue
			// 
			this.labelNameValue.AutoSize = true;
			this.labelNameValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "Name", true));
			this.labelNameValue.Location = new System.Drawing.Point(126, 3);
			this.labelNameValue.Name = "labelNameValue";
			this.labelNameValue.Size = new System.Drawing.Size(13, 13);
			this.labelNameValue.TabIndex = 1;
			this.labelNameValue.Text = "?";
			// 
			// labelNativeName
			// 
			this.labelNativeName.AutoSize = true;
			this.labelNativeName.Location = new System.Drawing.Point(3, 23);
			this.labelNativeName.Name = "labelNativeName";
			this.labelNativeName.Size = new System.Drawing.Size(70, 13);
			this.labelNativeName.TabIndex = 2;
			this.labelNativeName.Text = "Native name:";
			// 
			// labelNativeNameValue
			// 
			this.labelNativeNameValue.AutoSize = true;
			this.labelNativeNameValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "NativeName", true));
			this.labelNativeNameValue.Location = new System.Drawing.Point(126, 23);
			this.labelNativeNameValue.Name = "labelNativeNameValue";
			this.labelNativeNameValue.Size = new System.Drawing.Size(13, 13);
			this.labelNativeNameValue.TabIndex = 3;
			this.labelNativeNameValue.Text = "?";
			// 
			// labelEnglishNameValue
			// 
			this.labelEnglishNameValue.AutoSize = true;
			this.labelEnglishNameValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "EnglishName", true));
			this.labelEnglishNameValue.Location = new System.Drawing.Point(126, 43);
			this.labelEnglishNameValue.Name = "labelEnglishNameValue";
			this.labelEnglishNameValue.Size = new System.Drawing.Size(13, 13);
			this.labelEnglishNameValue.TabIndex = 5;
			this.labelEnglishNameValue.Text = "?";
			// 
			// labelEnglishName
			// 
			this.labelEnglishName.AutoSize = true;
			this.labelEnglishName.Location = new System.Drawing.Point(3, 43);
			this.labelEnglishName.Name = "labelEnglishName";
			this.labelEnglishName.Size = new System.Drawing.Size(73, 13);
			this.labelEnglishName.TabIndex = 4;
			this.labelEnglishName.Text = "English name:";
			// 
			// labelCalendarTypeValue
			// 
			this.labelCalendarTypeValue.AutoSize = true;
			this.labelCalendarTypeValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "CalendarType", true));
			this.labelCalendarTypeValue.Location = new System.Drawing.Point(126, 83);
			this.labelCalendarTypeValue.Name = "labelCalendarTypeValue";
			this.labelCalendarTypeValue.Size = new System.Drawing.Size(13, 13);
			this.labelCalendarTypeValue.TabIndex = 7;
			this.labelCalendarTypeValue.Text = "?";
			// 
			// labelCalendarType
			// 
			this.labelCalendarType.AutoSize = true;
			this.labelCalendarType.Location = new System.Drawing.Point(3, 83);
			this.labelCalendarType.Name = "labelCalendarType";
			this.labelCalendarType.Size = new System.Drawing.Size(75, 13);
			this.labelCalendarType.TabIndex = 6;
			this.labelCalendarType.Text = "Calendar type:";
			// 
			// calendarAlgTypeValue
			// 
			this.calendarAlgTypeValue.AutoSize = true;
			this.calendarAlgTypeValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "CalendarAlgorithmType", true));
			this.calendarAlgTypeValue.Location = new System.Drawing.Point(126, 103);
			this.calendarAlgTypeValue.Name = "calendarAlgTypeValue";
			this.calendarAlgTypeValue.Size = new System.Drawing.Size(13, 13);
			this.calendarAlgTypeValue.TabIndex = 9;
			this.calendarAlgTypeValue.Text = "?";
			// 
			// calendarAlgType
			// 
			this.calendarAlgType.AutoSize = true;
			this.calendarAlgType.Location = new System.Drawing.Point(3, 103);
			this.calendarAlgType.Name = "calendarAlgType";
			this.calendarAlgType.Size = new System.Drawing.Size(120, 13);
			this.calendarAlgType.TabIndex = 8;
			this.calendarAlgType.Text = "Calendar algorithm type:";
			// 
			// labelMonthsInYearValue
			// 
			this.labelMonthsInYearValue.AutoSize = true;
			this.labelMonthsInYearValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "MonthsInYear", true));
			this.labelMonthsInYearValue.Location = new System.Drawing.Point(126, 123);
			this.labelMonthsInYearValue.Name = "labelMonthsInYearValue";
			this.labelMonthsInYearValue.Size = new System.Drawing.Size(13, 13);
			this.labelMonthsInYearValue.TabIndex = 11;
			this.labelMonthsInYearValue.Text = "?";
			// 
			// labelMonthsInYear
			// 
			this.labelMonthsInYear.AutoSize = true;
			this.labelMonthsInYear.Location = new System.Drawing.Point(3, 123);
			this.labelMonthsInYear.Name = "labelMonthsInYear";
			this.labelMonthsInYear.Size = new System.Drawing.Size(79, 13);
			this.labelMonthsInYear.TabIndex = 10;
			this.labelMonthsInYear.Text = "Months in year:";
			// 
			// labelDisplayNameValue
			// 
			this.labelDisplayNameValue.AutoSize = true;
			this.labelDisplayNameValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "DisplayName", true));
			this.labelDisplayNameValue.Location = new System.Drawing.Point(126, 63);
			this.labelDisplayNameValue.Name = "labelDisplayNameValue";
			this.labelDisplayNameValue.Size = new System.Drawing.Size(13, 13);
			this.labelDisplayNameValue.TabIndex = 13;
			this.labelDisplayNameValue.Text = "?";
			// 
			// labelDisplayName
			// 
			this.labelDisplayName.AutoSize = true;
			this.labelDisplayName.Location = new System.Drawing.Point(3, 63);
			this.labelDisplayName.Name = "labelDisplayName";
			this.labelDisplayName.Size = new System.Drawing.Size(73, 13);
			this.labelDisplayName.TabIndex = 12;
			this.labelDisplayName.Text = "Display name:";
			// 
			// labelLCIDValue
			// 
			this.labelLCIDValue.AutoSize = true;
			this.labelLCIDValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "LCID", true));
			this.labelLCIDValue.Location = new System.Drawing.Point(126, 143);
			this.labelLCIDValue.Name = "labelLCIDValue";
			this.labelLCIDValue.Size = new System.Drawing.Size(13, 13);
			this.labelLCIDValue.TabIndex = 15;
			this.labelLCIDValue.Text = "?";
			// 
			// labelLCID
			// 
			this.labelLCID.AutoSize = true;
			this.labelLCID.Location = new System.Drawing.Point(3, 143);
			this.labelLCID.Name = "labelLCID";
			this.labelLCID.Size = new System.Drawing.Size(34, 13);
			this.labelLCID.TabIndex = 14;
			this.labelLCID.Text = "LCID:";
			// 
			// labelDatePatternValue
			// 
			this.labelDatePatternValue.AutoSize = true;
			this.labelDatePatternValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "FullDateTimePattern", true));
			this.labelDatePatternValue.Location = new System.Drawing.Point(127, 163);
			this.labelDatePatternValue.Name = "labelDatePatternValue";
			this.labelDatePatternValue.Size = new System.Drawing.Size(13, 13);
			this.labelDatePatternValue.TabIndex = 17;
			this.labelDatePatternValue.Text = "?";
			// 
			// labelDatePattern
			// 
			this.labelDatePattern.AutoSize = true;
			this.labelDatePattern.Location = new System.Drawing.Point(3, 163);
			this.labelDatePattern.Name = "labelDatePattern";
			this.labelDatePattern.Size = new System.Drawing.Size(69, 13);
			this.labelDatePattern.TabIndex = 16;
			this.labelDatePattern.Text = "Date pattern:";
			// 
			// cultureInfoViewModelBindingSource
			// 
			this.cultureInfoViewModelBindingSource.DataSource = typeof(CultureExplorer.WinForms.CultureInfoViewModel);
			// 
			// labelNativeDigitsValue
			// 
			this.labelNativeDigitsValue.AutoSize = true;
			this.labelNativeDigitsValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "NativeDigits", true));
			this.labelNativeDigitsValue.Location = new System.Drawing.Point(128, 183);
			this.labelNativeDigitsValue.Name = "labelNativeDigitsValue";
			this.labelNativeDigitsValue.Size = new System.Drawing.Size(13, 13);
			this.labelNativeDigitsValue.TabIndex = 19;
			this.labelNativeDigitsValue.Text = "?";
			// 
			// labelNativeDigits
			// 
			this.labelNativeDigits.AutoSize = true;
			this.labelNativeDigits.Location = new System.Drawing.Point(4, 183);
			this.labelNativeDigits.Name = "labelNativeDigits";
			this.labelNativeDigits.Size = new System.Drawing.Size(68, 13);
			this.labelNativeDigits.TabIndex = 18;
			this.labelNativeDigits.Text = "Native digits:";
			// 
			// labelMonthNamesValue
			// 
			this.labelMonthNamesValue.AutoSize = true;
			this.labelMonthNamesValue.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.cultureInfoViewModelBindingSource, "MonthNames", true));
			this.labelMonthNamesValue.Location = new System.Drawing.Point(128, 203);
			this.labelMonthNamesValue.Name = "labelMonthNamesValue";
			this.labelMonthNamesValue.Size = new System.Drawing.Size(13, 13);
			this.labelMonthNamesValue.TabIndex = 21;
			this.labelMonthNamesValue.Text = "?";
			// 
			// labelMonthNames
			// 
			this.labelMonthNames.AutoSize = true;
			this.labelMonthNames.Location = new System.Drawing.Point(4, 203);
			this.labelMonthNames.Name = "labelMonthNames";
			this.labelMonthNames.Size = new System.Drawing.Size(74, 13);
			this.labelMonthNames.TabIndex = 20;
			this.labelMonthNames.Text = "Month names:";
			// 
			// CultureInfoControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.labelMonthNamesValue);
			this.Controls.Add(this.labelMonthNames);
			this.Controls.Add(this.labelNativeDigitsValue);
			this.Controls.Add(this.labelNativeDigits);
			this.Controls.Add(this.labelDatePatternValue);
			this.Controls.Add(this.labelDatePattern);
			this.Controls.Add(this.labelLCIDValue);
			this.Controls.Add(this.labelLCID);
			this.Controls.Add(this.labelDisplayNameValue);
			this.Controls.Add(this.labelDisplayName);
			this.Controls.Add(this.labelMonthsInYearValue);
			this.Controls.Add(this.labelMonthsInYear);
			this.Controls.Add(this.calendarAlgTypeValue);
			this.Controls.Add(this.calendarAlgType);
			this.Controls.Add(this.labelCalendarTypeValue);
			this.Controls.Add(this.labelCalendarType);
			this.Controls.Add(this.labelEnglishNameValue);
			this.Controls.Add(this.labelEnglishName);
			this.Controls.Add(this.labelNativeNameValue);
			this.Controls.Add(this.labelNativeName);
			this.Controls.Add(this.labelNameValue);
			this.Controls.Add(this.labelName);
			this.Margin = new System.Windows.Forms.Padding(30);
			this.Name = "CultureInfoControl";
			this.Size = new System.Drawing.Size(334, 315);
			((System.ComponentModel.ISupportInitialize)(this.cultureInfoViewModelBindingSource)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label labelName;
		private System.Windows.Forms.BindingSource cultureInfoViewModelBindingSource;
		private System.Windows.Forms.Label labelNameValue;
		private System.Windows.Forms.Label labelNativeName;
		private System.Windows.Forms.Label labelNativeNameValue;
		private System.Windows.Forms.Label labelEnglishNameValue;
		private System.Windows.Forms.Label labelEnglishName;
		private System.Windows.Forms.Label labelCalendarTypeValue;
		private System.Windows.Forms.Label labelCalendarType;
		private System.Windows.Forms.Label calendarAlgTypeValue;
		private System.Windows.Forms.Label calendarAlgType;
		private System.Windows.Forms.Label labelMonthsInYearValue;
		private System.Windows.Forms.Label labelMonthsInYear;
		private System.Windows.Forms.Label labelDisplayNameValue;
		private System.Windows.Forms.Label labelDisplayName;
		private System.Windows.Forms.Label labelLCIDValue;
		private System.Windows.Forms.Label labelLCID;
		private System.Windows.Forms.Label labelDatePatternValue;
		private System.Windows.Forms.Label labelDatePattern;
		private System.Windows.Forms.Label labelNativeDigitsValue;
		private System.Windows.Forms.Label labelNativeDigits;
		private System.Windows.Forms.Label labelMonthNamesValue;
		private System.Windows.Forms.Label labelMonthNames;
	}
}
