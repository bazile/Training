using System;
using System.Threading;

namespace ThreadsDemo.ConsoleMessages
{
	class Program
	{
		static void Main()
		{
			var printMsgThread = new Thread(new ThreadStart(PrintMessage));
            //printMsgThread.IsBackground = true;
			printMsgThread.Start();

            //var printThreadWithParam = new Thread(new ParameterizedThreadStart(PrintMessage));
            ////printThreadWithParam.IsBackground = true;
            //printThreadWithParam.Start("I'm parameterized thread!");

            //var printThreadWithComplexParam = new Thread(new ParameterizedThreadStart(PrintComplexMessage));
            ////printThreadWithComplexParam.IsBackground = true;
            //printThreadWithComplexParam.Start(new PrintMessageData { Message = "I'm super-parameterized thread!", When = DateTime.Now });

			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0}] I'm main thread!", i);
			}

			// Ожидаем завершения потоков
			printMsgThread.Join();
			//printThreadWithParam.Join();
		}

		private static void PrintMessage()
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0}] I'm background thread!", i);
			}
		}

		private static void PrintMessage(object text)
		{
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0}] {1}", i, text);
			}
		}

		private static void PrintComplexMessage(object obj)
		{
            var data = (PrintMessageData)obj;
			for (int i = 0; i < 100; i++)
			{
				Console.WriteLine("[{0}] {1:g} - {2}", i, data.When, data.Message);
			}
		}

		private class PrintMessageData
		{
			public string Message;
			public DateTime When;
		}
	}
}
