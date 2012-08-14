using System;
using MyVector;
using NUnit.Framework;

namespace UnitTests
{
	[TestFixture]
    public class IntVectorFixture
    {
		[Test]
		public void EmptyVectorMustHaveSizeOfZero()
		{
			var v = new IntVector(10);
			Assert.AreEqual(0, v.Size);
		}

		[Test]
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

		[Test]
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

		[Test]
		public void MustThrowExceptionIfOutRange()
		{
			var v = new IntVector(1);
			Assert.Catch<IndexOutOfRangeException>(() => { int i = v[1]; });
			Assert.Catch<InvalidOperationException>(() => v.Pop());
		}

		[Test]
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

		[Test]
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
    }
}
