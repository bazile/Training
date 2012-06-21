using System;
using System.Drawing;
using System.Windows.Forms;

namespace HelloWorld.WinForms
{
	public partial class HelloWorldForm : Form
	{
		public HelloWorldForm()
		{
			InitializeComponent();
		}

		private void OnButtonHelloClick(object sender, EventArgs e)
		{
			Button helloButton = (Button)sender;
			helloButton.ForeColor = Color.Red;
		}
	}
}
