using System;
using System.Windows.Forms;

namespace BelhardTraining.FiguresDemo
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		Figure[] figures;

		private void Form1_Load(object sender, EventArgs e)
		{
			figures = FiguresGenerator.GetRandomFigures(ClientRectangle);
		}
	
		private void Form1_Paint(object sender, PaintEventArgs e)
		{
			foreach (Figure figure in figures)
			{
				figure.Draw(e.Graphics);
			}
		}
	}
}
