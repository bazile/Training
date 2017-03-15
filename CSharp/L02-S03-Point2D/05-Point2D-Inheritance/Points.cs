using System;
using System.Runtime.CompilerServices;

namespace TrainingCenter.PointDemo
{
	public class Point2D
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Point2D(int x, int y)
		{
			X = x;
			Y = y;
		}

		public double CalculateDistance(Point2D other)
		{
			return Math.Sqrt(Square(other.X - X) + Square(other.Y - Y));
		}

		//[MethodImpl(MethodImplOptions.AggressiveInlining)] // AggressiveInlining поддерживается в .NET 4.5 и выше
		protected static double Square(double num)
		{
			return num*num;
		}
	}

	public class Point3D : Point2D
	{
		public int Z { get; set; }

		public Point3D(int x, int y, int z) : base(x, y)
		{
			Z = z;
		}

		//public double CalculateDistance(Point2D other)
		//{
		//}

		public double CalculateDistance(Point3D other)
		{
			return Math.Sqrt(Square(other.X - X) + Square(other.Y - Y) + Square(other.Z - Z));
		}
	}
}
