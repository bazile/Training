using System;

namespace BelhardTraining.FiguresDemo
{
	public static class Program
	{
		public static void Main()
		{
			Figure[] figures = new Figure[]
				{
					new Figure(),
					new Rectangle(3,4),
					new Square(3),
					new Ellipse(2.5, 1.9),
					new Ellipse(3.1, 3.1),
					new Circle(3.1),
				};
			foreach (Figure figure in figures)
			{
				PrintFigure(figure.WhoAmI(), figure.GetType().Name, figure.ComputeArea());

				#region Неправильная попытка исправить с помощью проверки типа
				
				//// Это анти-пример
				//// НИКОГДА НЕ ПИШИТЕ ТАКОЙ КОД!

				//if (figure is Ellipse)
				//{
				//    Ellipse e = (Ellipse)figure;
				//    PrintFigure(e.WhoAmI(), e.GetType().Name, e.ComputeArea());
				//}
				//else if (figure is Circle)
				//{
				//    Circle c = (Circle)figure;
				//    PrintFigure(c.WhoAmI(), c.GetType().Name, c.ComputeArea());
				//}
				//else if (figure is Square)
				//{
				//    Square sq = (Square)figure;
				//    PrintFigure(sq.WhoAmI(), sq.GetType().Name, sq.ComputeArea());
				//}
				//else if (figure is Rectangle)
				//{
				//    Rectangle rec = (Rectangle)figure;
				//    PrintFigure(rec.WhoAmI(), rec.GetType().Name, rec.ComputeArea());
				//}

				#endregion
			}
		}

		private static void PrintFigure(string whoAmI, string typeName, double area)
		{
			ConsoleColor oldColor = Console.ForegroundColor;
			if (whoAmI != typeName) Console.ForegroundColor = ConsoleColor.Red;

			Console.WriteLine(
				"Who Am I = {0}. Type name is {1}. Area={2:F2}",
				whoAmI,
				typeName,
				area
			);

			Console.ForegroundColor = oldColor;
		}
	}
}
