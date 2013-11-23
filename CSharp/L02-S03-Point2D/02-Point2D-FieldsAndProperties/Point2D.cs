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
	//    private int x, y;
	//    private ConsoleColor color;

	//    public int X
	//    {
	//        get { return x; }
	//        set { x = value; }
	//    }

	//    public int Y
	//    {
	//        get { return y; }
	//        set { y = value; }
	//    }

	//    public ConsoleColor Color
	//    {
	//        get { return color; }
	//        set { color = value; }
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

    #region Пример с использованием авто-свойств (auto properties)

    //public class Point2D
    //{
    //    public int X { get; set; }
    //    public int Y { get; set; }
    //    public ConsoleColor Color { get; set; }

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
	//    private int x, y;
	//    private ConsoleColor color;

	//    public int X
	//    {
	//        get { return x; }
	//        set
	//        {
	//            if (value >= 0)
	//            {
	//                x = value;
	//            }
	//        }
	//    }

	//    public int Y
	//    {
	//        get { return y; }
	//        set
	//        {
	//            if (value >= 0)
	//            {
	//                y = value;
	//            }
	//        }
	//    }

	//    public ConsoleColor Color
	//    {
	//        get { return color; }
	//        set { color = value; }
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
