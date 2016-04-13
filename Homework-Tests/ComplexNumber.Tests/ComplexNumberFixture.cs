using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
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
        #region
        //[Test]
        //[Ignore]
        //public void MainImplementation()
        //{
        //    ComplexNumber x = new ComplexNumber(10.5);
        //    ComplexNumber y = null;

        //    if (y == null)
        //    {
        //        y = new ComplexNumber(7, 8.1);

        //        ComplexNumber z = x + y;
        //        Console.WriteLine(z); // 17.5+i8.1

        //        z -= 20;
        //        Console.WriteLine(z); // -2.5+i8.1

        //        z.Real += 13;
        //        z.Imaginary -= 8.1;
        //        Console.WriteLine(z); // 10.5

        //        if (z == x && z != y)
        //        {
        //            Console.WriteLine("{0:A}", z - y); // 3.5-i8.1
        //            Console.WriteLine("{0:P}", z - y); // (3.5, -8.1)
        //        }
        //    }
        //}
        #endregion

        [Test]
        [Category("Constructor")]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "ConstructorDataRealOnly")]
        public void CanCreateComplexNumberWithoutImaginaryPart(double real)
        {
            var x = new ComplexNumber(real);
            Assert.AreEqual(real, x.Real);
            Assert.AreEqual(0, x.Imaginary);
        }

        [Test]
        [Category("Constructor")]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "ConstructorDataRealAndImaginary")]
        public void CanCreateComplexNumberWithImaginaryPart(double real, double imaginary)
        {
            var x = new ComplexNumber(real, imaginary);
            Assert.AreEqual(real, x.Real);
            Assert.AreEqual(imaginary, x.Imaginary);
        }

        [Test]
        [Category("Operator overloading")]
        public void CanCompare()
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
// ReSharper disable InconsistentNaming
            string pairXX = AsString(x) + " and " + AsString(x);
            string pairXY = AsString(x) + " and " + AsString(y);
            string pairYX = AsString(y) + " and " + AsString(x);
            string pairYY = AsString(y) + " and " + AsString(y);
// ReSharper restore InconsistentNaming

            Debug.WriteLine("Checking " + pairXY);

            AssertTrueEquality(x, x, pairXX + " must be equal");
            AssertTrueEquality(y, y, pairYY + " must be equal");

            AssertTrueEquality(x, new ComplexNumber(x.Real, x.Imaginary), pairXX + " must be equal");
            AssertTrueEquality(new ComplexNumber(x.Real, x.Imaginary), x, pairXX + " must be equal");

            AssertFalseEquality(x, y, pairXY + " must be not equal");
            AssertFalseEquality(y, x, pairYX + " must be not equal");
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private static void AssertTrueEquality(ComplexNumber a, ComplexNumber b, string message)
        {
            Assert.IsTrue(a == b, message);
            Assert.IsTrue(a.Equals((object)b), message);
            Assert.IsTrue(((IEquatable<ComplexNumber>)a).Equals(b), message);
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private static void AssertFalseEquality(ComplexNumber a, ComplexNumber b, string message)
        {
            Assert.IsFalse(a == b, message);
            Assert.IsFalse(a.Equals((object)b), message);
            Assert.IsFalse(((IEquatable<ComplexNumber>)a).Equals(b), message);
        }

        [Test]
        [Category("Operator overloading")]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "EqualityData")]
        public void CanCompareNonEquality(ComplexNumber x, ComplexNumber y)
        {
            // ReSharper disable InconsistentNaming
            string pairXX = AsString(x) + " and " + AsString(x);
            string pairXY = AsString(x) + " and " + AsString(y);
            string pairYX = AsString(y) + " and " + AsString(x);
            string pairYY = AsString(y) + " and " + AsString(y);
            // ReSharper restore InconsistentNaming

            Debug.WriteLine("Checking " + pairXY);

            #pragma warning disable 1718 // Comparison made to same variable
            // ReSharper disable EqualExpressionComparison

                AssertFalseNonEquality(x, x, pairXX + " must be equal");
                AssertFalseNonEquality(y, y, pairYY + " must be equal");

            // ReSharper restore EqualExpressionComparison
            #pragma warning restore 1718 // Comparison made to same variable

            AssertFalseNonEquality(x, new ComplexNumber(x.Real, x.Imaginary), pairXX + " must be equal");
            AssertFalseNonEquality(new ComplexNumber(x.Real, x.Imaginary), x, pairXX + " must be equal");

            AssertTrueNonEquality(x, y, pairXY + " must be not equal");
            AssertTrueNonEquality(y, x, pairYX + " must be not equal");
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private static void AssertTrueNonEquality(ComplexNumber a, ComplexNumber b, string message)
        {
            Assert.IsTrue(a != b, message);
            Assert.IsFalse(a.Equals((object)b), message);
            Assert.IsFalse(((IEquatable<ComplexNumber>)a).Equals(b), message);
        }

        [SuppressMessage("ReSharper", "UnusedParameter.Local")]
        private static void AssertFalseNonEquality(ComplexNumber a, ComplexNumber b, string message)
        {
            Assert.IsFalse(a != b, message);
            Assert.IsTrue(a.Equals((object)b), message);
            Assert.IsTrue(((IEquatable<ComplexNumber>)a).Equals(b), message);
        }

        [Test]
        [Category("Operator overloading")]
        public void CanCompareWithNull()
        {
            var x = new ComplexNumber(0);
            Assert.IsTrue(x != null);
            Assert.IsTrue(null != x);
            Assert.IsFalse(x == null);
            Assert.IsFalse(null == x);
            Assert.IsFalse(x.Equals(null), "x.Equals(null)");

            x = null;
            ComplexNumber y = null;
            Assert.IsTrue(x == y);
            Assert.IsFalse(x != y);
        }

        [Test]
        [Category("Operator overloading")]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "AddData")]
        public ComplexNumber CanAdd(ComplexNumber x, ComplexNumber y)
        {
            ComplexNumber result = x + y;
            Assert.AreEqual(x.Real + y.Real, result.Real);
            Assert.AreEqual(x.Imaginary + y.Imaginary, result.Imaginary);
            return result;
        }

        [Test]
        [Category("Operator overloading")]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "SubtractData")]
        public ComplexNumber CanSubtract(ComplexNumber x, ComplexNumber y)
        {
            ComplexNumber result = x - y;
            Assert.AreEqual(x.Real - y.Real, result.Real);
            Assert.AreEqual(x.Imaginary - y.Imaginary, result.Imaginary);
            return result;
        }

        [Test]
        [Category("Operator overloading")]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "ConstructorDataRealOnly")]
        public void CanConvertDoubleToComplexNumber(double real)
        {
            ComplexNumber result = real;
            Assert.AreEqual(result.Real, real);
            Assert.AreEqual(result.Imaginary, 0.0);
        }

        [Test]
        [Category("Interface implementation")]
        public void ImplementsGenericIEquatable()
        {
            var x = new ComplexNumber(10);
            Assert.That(x,
                Is.AssignableTo<IEquatable<ComplexNumber>>(),
                "Type does not implement IEquatable<ComplexNumber>."
            );
        }

        [Test]
        [Category("Interface implementation")]
        public void ImplementsIFormattable()
        {
            var x = new ComplexNumber(10);
            Assert.That(x,
                Is.AssignableTo<IFormattable>(),
                "Type does not implement IFormattable."
            );
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
        [Category("ToString() implementation")]
        public void OverridesToString()
        {
            AssertMethodOverride("ToString");
        }

        [Test]
        [Category("ToString() implementation")]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "ToStringData")]
        public string AssertFormatting(ComplexNumber number, string formatSpecifier)
        {
            return string.IsNullOrEmpty(formatSpecifier)
                        ? number.ToString().Replace(" ", "")
                        : ((IFormattable)number).ToString(formatSpecifier, CultureInfo.InvariantCulture).Replace(" ", "");
        }

        [Test]
        [Category("ToString() implementation")]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "ToStringWithCultureData")]
        public string AssertFormattingWithCulture(ComplexNumber number, string formatSpecifier, string cultureName)
        {
            return ((IFormattable)number).ToString(formatSpecifier, new CultureInfo(cultureName)).Replace(" ", "");
        }

        [Test]
        [Category("ToString() implementation")]
        public void ToStringThrowsFormatExceptionForUnknownFormat()
        {
            ImplementsIFormattable();
            
            Assert.That(
                () => {
                    var num = new ComplexNumber(1, 1);
                    var iformattable = num as IFormattable;
                    string result = iformattable.ToString("X", null);
                    Console.WriteLine(result);
                },
                Throws.TypeOf<FormatException>().With.Message.Length.GreaterThan(0)
            );
        }

        private static void AssertMethodOverride(string methodName, params Type[] arguments)
        {
            Type t = typeof(ComplexNumber);
            MethodInfo mi = t.GetMethod(methodName, BindingFlags.DeclaredOnly | BindingFlags.ExactBinding | BindingFlags.Instance | BindingFlags.Public, null, arguments, null);
            Assert.IsNotNull(mi, string.Format("Method '{0}' is not overriden.", methodName));
            Assert.IsTrue(mi.IsVirtual, string.Format("Method '{0}' is found but it is not virtual.", methodName));
        }

        readonly CultureInfo AsStringCulture = CultureInfo.GetCultureInfo("en-US");
        private string AsString(ComplexNumber cx)
        {
            if (ReferenceEquals(cx, null)) return "null";
            return string.Format(AsStringCulture, "[{0}, {1}]", cx.Real, cx.Imaginary);
        }
    }

    public static class ComplexNumberFixtureData
    {
        public static IEnumerable<TestCaseData> ConstructorDataRealOnly
        {
            get
            {
                double[] nums = new[] { 0, 1, -1, 10.51, -10.52, double.MaxValue, double.MinValue};
                return nums.Select(num => new TestCaseData(num));
            }
        }

        public static IEnumerable<TestCaseData> ConstructorDataRealAndImaginary
        {
            get
            {
                double[] nums = new[] {0, 1, -1, 10.51, -10.52, double.MaxValue, double.MinValue};
                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = 0; j < nums.Length; j++)
                    {
                        yield return new TestCaseData(nums[i], nums[j]);
                    }
                }
            }
        }

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

                yield return new TestCaseData(new ComplexNumber(1, 2), new ComplexNumber(9, 8)).Returns(new ComplexNumber(-8, -6));
                yield return new TestCaseData(new ComplexNumber(3, 4), new ComplexNumber(-1, -2)).Returns(new ComplexNumber(4, 6));
            }
        }

        public static IEnumerable<TestCaseData> ToStringData
        {
            get
            {
                yield return new TestCaseData(new ComplexNumber(0, 0)  , null).Returns("0");
                yield return new TestCaseData(new ComplexNumber(1, 0)  , null).Returns("1");
                yield return new TestCaseData(new ComplexNumber(-1, 0) , null).Returns("-1");
                yield return new TestCaseData(new ComplexNumber(1, 2)  , null).Returns("1+i2");
                yield return new TestCaseData(new ComplexNumber(-1, 2) , null).Returns("-1+i2");
                yield return new TestCaseData(new ComplexNumber(1, -2) , null).Returns("1-i2");
                yield return new TestCaseData(new ComplexNumber(-1, -2), null).Returns("-1-i2");

                yield return new TestCaseData(new ComplexNumber(0, 0)  , "A").Returns("0");
                yield return new TestCaseData(new ComplexNumber(1, 0)  , "A").Returns("1");
                yield return new TestCaseData(new ComplexNumber(-1, 0) , "A").Returns("-1");
                yield return new TestCaseData(new ComplexNumber(1, 2)  , "A").Returns("1+i2");
                yield return new TestCaseData(new ComplexNumber(-1, 2) , "A").Returns("-1+i2");
                yield return new TestCaseData(new ComplexNumber(1, -2) , "A").Returns("1-i2");
                yield return new TestCaseData(new ComplexNumber(-1, -2), "A").Returns("-1-i2");

                yield return new TestCaseData(new ComplexNumber(0, 0)  , "P").Returns("(0,0)");
                yield return new TestCaseData(new ComplexNumber(1, 2)  , "P").Returns("(1,2)");
                yield return new TestCaseData(new ComplexNumber(-1, 2) , "P").Returns("(-1,2)");
                yield return new TestCaseData(new ComplexNumber(1, -2) , "P").Returns("(1,-2)");
                yield return new TestCaseData(new ComplexNumber(-1, -2), "P").Returns("(-1,-2)");
            }
        }

        public static IEnumerable<TestCaseData> ToStringWithCultureData
        {
            get
            {
                yield return new TestCaseData(new ComplexNumber(1.123, 2.234)  , "A", "ru-RU").Returns("1,123+i2,234");
                yield return new TestCaseData(new ComplexNumber(-1.123, -2.234), "A", "ru-RU").Returns("-1,123-i2,234");
                yield return new TestCaseData(new ComplexNumber(1.123, 2.234)  , "A", "en-US").Returns("1.123+i2.234");
                yield return new TestCaseData(new ComplexNumber(-1.123, -2.234), "A", "en-US").Returns("-1.123-i2.234");

                yield return new TestCaseData(new ComplexNumber(1.123, 2.234)  , "P", "ru-RU").Returns("(1,123,2,234)");
                yield return new TestCaseData(new ComplexNumber(-1.123, -2.234), "P", "ru-RU").Returns("(-1,123,-2,234)");
                yield return new TestCaseData(new ComplexNumber(1.123, 2.234)  , "P", "en-US").Returns("(1.123,2.234)");
                yield return new TestCaseData(new ComplexNumber(-1.123, -2.234), "P", "en-US").Returns("(-1.123,-2.234)");
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
