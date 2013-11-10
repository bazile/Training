using System;
using System.Globalization;
using System.Threading;

namespace BelhardTraining.PointDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			Point2D p1 = new Point2D(-1, -2);
			Console.WriteLine("{0}", p1);
			Console.WriteLine("{0:R}", p1);
			Console.WriteLine("{0:S}", p1);
			Console.WriteLine("{0:C}", p1);
			Console.WriteLine();
			
			Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
			Console.WriteLine("en-US");

			Console.WriteLine("{0}", p1);
			Console.WriteLine("{0:R}", p1);
			Console.WriteLine("{0:S}", p1);
			Console.WriteLine("{0:C}", p1);
			//Console.WriteLine("{0:X}", p1);
		}
	}
}
