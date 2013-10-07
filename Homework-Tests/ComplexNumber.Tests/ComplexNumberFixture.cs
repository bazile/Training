using System;
using System.Collections.Generic;
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
        [Category("Constructor")]
        public void CanCreateComplexNumberWithoutImaginaryPart()
        {
            const double real = 5.1;

            ComplexNumber x = new ComplexNumber(real);
            Assert.AreEqual(real, x.Real);
            Assert.AreEqual(0, x.Imaginary);
        }

        [Test]
        [Category("Constructor")]
        public void CanCreateComplexNumberWithImaginaryPart()
        {
            const double real = 5.2;
            const double imaginary = -10.3;

            ComplexNumber x = new ComplexNumber(real, imaginary);
            Assert.AreEqual(real, x.Real);
            Assert.AreEqual(imaginary, x.Imaginary);
        }

        [Test]
        [Category("Operator overloading")]
        public void CanCompareComplexNumbers()
        {
            const double real = 5.2;
            const double imaginary = -10.3;
            ComplexNumber x = new ComplexNumber(real, imaginary);
            ComplexNumber y = new ComplexNumber(real, imaginary);

            Assert.IsTrue(x == y);
            Assert.IsFalse(x != y);
        }

        [Test]
        [Category("Operator overloading")]
        public void CanCompareComplexNumberWithNull()
        {
            ComplexNumber x = new ComplexNumber(0);
            Assert.IsTrue(x != null);
            Assert.IsFalse(x == null);

            x = null;
            ComplexNumber y = null;
            Assert.IsTrue(x == y);
            Assert.IsFalse(x != y);
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
            ComplexNumber x = new ComplexNumber(10);
            Assert.IsNotNull(x as IComparable, "Type does not implement IComparable.");
        }

        [Test]
        [Category("Interface implementation")]
        public void ImplementsGenericIComparable()
        {
            ComplexNumber x = new ComplexNumber(10);
            Assert.IsNotNull(x as IComparable<ComplexNumber>, "Type does not implement IComparable<ComplexNumber>.");
        }

        [Test]
        [Category("Interface implementation")]
        public void ImplementsIFormattable()
        {
            ComplexNumber x = new ComplexNumber(10);
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

        private void AssertMethodOverride(string methodName, params Type[] arguments)
        {
            Type t = typeof(ComplexNumber);
            MethodInfo mi = t.GetMethod(methodName, BindingFlags.DeclaredOnly | BindingFlags.ExactBinding | BindingFlags.Instance | BindingFlags.Public, null, arguments, null);
            Assert.IsNotNull(mi, String.Format("Method '{0}' is not overriden.", methodName));
            Assert.IsTrue(mi.IsVirtual, String.Format("Method '{0}' is found but it is not virtual.", methodName));
        }

        [Test]
        [TestCaseSource(typeof(ComplexNumberFixtureData), "ToStringData")]
        public string AssertFormatting(ComplexNumber number, string formatSpecifier)
        {
            return String.IsNullOrEmpty(formatSpecifier)
                       ? number.ToString()
                       : number.ToString(formatSpecifier, CultureInfo.InvariantCulture);
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
            }
        }
    }
}
