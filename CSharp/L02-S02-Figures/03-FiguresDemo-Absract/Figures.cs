/*
 * Демонстрация наследования, абстрактных классов, виртуальных и абстрактных методов.
*/

using System;

namespace BelhardTraining.FiguresDemo
{
    /// <summary>Неопределенная геометрическая фигура</summary>
    /// <remarks>В C# запрещено создавать экземпляры абстрактных классов</remarks>
    public abstract class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }

        public abstract double ComputeArea();
        public abstract string WhoAmI();
    }

    public class Rectangle : Figure
    {
        public double Width { get; private set; }
        public double Height { get; private set; }

        public Rectangle(double width, double height)
        {
            Width = width;
            Height = height;
        }

        public override double ComputeArea()
        {
            return Width * Height;
        }

        public override string WhoAmI()
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

    public class Ellipse : Figure
    {
        public double MajorRadius { get; private set; }
        public double MinorRadius { get; private set; }

        public Ellipse(double majorRadius, double minorRadius)
        {
            MajorRadius = majorRadius;
            MinorRadius = minorRadius;
        }

        public override double ComputeArea()
        {
            return Math.PI * MajorRadius * MinorRadius;
        }

        public override string WhoAmI()
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
    public class Triangle : Figure
    {
        public double SideLength { get; private set; }

        public Triangle(double sideLength)
        {
            SideLength = sideLength;
        }

        public override double ComputeArea()
        {
            return SideLength * SideLength * Math.Sqrt(3) / 4f;
        }

        public override string WhoAmI()
        {
            return "Triangle";
        }
    }
}
