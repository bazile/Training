using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;

namespace TrainingCenter.PointDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			// Пример сортировки.
			// Класс List<T> способен отсортировать экземпляры Point2D благодаря наличиб реализации IComparable
			List<Point2D> points = new List<Point2D>();
			points.Add(new Point2D(5, 5));
			points.Add(new Point2D(2, 2));
			points.Add(new Point2D(4, 4));
			points.Add(new Point2D(1, 1));
			points.Add(new Point2D(3, 3));

			Console.WriteLine("До сортировки:");
			foreach (Point2D point in points)
			{
				Console.WriteLine("({0}, {1})", point.X, point.Y);
			}
			
			points.Sort();
			Console.WriteLine("После сортировки:");
			foreach (Point2D point in points)
			{
				Console.WriteLine("({0}, {1})", point.X, point.Y);
			}

			Console.WriteLine("--------------");
			Console.WriteLine("Пример форматированного вывода");

			// Форматированный вывод используя собственную реализацию IFormattable
			Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name);
			Point2D p1 = new Point2D(-1, -2);
			Console.WriteLine("{0}", p1);
			Console.WriteLine("{0:R}", p1);
			Console.WriteLine("{0:S}", p1);
			Console.WriteLine("{0:C}", p1);
			Console.WriteLine();
			
			// На форматированный вывод влияет текущая культура
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-NZ");
			Console.WriteLine(Thread.CurrentThread.CurrentCulture.Name);

			Console.WriteLine("{0}", p1);
			Console.WriteLine("{0:R}", p1);
			Console.WriteLine("{0:S}", p1);
			Console.WriteLine("{0:C}", p1);
			//Console.WriteLine("{0:X}", p1);
		}
	}
}
