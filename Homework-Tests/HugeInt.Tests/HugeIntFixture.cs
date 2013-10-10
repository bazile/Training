using NUnit.Framework;

namespace HugeInt.Tests
{
    //
    // Unit-тесты для классов HugeInt и UHugeInt
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
    public class HugeIntFixture
    {
        [Test]
        public void CanCreateHugeIntFromString()
        {
            HugeInt num = new HugeInt("1290");
            Assert.AreEqual("1290", num.ToString());
        }

        [Test]
        public void CanCreateHugeIntFromInt()
        {
            HugeInt num = new HugeInt(1290);
            Assert.AreEqual("1290", num.ToString());
        }

        //[Test]
        //public void CanCreateHugeIntFromByteArray()
        //{
        //    HugeInt num = new HugeInt(new byte[]{1,2,9,0});
        //    Assert.AreEqual("1290", num.ToString());
        //}

        [Test]
        [Category("Operator overloading")]
        public void CanAddHugeInt()
        {
            HugeInt a = new HugeInt(123);
            HugeInt b = new HugeInt(456);
            HugeInt c = a + b;
            Assert.AreEqual("579", c.ToString());
        }

        [Test]
        [Category("Operator overloading")]
        public void CanSubtractHugeInt()
        {
            HugeInt a = new HugeInt(456);
            HugeInt b = new HugeInt(123);
            HugeInt c = a - b;
            Assert.AreEqual("333", c.ToString());
        }

        [Test]
        [Category("Operator overloading")]
        public void CanCompareComplexNumberWithNull()
        {
            HugeInt x = new HugeInt(0);
            Assert.IsTrue(x != null);
            Assert.IsFalse(x == null);
        }
    }
}
