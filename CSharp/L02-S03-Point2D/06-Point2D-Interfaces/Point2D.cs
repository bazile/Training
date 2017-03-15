using System;

namespace TrainingCenter.PointDemo
{
	#region Пример с IComparable<Point2D>/IComparable

	//public class Point2D : IComparable<Point2D>, IComparable
	//{
	//    public int X { get; set; }
	//    public int Y { get; set; }
	//    public ConsoleColor Color { get; set; }

	//    public Point2D(int x, int y)
	//    {
	//        X = x;
	//        Y = y;
	//        Color = ConsoleColor.Green;
	//    }

	//    public Point2D(int x, int y, ConsoleColor color)
	//    {
	//        X = x;
	//        Y = y;
	//        Color = color;
	//    }

	//    public double CalculateDistance(Point2D other)
	//    {
	//        return Math.Sqrt((other.X - X) * (other.X - X) + (other.Y - Y) * (other.Y - Y));
	//    }

	//    public int CompareTo(Point2D other)
	//    {
	//        // При сравнении с null следует всегда возвращать положительное число
	//        if (other == null) return 1;

	//        if (ReferenceEquals(this, other)) return 0;

	//        int distance = (int)Math.Floor(CalculateDistance(other));
	//        if (distance != 0) return distance;

	//        return Color - other.Color;
	//    }

	//    public int CompareTo(object obj)
	//    {
	//        return CompareTo(obj as Point2D);
	//    }
	//}

	#endregion

	#region Пример с IFormattable, IComparable<Point2D>/IComparable

	public class Point2D : IComparable<Point2D>, IComparable, IFormattable
	{
		public int X { get; set; }
		public int Y { get; set; }
		public ConsoleColor Color { get; set; }

		public Point2D(int x, int y)
		{
			X = x;
			Y = y;
			Color = ConsoleColor.Green;
		}

		public Point2D(int x, int y, ConsoleColor color)
		{
			X = x;
			Y = y;
			Color = color;
		}

		public double CalculateDistance(Point2D other)
		{
			return Math.Sqrt((other.X - X) * (other.X - X) + (other.Y - Y) * (other.Y - Y));
		}

		public int CompareTo(Point2D other)
		{
			// При сравнении с null следует всегда возвращать положительное число
			if (other == null) return 1;

			if (ReferenceEquals(this, other)) return 0;

			int distance = (int)Math.Floor(CalculateDistance(other));
			if (distance != 0) return distance;

			return Color - other.Color;
		}

		public int CompareTo(object obj)
		{
			return CompareTo(obj as Point2D);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="format">
		/// Строка форматирования: R - в круглых скобках, S - в квадратных скобках, C - в фигурных скобках
		/// По умолчанию используется формат R
		/// </param>
		/// <param name="formatProvider"></param>
		/// <returns></returns>
		public string ToString(string format, IFormatProvider formatProvider)
		{
			format = format ?? "R";
			string openBrace, closeBrace;
			if (format.Equals("R", StringComparison.OrdinalIgnoreCase))
			{
				openBrace = "(";
				closeBrace = ")";
			}
			else if (format.Equals("S", StringComparison.OrdinalIgnoreCase))
			{
				openBrace = "[";
				closeBrace = "]";
			}
			else if (format.Equals("C", StringComparison.OrdinalIgnoreCase))
			{
				openBrace = "{";
				closeBrace = "}";
			}
			else
			{
				throw new FormatException("Unsupported format " + format);
			}

			return String.Format(formatProvider, "{0}{2:N}, {3:N}{1}", openBrace, closeBrace, X, Y);
		}
	}

	#endregion

}
