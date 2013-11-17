using System;

namespace BelhardTraining.PointDemo
{
	class Program
	{
		static void Main()
		{
			Point2D p1 = new Point2D(10,7);
			Point3D p2 = new Point3D(10, 7, -5);
			Point3D p3 = new Point3D(10, 7, 5);

			// Переменная p1 имеет тип Point2D, p2 - Point3D
			// Функция CalculateDistance из класса Point2D принимает аргумент типа Point2D
			// Т.к. класс Point3D является наследником Point3D, то этот вызов является допустимым
			// Фактически мы вычисляем растояние между двумя Point2D игнорируя координату Z
			Console.WriteLine(p1.CalculateDistance(p2)); // Результат - 0

			// Аналогично первому вызову
			Console.WriteLine(p2.CalculateDistance(p1)); // Результат - 0

			// Обе переменные имеют тип Point3D
			// Вызывается функция CalculateDistance класса Point3D
			Console.WriteLine(p2.CalculateDistance(p3)); // Результат - 10
		}
	}
}
