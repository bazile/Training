using System;

namespace TrainingCenter.PointDemo
{
	class Program
	{
		static void Main()
		{
			Point2D point1 = new Point2D();
			point1.X = 10; point1.Y = -2;
			//point1.Color = ConsoleColor.Red;

			Point2D point2 = new Point2D();
			point2.X = 5; point2.Y = 1;
			//point2.Color = ConsoleColor.Yellow;

			Point2D point3 = new Point2D();
			point3.X = -2; point3.Y = 7;
			//point3.Color = ConsoleColor.Cyan;

			point1.PrintDistance(point2);
			point2.PrintDistance(point3);
			point3.PrintDistance(point1);
		}
	}
}
