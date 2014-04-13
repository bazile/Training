using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BankCardNumber.Tests
{
	/// <remarks>
	/// Проверочные номера карт взяты со страницы https://www.auricsystems.com/support-center/sample-credit-card-numbers/
	/// </remarks>>
	[TestClass]
	public class BankCardNumberFixture
	{
		[TestMethod]
		public void NullValueIsInvalid()
		{
			Assert.IsFalse(CardNumberValidator.IsValid(null), "Null value must not be valid");
		}

		[TestMethod]
		public void VisaIsValid()
		{
			var visaNumbers = new[]
				{
					"4444 4444 4444 4448",
					"4444 4244 4444 4440",
					"4444 4144 4444 4441",
					"4012 8888 8888 1881",
					"4055 0111 1111 1111"
				};
			foreach (var cardNumber in visaNumbers)
			{
				AssertIsValid(cardNumber);
			}
		}

		[TestMethod]
		public void MasterCardIsValid()
		{
			var masterCardNumbers = new[]
				{
					"5500 0055 5555 5559",
					"5555 5555 5555 5557",
					"5454 5454 5454 5454",
					"5555 5155 5555 5551",
					"5405 2222 2222 2226",
					"5478 0500 0000 0007",
					"5111 0051 1105 1128",
					"5112 3451 1234 5114"
				};
			foreach (var cardNumber in masterCardNumbers)
			{
				AssertIsValid(cardNumber);
			}
		}

		[TestMethod]
		public void ImaginaryNumberIsValid()
		{
			AssertIsValid("79927398713");
		}

		[TestMethod]
		public void ImaginaryNumberIsIndalid()
		{
			var badNumbers = new[] { "79927398710", "79927398711", "79927398712", "79927398714", "79927398715", "79927398716", "79927398717", "79927398718", "79927398719" };
			foreach (var badCardNumber in badNumbers)
			{
				AssertIsIndalid(badCardNumber);
			}
		}

		private static void AssertIsValid(string cardNumber)
		{
			string errorMessage = string.Format("Card number '{0}' must be valid!", cardNumber);
			Assert.IsTrue(CardNumberValidator.IsValid(cardNumber.Replace(" ", "")), errorMessage);
		}

		private static void AssertIsIndalid(string cardNumber)
		{
			string errorMessage = string.Format("Card number '{0}' must be invalid!", cardNumber);
			Assert.IsFalse(CardNumberValidator.IsValid(cardNumber.Replace(" ", "")), errorMessage);
		}
	}
}
