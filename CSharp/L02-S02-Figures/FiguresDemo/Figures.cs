/*
 * Демонстрация наследования, абстрактных классов, виртуальных и невиртуальных методов.
 * Также демонстрируется использование класса System.Diagnostics.Debug
*/

using System;
using System.Diagnostics;
using System.Drawing;

namespace FiguresDemo
{
    public abstract class Figure
    {
	    public abstract double GetArea();

		public string WhoAmI()
		{
			return "Figure";
		}
    }

	public class Square : Figure
	{
		public Point TopLeft { get; private set; }
		public double Size { get; private set; }

		public Square(Point topLeft, double size)
		{
			TopLeft = topLeft;
			Size = size;
		}

		public override double GetArea()
		{
			Debug.WriteLine("Square.GetArea()");
			return Size*Size;
		}

		public new string WhoAmI()
		{
			return "Square";
		}
	}

	public class Ellipse : Figure
	{
		public Point Center { get; private set; }
		public double MajorRadius { get; private set; }
		public double MinorRadius { get; private set; }

		public Ellipse(Point center, double majorRadius, double minorRadius)
		{
			Center = center;
			MajorRadius = majorRadius;
			MinorRadius = minorRadius;
		}

		public override double GetArea()
		{
			Debug.WriteLine("Ellipse.GetArea()");
			return Math.PI*MajorRadius*MinorRadius;
		}

		public new string WhoAmI()
		{
			return "Ellipse";
		}
	}

	public class Circle : Ellipse
	{
		public double Radius
		{
			get { return MajorRadius; }
		}

		public Circle(Point center, double radius)
			: base(center, radius, radius)
		{
		}

		//public override double GetArea()
		//{
		//	Debug.WriteLine("Circle.GetArea()");
		//	return Math.PI*Radius*Radius;
		//}

		public new string WhoAmI()
		{
			return "Circle";
		}
	}
}
