using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Reflection;
using NUnit.Framework;

namespace ComplexNumber.Tests
{
    //
    // Unit-тесты для класса ComplexNumber
    //
    // Для запуска тестов установите одну из программ:
    //
    //  а) NUnit. Бесплатная библиотека с GUI утилитой для запуска тестов.
    //     http://www.nunit.org/
    //
    //          ИЛИ
    //
    //  б) ReSharper. Платное дополнение к Visual Studio.
    //     http://www.jetbrains.com/resharper/
    //

    [TestFixture]
    public class ComplexNumberFixture
    {
		[Test]
		[Ignore]
		public void MainImplementation()
		{
			//ComplexNumber x = new ComplexNumber(10.5);
			//ComplexNumber y = null;

			//if (y == null)
			//{
			//    y = new ComplexNumber(7, 8.1);

			//    ComplexNumber z = x + y;
			//    Console.WriteLine(z); // 17.5+i8.1

			//    z -= 20;
			//    Console.WriteLine(z); // -2.5+i8.1

			//    z.Real += 13;
			//    z.Imaginary -= 8.1;
			//    Console.WriteLine(z); // 10.5

			//    if (z == x && z != y)
			//    {
			//        Console.WriteLine("{0:A}", z - y); // 3.5-i8.1
			//        Console.WriteLine("{0:P}", z - y); // (3.5, -8.1)
			//    }
			//}
		}

        [Test]
        [Category("Constructor")]
        public void CanCreateComplexNumberWithoutImaginaryPart()
        {
            const double real = 5.1;

            var x = new ComplexNumber(real);
            Assert.AreEqual(real, x.Real);
            Assert.AreEqual(0, x.Imaginary);
        }

        [Test]
        [Category("Constructor")]
        public void CanCreateComplexNumberWithImaginaryPart()
        {
            const double real = 5.2;
            const double imaginary = -10.3;

            var x = new ComplexNumber(real, imaginary);
            Assert.AreEqual(real, x.Real);
            Assert.AreEqual(imaginary, x.Imaginary);
        }

        [Test]
        [Category("Operator overloading")]
        public void CanCompareComplexNumbers()
        {
            const double real = 5.2;
            const double imaginary = -10.3;
            var x = new ComplexNumber(real, imaginary);
            var y = new ComplexNumber(real, imaginary);

            Assert.IsTrue(x == y);
            Assert.IsFalse(x != y);
        }

		[Test]
		[Category("Operator overloading")]
		[TestCaseSource(typeof(ComplexNumberFixtureData), "EqualityData")]
		public void CanCompareEquality(ComplexNumber x, ComplexNumber y)
		{
			string pairXX = AsString(x) + " and " + AsString(x);
			string pairXY = AsString(x) + " and " + AsString(y);
			string pairYX = AsString(y) + " and " + AsString(x);
			string pairYY = AsString(y) + " and " + AsString(y);

			Debug.WriteLine("Checking " + pairXY);

			// ReSharper disable EqualExpressionComparison
			Assert.IsTrue(x == x, pairXX + " must be equal");
			Assert.IsTrue(y == y, pairYY + " must be equal");
			// ReSharper restore EqualExpressionComparison

			Assert.IsTrue(x == new ComplexNumber(x.Real, x.Imaginary), pairXX + " must be equal");
			Assert.IsTrue(new ComplexNumber(x.Real, x.Imaginary) == x, pairXX + " must be equal");

			Assert.IsFalse(x == y, pairXY + " must be not equal");
			Assert.IsFalse(y == x, pairYX + " must be not equal");
		}

		[Test]
		[Category("Operator overloading")]
		[TestCaseSource(typeof(ComplexNumberFixtureData), "EqualityData")]
		public void CanCompareNonEquality(ComplexNumber x, ComplexNumber y)
		{
			string pairXX = AsString(x) + " and " + AsString(x);
			string pairXY = AsString(x) + " and " + AsString(y);
			string pairYX = AsString(y) + " and " + AsString(x);
			string pairYY = AsString(y) + " and " + AsString(y);

			Debug.WriteLine("Checking " + pairXY);

			// ReSharper disable EqualExpressionComparison
			Assert.IsFalse(x != x, pairXX + " must be equal");
			Assert.IsFalse(y != y, pairYY + " must be equal");
			// ReSharper restore EqualExpressionComparison

			Assert.IsFalse(x != new ComplexNumber(x.Real, x.Imaginary), pairXX + " must be equal");
			Assert.IsFalse(new ComplexNumber(x.Real, x.Imaginary) != x, pairXX + " must be equal");

			Assert.IsTrue(x != y, pairXY + " must be not equal");
			Assert.IsTrue(y != x, pairYX + " must be not equal");
		}

        [Test]
        [Category("Operator overloading")]
        public void CanCompareComplexNumberWithNull()
        {
            var x = new ComplexNumber(0);
            Assert.IsTrue(x != null);
            Assert.IsFalse(x == null);

            x = null;
            ComplexNumber y = null;
            Assert.IsTrue(x == y);
            Assert.IsFalse(x != y);
        }

		[Test]
		[Category("Operator overloading")]
		public void NullIsLessThanComplexNumber()
		{
			// ReSharper disable ConditionIsAlwaysTrueOrFalse
			// ReSharper disable HeuristicUnreachableCode

			var x = new ComplexNumber(0);
			var comparable = x as IComparable<ComplexNumber>;
			if (comparable == null)
			{
				Assert.Inconclusive("Type doesn't implement IComparable<ComplexNumber>");
			}
			else
			{
				Assert.GreaterOrEqual(comparable.CompareTo(null), 0);
			}

			// ReSharper restore HeuristicUnreachableCode
			// ReSharper restore ConditionIsAlwaysTrueOrFalse
		}

        [Test]
        [Category("Operator overloading")]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "AddData")]
        public ComplexNumber CanAddComplexNumbers(ComplexNumber x, ComplexNumber y)
        {
            return x + y;
        }

        [Test]
        [Category("Operator overloading")]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "SubtractData")]
        public ComplexNumber CanSubtractComplexNumbers(ComplexNumber x, ComplexNumber y)
        {
            return x - y;
        }

        [Test]
        [Category("Interface implementation")]
        public void ImplementsIComparable()
        {
            var x = new ComplexNumber(10);
            Assert.IsNotNull(x as IComparable, "Type does not implement IComparable.");
        }

        [Test]
        [Category("Interface implementation")]
        public void ImplementsGenericIComparable()
        {
            var x = new ComplexNumber(10);
            Assert.IsNotNull(x as IComparable<ComplexNumber>, "Type does not implement IComparable<ComplexNumber>.");
        }

        [Test]
        [Category("Interface implementation")]
        public void ImplementsIFormattable()
        {
            var x = new ComplexNumber(10);
            Assert.IsNotNull(x as IFormattable, "Type does not implement IFormattable.");
        }

        [Test]
        [Category("System.Object overrides")]
        public void OverridesEquals()
        {
            AssertMethodOverride("Equals", typeof(object));
        }

        [Test]
        [Category("System.Object overrides")]
        public void HasGetHashCodeMethod()
        {
            MethodInfo mi = typeof(ComplexNumber).GetMethod("GetHashCode", BindingFlags.DeclaredOnly | BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
            if (mi != null)
            {
                Assert.Inconclusive("Found GetHashCode() method");
            }
        }

        [Test]
        [Category("System.Object overrides")]
        public void OverridesToString()
        {
            AssertMethodOverride("ToString");
        }

        [Test]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "ToStringData")]
        public string AssertFormatting(ComplexNumber number, string formatSpecifier)
        {
            return String.IsNullOrEmpty(formatSpecifier)
                       ? number.ToString()
                       : number.ToString(formatSpecifier, CultureInfo.InvariantCulture);
        }

		private static void AssertMethodOverride(string methodName, params Type[] arguments)
		{
			Type t = typeof(ComplexNumber);
			MethodInfo mi = t.GetMethod(methodName, BindingFlags.DeclaredOnly | BindingFlags.ExactBinding | BindingFlags.Instance | BindingFlags.Public, null, arguments, null);
			Assert.IsNotNull(mi, String.Format("Method '{0}' is not overriden.", methodName));
			Assert.IsTrue(mi.IsVirtual, String.Format("Method '{0}' is found but it is not virtual.", methodName));
		}

		private static string AsString(ComplexNumber cx)
		{
			if (cx == null) return "null";
			return String.Format(CultureInfo.GetCultureInfo("en-US"), "[{0}, {1}]", cx.Real, cx.Imaginary);
		}
    }

    public static class ComplexNumberFixtureData
    {
        public static IEnumerable<TestCaseData> AddData
        {
            get
            {
                yield return new TestCaseData(new ComplexNumber(0, 0), new ComplexNumber(0, 0)).Returns(new ComplexNumber(0, 0));

                yield return new TestCaseData(new ComplexNumber(1, 2), new ComplexNumber(3, 4)).Returns(new ComplexNumber(4, 6));
                yield return new TestCaseData(new ComplexNumber(3, 4), new ComplexNumber(1, 2)).Returns(new ComplexNumber(4, 6));
            }
        }

        public static IEnumerable<TestCaseData> SubtractData
        {
            get
            {
                yield return new TestCaseData(new ComplexNumber(0, 0), new ComplexNumber(0, 0)).Returns(new ComplexNumber(0, 0));

                yield return new TestCaseData(new ComplexNumber(1, 2), new ComplexNumber(3, 4)).Returns(new ComplexNumber(-2, -2));
                yield return new TestCaseData(new ComplexNumber(3, 4), new ComplexNumber(1, 2)).Returns(new ComplexNumber(2, 2));
            }
        }

        public static IEnumerable<TestCaseData> ToStringData
        {
            get
            {
                yield return new TestCaseData(new ComplexNumber(0, 0), null).Returns("0+i0");
                yield return new TestCaseData(new ComplexNumber(1, 2), null).Returns("1+i2");
                yield return new TestCaseData(new ComplexNumber(-1, 2), null).Returns("-1+i2");
                yield return new TestCaseData(new ComplexNumber(1, -2), null).Returns("1-i2");
                yield return new TestCaseData(new ComplexNumber(-1, -2), null).Returns("-1-i2");

				yield return new TestCaseData(new ComplexNumber(0, 0), "A").Returns("0+i0");
				yield return new TestCaseData(new ComplexNumber(1, 2), "A").Returns("1+i2");
				yield return new TestCaseData(new ComplexNumber(-1, 2), "A").Returns("-1+i2");
				yield return new TestCaseData(new ComplexNumber(1, -2), "A").Returns("1-i2");
				yield return new TestCaseData(new ComplexNumber(-1, -2), "A").Returns("-1-i2");

				yield return new TestCaseData(new ComplexNumber(0, 0), "P").Returns("(0, 0)");
				yield return new TestCaseData(new ComplexNumber(1, 2), "P").Returns("(1, 2)");
				yield return new TestCaseData(new ComplexNumber(-1, 2), "P").Returns("(-1, 2)");
				yield return new TestCaseData(new ComplexNumber(1, -2), "P").Returns("(1, -2)");
				yield return new TestCaseData(new ComplexNumber(-1, -2), "P").Returns("(-1, -2)");
			}
        }

	    public static object[] EqualityData
	    {
		    get
		    {
			    return new object[]
				    {
						new[] {
								new ComplexNumber(0, 0),
								new ComplexNumber(5.2, 10.3)
							},
						new[] {
								new ComplexNumber(5.2, 10.3),
								new ComplexNumber(5.2, -10.3)
							},
						new[] {
								new ComplexNumber(5.2, 10.3),
								new ComplexNumber(-5.2, 10.3)
							},
						new[] {
								new ComplexNumber(5.2, 10.3),
								new ComplexNumber(-5.2, -10.3)
							}
				    };
		    }
	    }
    }
}
