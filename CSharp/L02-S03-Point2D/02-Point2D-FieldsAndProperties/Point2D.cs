using System;

namespace TrainingCenter.PointDemo
{
	#region Пример с использованием полей

	#region Только координаты

	public class Point2D
	{
		/// <summary>
		/// Поля X и Y
		/// Модификатор доступа public открывает доступ внешнему коду к этим полям
		/// </summary>
		public int X, Y;

		public double CalculateDistance(Point2D other)
		{
			return Math.Sqrt((other.X - this.X) * (other.X - this.X) + (other.Y - this.Y) * (other.Y - this.Y));
		}

		public void PrintDistance(Point2D other)
		{
			Console.WriteLine("Расстояние между точками ({0},{1}) и ({2},{3}) = {4:F3}", X, Y, other.X, other.Y, CalculateDistance(other));
		}
	}

	#endregion

	#region Координаты и цвет

	//public class Point2D
	//{
	//    public int X, Y;
	//    public ConsoleColor Color = ConsoleColor.DarkGreen;

	//    public double CalculateDistance(Point2D other)
	//    {
	//        return Math.Sqrt((other.X - this.X) * (other.X - this.X) + (other.Y - this.Y) * (other.Y - this.Y));
	//    }

	//    public void PrintDistance(Point2D other)
	//    {
	//        Console.Write("Расстояние между точками ");
	//        PrintCoordinates(this);
	//        Console.Write(" и ");
	//        PrintCoordinates(other);
	//        Console.WriteLine(" = {0:F3}", CalculateDistance(other));
	//    }

	//    /// <summary>Печатает пару координат x и y заданным цветом</summary>
	//    /// <remarks>После завершения метода цвет консоли будет таким же как до её вызова</remarks>
	//    private static void PrintCoordinates(Point2D point)
	//    {
	//        ConsoleColor oldForegoundColor = Console.ForegroundColor;
	//        Console.ForegroundColor = point.Color;
	//        Console.Write("({0},{1})", point.X, point.Y);
	//        Console.ForegroundColor = oldForegoundColor;
	//    }
	//}

	#endregion

	#endregion

	#region Пример с использованием свойств

	///// <summary>Класс Point2D для хранения точки внутри квадрата на Декартовой плоскости</summary>
	//public class Point2D
	//{
	//    /// <summary>Координата вершин квадрата внутри которого должна находиться точка</summary>
	//    private const int maxCoord = 10;
		
	//    /// <summary>Поля для хранения координатами точки</summary>
	//    /// <remarks>
	//    /// 1. Используем private поля чтобы предотвратить неконтролируемый доступ извне класса
	//    /// 2. Обратите внимание что имена private членов принято записывать используя lowerCamelCase
	//    /// </remarks>
	//    private int x, y;

	//    /// <summary>Свойство для работы с координатами точки</summary>
	//    /// <remarks>Обратите внимание что имена public членов принято записывать используя UpperCamelCase</remarks>
	//    public int X
	//    {
	//        get { return x; }
	//        set
	//        {
	//            // Меняем значение поля x, только если желаемое значение координаты (value) находится в квадрате значений
	//            if (value >= -maxCoord && value <= maxCoord)
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
	//            // Меняем значение поля y, только если желаемое значение координаты (value) находится в квадрате значений
	//            if (value >= -maxCoord && value <= maxCoord)
	//            {
	//                y = value;
	//            }
	//        }
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
