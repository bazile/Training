using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Vector.UnitTests
{
	public class TestBase
	{
		protected void AssertCatch<T>(Action act)
			where T : Exception
		{
			Exception ex = null;
			try
			{
				act();
			}
			catch (T caughtEx)
			{
				ex = caughtEx;
			}
			Assert.IsInstanceOfType(ex, typeof(T));
		}
	}
}