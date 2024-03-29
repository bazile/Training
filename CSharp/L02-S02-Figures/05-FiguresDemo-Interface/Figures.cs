﻿/*
 * Демонстрация наследования, объявления и реализации интерфейса
*/

using System;

namespace TrainingCenter.FiguresDemo
{
	// Мы можем использовать интерфейс вместо абстрактного базового класса
	// Однако при этом нам нужно не забывать объявлять методы как virtual в классах реализующих наш интерфейс
	public interface IFigure
	{
		double ComputeArea();
		string WhoAmI();
	}

	public class Rectangle : IFigure
	{
		public double Width { get; private set; }
		public double Height { get; private set; }

		public Rectangle(double width, double height)
		{
			Width = width;
			Height = height;
		}

		public virtual double ComputeArea()
		{
			return Width * Height;
		}

		public virtual string WhoAmI()
		{
			return "Rectangle";
		}
	}

	public class Square : Rectangle
	{
		public Square(double size)
			: base(size, size)
		{
		}

		public override string WhoAmI()
		{
			return "Square";
		}
	}

	public class Ellipse : IFigure
	{
		public double MajorRadius { get; private set; }
		public double MinorRadius { get; private set; }

		public Ellipse(double majorRadius, double minorRadius)
		{
			MajorRadius = majorRadius;
			MinorRadius = minorRadius;
		}

		public virtual double ComputeArea()
		{
			return Math.PI * MajorRadius * MinorRadius;
		}

		public virtual string WhoAmI()
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

		public Circle(double radius)
			: base(radius, radius)
		{
		}

		public override string WhoAmI()
		{
			return "Circle";
		}
	}

	/// <summary>
	/// Правильный треугольник. Все стороны равны.
	/// </summary>
	public class Triangle : IFigure
	{
		public double SideLength { get; private set; }

		public Triangle(double sideLength)
		{
			SideLength = sideLength;
		}

		public virtual double ComputeArea()
		{
			return SideLength * SideLength * Math.Sqrt(3) / 4f;
		}

		public virtual string WhoAmI()
		{
			return "Triangle";
		}
	}
}
