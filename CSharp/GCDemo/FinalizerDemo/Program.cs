using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace BelhardTraining.FinalizerDemo
{
	class Something
	{
		IntPtr hMem;

		public Something()
		{
			const int allocSize = 7*1024*1024;
			hMem = Marshal.AllocHGlobal(allocSize);
			GC.AddMemoryPressure(allocSize);
		}

		~Something()
		{
			Marshal.FreeHGlobal(hMem);
		}

		/// <summary>Симуляция полезной работы</summary>
		public void DoSomething()
		{
			Marshal.WriteByte(hMem, 10, 0xAE);
		}
	}

	class Program
	{
		static void Main()
		{
			Process proc = Process.GetCurrentProcess();
			long initialMemory = proc.PrivateMemorySize64;
			Console.WriteLine(initialMemory.ToString("N0"));
			long threshold = initialMemory*100;
			for (;;)
			{
				for (int i = 0; i < 100; i++)
				{
					var smth = new Something();
					smth.DoSomething();
					Console.Write("+");
					//Thread.Sleep(20);
				}

				Console.Write(" ");

				proc.Refresh();
				long currentMemory = proc.PrivateMemorySize64;
				Console.Write("{0:N0} ", currentMemory);
				if (currentMemory > initialMemory && currentMemory - initialMemory > threshold)
				{
					GC.Collect();
					GC.WaitForPendingFinalizers();
					GC.Collect();
					Console.Write("!");
				}
				Console.WriteLine();
				Thread.Sleep(500);
			}
		}
	}
}
