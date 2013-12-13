using System;

namespace BelhardTraining
{
	class Program
	{
		static void Main()
		{
			Point2D p1 = new Point2D();
			p1.Color = ConsoleColor.Blue;
			p1.Color = ConsoleColor.Magenta;

			Console.WriteLine();

			Point2D p2 = new Point2D();
			p2.Color = ConsoleColor.Green;
			p2.Color = ConsoleColor.Yellow;
		}
	}

	class Point2D
	{
		private ConsoleColor _color;

		public double X { get; set; }
		public double Y { get; set; }

		public ConsoleColor Color
		{
			get { return _color; }
			set
			{
				if (_color != value)
				{
					ColorIsChanging(_color, value);
					_color = value;
				}
			}
		}

		private void ColorIsChanging(ConsoleColor oldColor, ConsoleColor newColor)
		{
			Console.WriteLine("Старый цвет: {0}. Новый цвет {1}", oldColor, newColor);
		}
	}
}
