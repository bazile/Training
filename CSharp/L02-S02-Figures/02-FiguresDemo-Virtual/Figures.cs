/*
 * Демонстрация наследования и виртуальных методов.
 * Также демонстрируется использование класса System.Diagnostics.Debug
*/

using System;
using System.Diagnostics;

namespace BelhardTraining.FiguresDemo
{
    /// <summary>Неопределенная геометрическая фигура</summary>
    public class Figure
    {
        public int X { get; set; }
        public int Y { get; set; }

        public virtual double ComputeArea()
        {
            Debug.WriteLine("Figure.ComputeArea()");

            // Возвращаем значение Not-A-Number чтобы показать вызывающему
            //      коду что эта фигура не имеет площади
            return double.NaN;
        }

        public virtual string WhoAmI()
        {
            Debug.WriteLine("Figure.WhoAmI()");
            return "Figure";

            // Вместо возврата значения можно было бы сгенерировать
            //      исключение NotImplementedException чтобы вызывающий
            //      код знал что этот метод вызывать не следует
            // К сожалению узнаем мы об этом только на этапе исполнения 
            //throw new NotImplementedException();
        }
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
    public class EquilateralTriangle : Figure
    {
        public double SideLength { get; private set; }

        public EquilateralTriangle(double sideLength)
        {
            SideLength = sideLength;
        }

        public override double ComputeArea()
        {
            return SideLength * SideLength * Math.Sqrt(3) / 4f;
        }

        public override string WhoAmI()
        {
            return "EquilateralTriangle";
        }
    }
}
