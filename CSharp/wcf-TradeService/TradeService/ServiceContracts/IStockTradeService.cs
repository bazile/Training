using System.ServiceModel;

namespace Belhard.TradeService
{
	[ServiceContract(Namespace="http://http://tc.belhard.com/StockTrade")]
	public interface IStockTradeService
	{
		[OperationContract]
		Quote GetQuote(string ticker);

		[OperationContract]
		void PublishQuote(Quote quote);
	}
}
