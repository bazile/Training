using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Belhard.TradeService
{
	[ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, IncludeExceptionDetailInFaults = true)]
	public class StockTradeService : IStockTradeService
	{
		private readonly Dictionary<string, Quote> _tickers = new Dictionary<string, Quote>();

		public Quote GetQuote(string ticker)
		{
			lock (_tickers)
			{
				Quote quote = _tickers[ticker];
				if (quote == null)
				{
					// Quote doesn't exist.
					throw new ArgumentOutOfRangeException(string.Format("No quotes found for ticker '{0}'", ticker));
				}
				return quote;
			}
		}

		public void PublishQuote(Quote quote)
		{
			lock (_tickers)
			{
				_tickers[quote.Ticker] = quote;
			}
		}
	}
}

