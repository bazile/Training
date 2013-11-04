using System;

namespace BelhardTraining.PointDemo
{
    #region Пример с использованием полей

    public class Point2D
    {
        public int X, Y;
        public ConsoleColor Color;

        public double CalculateDistance(Point2D other)
        {
            return Math.Sqrt((other.X - X) * (other.X - X) + (other.Y - Y) * (other.Y - Y));
        }

        public void PrintDistance(Point2D other)
        {
            Console.WriteLine("Расстояние между точками ({0},{1}) и ({2},{3}) = {4:F3}", X, Y, other.X, other.Y, CalculateDistance(other));
        }
    }

    #endregion

    #region Пример с использованием свойств

    //public class Point2D
    //{
    //    private int _x, _y;
    //    private ConsoleColor _color;

    //    public int X
    //    {
    //        get { return _x; }
    //        set { _x = value; }
    //    }

    //    public int Y
    //    {
    //        get { return _y; }
    //        set { _y = value; }
    //    }

    //    public ConsoleColor Color
    //    {
    //        get { return _color; }
    //        set { _color = value; }
    //    }

    //    public double CalculateDistance(Point2D other)
    //    {
    //        return Math.Sqrt((other.X - X) * (other.X - X) + (other.Y - Y) * (other.Y - Y));
    //    }

    //    public void PrintDistance(Point2D other)
    //    {
    //        Console.WriteLine("Расстояние между точками ({0},{1}) и ({2},{3}) = {4:F3}", X, Y, other.X, other.Y, CalculateDistance(other));
    //    }
    //}

    #endregion

    #region Пример с использованием свойств. Проверка значений.

    ///// <summary>
    ///// В данной реализации свойствам X и Y можно присвоить только положительные или нулевые координаты
    ///// </summary>
    //public class Point2D
    //{
    //    private int _x, _y;
    //    private ConsoleColor _color;

    //    public int X
    //    {
    //        get { return _x; }
    //        set
    //        {
    //            if (value >= 0)
    //            {
    //                _x = value;
    //            }
    //        }
    //    }

    //    public int Y
    //    {
    //        get { return _y; }
    //        set
    //        {
    //            if (value >= 0)
    //            {
    //                _y = value;
    //            }
    //        }
    //    }

    //    public ConsoleColor Color
    //    {
    //        get { return _color; }
    //        set { _color = value; }
    //    }

    //    public double CalculateDistance(Point2D other)
    //    {
    //        return Math.Sqrt((other.X - X) * (other.X - X) + (other.Y - Y) * (other.Y - Y));
    //    }

    //    public void PrintDistance(Point2D other)
    //    {
    //        Console.WriteLine("Расстояние между точками ({0},{1}) и ({2},{3}) = {4:F3}", X, Y, other.X, other.Y, CalculateDistance(other));
    //    }
    //}

    #endregion

}
