using MyVector;
using NUnit.Framework;

namespace UnitTests
{
	[TestFixture]
    public class VectorFixture
    {
		[Test]
		public void LengthMustBeCorrect()
		{
			var v1 = new Vector(1);
			Assert.AreEqual(1, v1.Length);
		}

		[Test]
		public void MustReturnCorrectValues()
		{
			var v1 = new Vector(3);
			v1[0] = 100;
			v1[1] = 200;
			v1[2] = 300;
			Assert.AreEqual(100, v1[0]);
			Assert.AreEqual(200, v1[1]);
			Assert.AreEqual(300, v1[2]);
		}
    }
}
