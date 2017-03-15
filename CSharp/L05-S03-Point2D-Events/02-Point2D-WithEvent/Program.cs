using System;

namespace TrainingCenter
{
	class Program
	{
		static void Main()
		{
			Point2D p1 = new Point2D();
			p1.ColorIsChanging += new ColorChange(ColorIsChanging);
			p1.Color = ConsoleColor.Blue;
			p1.Color = ConsoleColor.Magenta;

			Console.WriteLine();

			Point2D p2 = new Point2D();
			p2.ColorIsChanging += ColorIsChanging;
			p2.Color = ConsoleColor.Green;
			p2.Color = ConsoleColor.Yellow;

		}

		static void ColorIsChanging(ConsoleColor oldColor, ConsoleColor newColor)
		{
			Console.WriteLine("Старый цвет: {0}. Новый цвет {1}", oldColor, newColor);
		}
	}

	// Делегат который используется для объявления события изменения цвета
	// Делегаты можно объявлять как на уровне пространства имен так и на уровне класса
	// Объявление на уровне пространства имен встречается чаще всего т.к. делегат нужен и за пределами класса
	delegate void ColorChange(ConsoleColor oldColor, ConsoleColor newColor);

	class Point2D
	{
		public event ColorChange ColorIsChanging;

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
					// Генерируем событие ColorIsChanging
					// Перед этим убеждаемся что у события есть хотя бы один подписчик
					if (ColorIsChanging != null)
					{
						ColorIsChanging(_color, value);
					}

					_color = value;
				}
			}
		}
	}
}
