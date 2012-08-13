//using System;

namespace MyVector
{
	class Program
	{
		static void Main(string[] args)
		{
			const int vectorLength = 15;

			Vector v = new Vector(vectorLength);
			//var v = new Vector(10);

			// Заполняем вектор случайными числами от 1 до 999
			System.Random random = new System.Random();
			for (int i=0; i<vectorLength; i++)
			{
				v[i] = random.Next(1, 999);
			}

			System.Console.WriteLine("Length of vector = {0}", v.Length);
			System.Console.WriteLine("Sum of vector = {0}", v.GetSum());

			foreach (int item in v)
			{
				System.Console.WriteLine("{0:000}", item);
			}
		}
	}
}
