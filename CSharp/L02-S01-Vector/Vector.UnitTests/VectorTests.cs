using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyVector.Generic;

namespace Vector.UnitTests
{
	[TestClass]
	public class VectorTests : TestBase
	{
		[TestMethod]
		public void EmptyVectorMustHaveSizeOfZero()
		{
			var v = new Vector<byte>(10);
			Assert.AreEqual(0, v.Size);
		}

		[TestMethod]
		public void MustBeFilledWithTheSingleValue()
		{
			const byte fillValue = 123;
			var v = new Vector<byte>(33, fillValue);

			Assert.AreEqual(33, v.Size);
			foreach (int value in v)
			{
				Assert.AreEqual(fillValue, value);
			}
		}

		[TestMethod]
		public void MustReturnCorrectValues()
		{
			var v = new Vector<byte>(2);
			v.Push(50);
			v.Push(100);
			v.Push(150);
			Assert.AreEqual(3, v.Size);
			Assert.AreEqual(50, v[0]);
			Assert.AreEqual(100, v[1]);
			Assert.AreEqual(150, v[2]);
		}

		[TestMethod]
		public void MustThrowExceptionIfOutRange()
		{
			var v = new Vector<byte>(1);
			AssertCatch<IndexOutOfRangeException>(() => { int i = v[1]; });
			AssertCatch<InvalidOperationException>(() => v.Pop());
		}

		[TestMethod]
		public void OperatorEquals()
		{
			var v1 = new Vector<byte>(3);
			v1.Push(50);
			v1.Push(100);
			v1.Push(150);
			Vector<byte> v2 = v1;

			Assert.IsTrue(v1 == v2);
			Assert.IsFalse(v1 == null);

			v2 = null;
			Assert.IsTrue(v2 == null);

			v2 = new Vector<byte>(3);
			v2.Push(50);
			v2.Push(100);
			v2.Push(150);
			Assert.IsTrue(v1 == v2);
			Assert.IsTrue(v2 == v1);
			Assert.IsFalse(v1 != v2);
			Assert.IsFalse(v2 != v1);
		}

		[TestMethod]
		public void GetHashCodeMustBeDifferent()
		{
			var v1 = new Vector<byte>(3);
			v1.Push(50);
			v1.Push(100);
			v1.Push(150);

			var v2 = new Vector<byte>(3);
			v2.Push(5);
			v2.Push(100);
			v2.Push(150);

			Assert.AreNotEqual(v1.GetHashCode(), v2.GetHashCode());
		}
	}
}
