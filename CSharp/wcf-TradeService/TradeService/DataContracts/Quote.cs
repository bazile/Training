using System;
using System.Runtime.Serialization;

namespace Belhard.TradeService
{
	public class Quote
	{
		[DataMember(Name = "Ticker")]
		public string Ticker;

		[DataMember(Name = "Bid")]
		public decimal Bid;

		[DataMember(Name = "Ask")]
		public decimal Ask;

		[DataMember(Name = "Publisher")]
		public string Publisher;

		[DataMember(Name = "UpdateDateTime")]
		private DateTime UpdateDateTime;
	}
}
