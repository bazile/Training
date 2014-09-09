using System;

namespace BelhardTraining.PointDemo
{
	/// <summary>Структура Point2D</summary>
	/// <remarks>
	/// Выбор структуры для Point2D может оказаться более оправданным
	///		чем класс из-за небольшого размера - 12 байт = 4 + 4 + 4
	///		и из-за его простоты
	/// 
	/// Структуры отличаются от классов:
	///  * Структуры не могут наследоваться от другой структуры,
	///		поэтому не разрешено использовать protected члены
	///  * В структуре нельзя объявить конструктор без аргументов
	///  * В структуре нельзя инициализировать поля при объявлении
	/// </remarks>
	struct Point2D
	{
		public int X, Y;
		public ConsoleColor Color;

		public double CalculateDistance(Point2D other)
		{
			return Math.Sqrt((other.X - this.X) * (other.X - this.X) + (other.Y - this.Y) * (other.Y - this.Y));
		}

		public void PrintDistance(Point2D other)
		{
			Console.Write("Расстояние между точками ");
			PrintCoordinates(this);
			Console.Write(" и ");
			PrintCoordinates(other);
			Console.WriteLine(" = {0:F3}", CalculateDistance(other));
		}

		/// <summary>Печатает пару координат x и y заданным цветом</summary>
		/// <remarks>После завершения метода цвет консоли будет таким же как до её вызова</remarks>
		private static void PrintCoordinates(Point2D point)
		{
			ConsoleColor oldForegoundColor = Console.ForegroundColor;
			Console.ForegroundColor = point.Color;
			Console.Write("({0},{1})", point.X, point.Y);
			Console.ForegroundColor = oldForegoundColor;
		}
	}
}
