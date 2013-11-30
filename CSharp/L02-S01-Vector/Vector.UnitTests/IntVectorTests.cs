using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyVector;

namespace Vector.UnitTests
{
	[TestClass]
    public class IntVectorFixture : TestBase
    {
		[TestMethod]
		public void EmptyVectorMustHaveSizeOfZero()
		{
			var v = new IntVector(10);
			Assert.AreEqual(0, v.Size);
		}

		[TestMethod]
		public void MustBeFilledWithTheSingleValue()
		{
			const int fillValue = 1234;
			var v = new IntVector(33, fillValue);

			Assert.AreEqual(33, v.Size);
			foreach(int value in v)
			{
				Assert.AreEqual(fillValue, value);
			}
		}

		[TestMethod]
		public void MustReturnCorrectValues()
		{
			var v = new IntVector(2);
			v.Push(100);
			v.Push(200);
			v.Push(300);
			Assert.AreEqual(3, v.Size);
			Assert.AreEqual(100, v[0]);
			Assert.AreEqual(200, v[1]);
			Assert.AreEqual(300, v[2]);
		}

		[TestMethod]
		public void MustThrowExceptionIfOutRange()
		{
			var v = new IntVector(1);
			AssertCatch<IndexOutOfRangeException>(() => { int i = v[1]; });
			AssertCatch<InvalidOperationException>(() => v.Pop());
		}

		[TestMethod]
		public void OperatorPlusMustAddValue()
		{
			var v = new IntVector(2);
			v.Push(100);
			v.Push(200);
			v.Push(300);
			v += 10;
			Assert.AreEqual(110, v[0]);
			Assert.AreEqual(210, v[1]);
			Assert.AreEqual(310, v[2]);
		}

		[TestMethod]
		public void OperatorEquals()
		{
			var v1 = new IntVector(3);
			v1.Push(100);
			v1.Push(200);
			v1.Push(300);
			IntVector v2 = v1;

			Assert.IsTrue(v1==v2);
			Assert.IsFalse(v1 == null);

			v2 = null;
			Assert.IsTrue(v2 == null);

			v2 = new IntVector(3);
			v2.Push(100);
			v2.Push(200);
			v2.Push(300);
			Assert.IsTrue(v1 == v2);
			Assert.IsTrue(v2 == v1);
			Assert.IsFalse(v1 != v2);
			Assert.IsFalse(v2 != v1);
		}

		[TestMethod]
		public void GetHashCodeMustBeDifferent()
		{
			var v1 = new IntVector(3);
			v1.Push(100);
			v1.Push(200);
			v1.Push(300);

			var v2 = new IntVector(3);
			v2.Push(101);
			v2.Push(200);
			v2.Push(300);
			
			Assert.AreNotEqual(v1.GetHashCode(), v2.GetHashCode());
		}
    }
}
