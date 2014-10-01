using System.Windows.Forms;

namespace BelhardTraining.Windows.Forms
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			FormWithElevateButton form = new FormWithElevateButton();
			form.ShowDialog();
		}
	}
}
