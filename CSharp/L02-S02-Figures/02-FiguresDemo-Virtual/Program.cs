﻿using System;

namespace BelhardTraining.FiguresDemo
{
	class Program
	{
		static void Main()
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