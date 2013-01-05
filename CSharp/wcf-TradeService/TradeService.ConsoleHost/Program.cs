using System;
using System.ServiceModel;

namespace Belhard.TradeService.ConsoleHost
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			Type serviceType = typeof(StockTradeService);
			var host = new ServiceHost(serviceType);
			host.Open();

			Console.WriteLine("Service started");
			Console.WriteLine("Listening at:");
			foreach (var addr in host.BaseAddresses)
			{
				Console.WriteLine("\t@ {0}", addr.AbsoluteUri);
			}
			Console.WriteLine("Press Return to exit");

			Console.ReadLine();
		}
	}
}

