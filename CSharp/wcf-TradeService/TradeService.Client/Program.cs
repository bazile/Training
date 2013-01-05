using System;
using Belhard.TradeService.Client.StockTradeServiceImplementation;

namespace Belhard.TradeService.Client
{
	internal class Program
	{
		private static void Main(string[] args)
		{
			var proxy = new StockTradeServiceClient();

			var msftQuote = new Quote {Ticker = "MSFT", Bid = 30.25M, Ask = 32.00M, Publisher = "PracticalWCF"};
			var ibmQuote = new Quote {Ticker = "IBM", Bid = 80.50M, Ask = 81.00M, Publisher = "PracticalWCF"};
			proxy.PublishQuote(msftQuote);
			proxy.PublishQuote(ibmQuote);

			Quote result = null;
			result = proxy.GetQuote("MSFT");
			Console.WriteLine("Ticker: {0} Ask: {1} Bid: {2}", result.Ticker, result.Ask, result.Bid);

			result = proxy.GetQuote("IBM");
			Console.WriteLine("Ticker: {0} Ask: {1} Bid: {2}", result.Ticker, result.Ask, result.Bid);

			result = null;
			try
			{
				result = proxy.GetQuote("ATT");
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
			}
			if (result == null)
			{
				Console.WriteLine("Ticker ATT not found!");
			}
		}
	}
}
