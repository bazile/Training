#if !USE_MY_IMPLEMENTATION

using System;
using System.Globalization;
using System.Linq;

namespace BankCardNumber.Tests
{
	public static class CardNumberValidator
	{
		public static bool IsValid(string cardNumber)
		{
			throw new NotImplementedException();
		}
	}
}

#endif
