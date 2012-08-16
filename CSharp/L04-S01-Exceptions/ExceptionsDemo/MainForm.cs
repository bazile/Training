using System;
using System.Windows.Forms;

namespace ExceptionsDemo
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void OnButtonCalculateClick(object sender, System.EventArgs e)
		{
			int x, y;

			// Пробуем получить значение X
			try
			{
				x = Int32.Parse(textBoxX.Text);
			}
			catch (FormatException) { return; }
			catch (OverflowException) { return; }

			// Пробуем получить значение Y
			try
			{
				y = Int32.Parse(textBoxY.Text);
			}
			catch (FormatException) { return; }
			catch (OverflowException) { return; }

			// Пробуем выполнить деление X на Y
			string result = "\u221E";
			try
			{
				int z = x/y;
				result = String.Format("{0:F2}", z);
			}
			catch (DivideByZeroException)
			{
				
			}
			finally
			{
				labelResult.Text = result;
			}
		}
	}
}
