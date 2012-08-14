using System;
using System.Drawing;

namespace FiguresDemo
{
    public abstract class Figure
    {
	    public abstract double GetArea();
    }

	public class Square : Figure
	{
		private Point _topLeft;
		private double _size;

		public Square(Point topLeft, double size)
		{
			_topLeft = topLeft;
			_size = size;
		}

		public override double GetArea()
		{
			return _size*_size;
		}
	}

	public class Circle : Figure
	{
		private Point _center;
		private double _radius;

		public Circle(Point center, double radius)
		{
			_center = center;
			_radius = radius;
		}

		public override double GetArea()
		{
			return Math.PI*_radius*_radius;
		}
	}
}
