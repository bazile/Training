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

			// Заполняем вектор случайными числами от 70 до 450
			System.Random random = new System.Random();
			for (int i=0; i<vectorLength; i++)
			{
				v[i] = random.Next(70, 450);
			}

			System.Console.WriteLine("Length of vector = {0}", v.Length);
			System.Console.WriteLine("Sum of vector = {0}", v.GetSum());
		}
	}
}
