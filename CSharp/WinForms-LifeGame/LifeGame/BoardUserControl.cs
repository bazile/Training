using System.Drawing;
using System.Windows.Forms;

namespace LifeGame
{
	public partial class BoardUserControl : UserControl
	{
		public BoardUserControl()
		{
			InitializeComponent();
		}

		private void OnPaint(object sender, PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			g.Clear(BackColor);

			var blackPen = new Pen(Color.Black, 1);
			const int stepX = 10;
			const int stepY = 10;
			//g.DrawLine(blackPen, new Point(r.Left, r.Top), new Point(r.Right, r.Bottom));

			int rows = e.ClipRectangle.Height/stepY;
			int columns = e.ClipRectangle.Width/stepX;

			int left = e.ClipRectangle.Width - stepX * (e.ClipRectangle.Width / stepX);
			int top = e.ClipRectangle.Height - stepY * (e.ClipRectangle.Height / stepY);
			var r = new Rectangle(left, top, columns*stepX, rows*stepY);

			var point1 = new Point(r.Left, r.Top);
			var point2 = new Point(r.Right, r.Top);
			for (int i=0; i<=rows; i++)
			{
				g.DrawLine(blackPen, point1, point2);
				point1.Y += stepY;
				point2.Y += stepY;
			}

			point1 = new Point(r.Left, r.Top);
			point2 = new Point(r.Left, r.Bottom);
			for (int i=0; i<=columns; i++)
			{
				g.DrawLine(blackPen, point1, point2);
				point1.X += stepX;
				point2.X += stepX;
			}
		}
	}
}
