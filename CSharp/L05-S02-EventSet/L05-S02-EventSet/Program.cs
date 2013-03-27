using System;

/*
 * Данный пример взят из книги Джефри Рихтера "CLR via C#"
*/

namespace BelhardTraining.EventSetDemo
{
	class Program
	{
		static void Main(string[] args)
		{
			TypeWithLotsOfEvents twle = new TypeWithLotsOfEvents();

			// Подписка на событие
			twle.Foo += HandleFooEvent;

			// Проверка что событие работает
			twle.SimulateFoo();
		}

		private static void HandleFooEvent(object sender, FooEventArgs e)
		{
			Console.WriteLine("Handling Foo Event here...");
		}
	}
}
