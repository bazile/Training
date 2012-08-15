using System;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Threading;

namespace FiguresDemo
{
	public static class Program
	{
		public static void Main()
		{
			//Thread.CurrentThread.CurrentCulture = new CultureInfo("ru-RU");
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");

			Figure[] figures = new Figure[]
				{
					new Square(new Point(9,3), 1), 
					new Ellipse(new Point(5,2), 2.5, 1.9),
					new Ellipse(new Point(1,1), 3.1, 3.1),
					new Circle(new Point(1,1), 3.1),
				};
			foreach (var figure in figures)
			{
				Debug.WriteLine(figure.WhoAmI());
				Console.WriteLine("Who Am I = {2}. Type is {0}. Area={1:F2}", figure.GetType(), figure.GetArea(), figure.WhoAmI());
			}
		}
	}
}
