using System.Drawing;
using System.Windows.Forms;

namespace LifeGame
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			//var l = new LifeBoard();
			//l.Seed();
			//l.Tick();
		}

		private void OnPanelBoardPaint(object sender, PaintEventArgs e)
		{
		}

		private void OnExitMenuItemClick(object sender, System.EventArgs e)
		{
			Close();
		}
	}
}
