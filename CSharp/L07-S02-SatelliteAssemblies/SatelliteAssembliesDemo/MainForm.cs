using System;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;

namespace SatelliteAssembliesDemo
{
	// TODO: список цитат на разных языках с выбором случайной
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
			pictureBox.Image = (Image)rm.GetObject("Flag");
		}
	}
}
