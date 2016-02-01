using System;
using System.Globalization;
using System.Windows.Forms;
using Humanizer;

namespace AssemblyAsResourceDemo
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void OnLoad(object sender, EventArgs e)
		{
			listBoxMsg.Items.Add("Сообщения выводятся с помощью библиотеки Humanizer которая загружается из ресурсов приложения");
			listBoxMsg.Items.Add("-------------------------------------------------------------------------------------------");

			ClientSize = listBoxMsg.Size;

			listBoxMsg.Items.Add("Текущая культура ресурсов: " + CultureInfo.CurrentUICulture.Name);

			listBoxMsg.Items.Add("");

			listBoxMsg.Items.Add("1 (мужской род): " + 1.ToWords(GrammaticalGender.Masculine));
			listBoxMsg.Items.Add("1 (женский род): " + 1.ToWords(GrammaticalGender.Feminine));

			listBoxMsg.Items.Add("");

			int year = DateTime.Now.Year;
			listBoxMsg.Items.Add(year + " в римской системе исчисления: " + year.ToRoman());
			listBoxMsg.Items.Add(DateTime.UtcNow.AddDays(-3).Humanize());

			listBoxMsg.Items.Add("");
			listBoxMsg.Items.Add(5.Ordinalize());
		}
	}
}
