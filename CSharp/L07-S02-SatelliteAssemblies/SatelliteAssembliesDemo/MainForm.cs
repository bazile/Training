using System;
using System.Resources;
using System.Windows.Forms;

namespace SatelliteAssembliesDemo
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		private void OnMainFormLoad(object sender, EventArgs e)
		{
			var rm = new ResourceManager(typeof(SatelliteAssembliesDemo));
			textBoxMessage.Text = rm.GetString("MessageText"); 
		}
	}
}
