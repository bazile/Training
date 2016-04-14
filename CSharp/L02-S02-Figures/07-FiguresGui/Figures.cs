/*
 * Демонстрация наследования, абстрактных классов, виртуальных и абстрактных методов.
*/

using System;
using System.Drawing;

namespace BelhardTraining.FiguresDemo
{
	/// <summary>Неопределенная геометрическая фигура</summary>
	/// <remarks>В C# запрещено создавать экземпляры абстрактных классов</remarks>
	public abstract class Figure
	{
		public Color Color { get; protected set; }

		public abstract void Draw(Graphics g);
	}

	public struct Point2D
	{
		private int x, y;

		public int X { get { return x; } }
		public int Y { get { return y; } }

		public Point2D(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
	}	  

	public class Rectangle : Figure
	{
		public Point2D TopLeft { get; private set; }
		public int Width { get; private set; }
		public int Height { get; private set; }

		public Rectangle(Color color, Point2D topLeft, int width, int height)
		{
			Color = color;
			TopLeft = topLeft;
			Width = width;
			Height = height;
		}

		public override void Draw(Graphics g)
		{
			g.DrawRectangle(new Pen(Color), TopLeft.X, TopLeft.Y, Width, Height);
		}
	}

	//public class Square : Rectangle
	//{
	//	public Square(double size)
	//		: base(size, size)
	//	{
	//	}

	//	public override string WhoAmI()
	//	{
	//		return "Square";
	//	}
	//}

	public class Ellipse : Figure
	{
		public Point2D Center { get; private set; }
		public double MajorRadius { get; private set; }
		public double MinorRadius { get; private set; }

		public Ellipse(Color color, Point2D center, double majorRadius, double minorRadius)
		{
			MajorRadius = majorRadius;
			MinorRadius = minorRadius;
		}

		public override void Draw(Graphics g)
		{
			//g.DrawEllipse(new Pen(Color), 
		}
	}

	//public class Circle : Ellipse
	//{
	//	public double Radius
	//	{
	//		get { return MajorRadius; }
	//	}

	//	public Circle(double radius)
	//		: base(radius, radius)
	//	{
	//	}

	//	public override string WhoAmI()
	//	{
	//		return "Circle";
	//	}
	//}

	///// <summary>
	///// Правильный треугольник. Все стороны равны.
	///// </summary>
	//public class EquilateralTriangle : Figure
	//{
	//	public double SideLength { get; private set; }

	//	public EquilateralTriangle(double sideLength)
	//	{
	//		SideLength = sideLength;
	//	}

	//	public override double ComputeArea()
	//	{
	//		return SideLength * SideLength * Math.Sqrt(3) / 4f;
	//	}

	//	public override string WhoAmI()
	//	{
	//		return "EquilateralTriangle";
	//	}
	//}
}
