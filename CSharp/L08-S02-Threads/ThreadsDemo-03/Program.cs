using System;

namespace ThreadsDemo.Queue
{
	class Program
	{
		static void Main()
		{
			Console.WriteLine("Вводите строки.");
			Console.WriteLine("Для завершения работы введите пустую строку.");
			Console.WriteLine();

			var actionQueue = new ActionQueue<string>(PrintMessage);
			for (;;)
			{
				string line = Console.ReadLine();
				if (String.IsNullOrEmpty(line)) break;

				foreach (char ch in line)
				{
					actionQueue.EnqueueElement(ch.ToString());
				}
			}
		}

		private static void PrintMessage(string message)
		{
			Console.WriteLine("Message received: {0}", message);
		}
	}
}
