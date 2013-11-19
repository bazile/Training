using System.Globalization;
using System.Numerics;

namespace BelhardTraining.PiCalc
{
    /// <summary>
    /// Вычисление значения константы Пи с помощью ряда Лейбница
    /// pi/4 = 1/1 - 1/3 + 1/5 - 1/7 + 1/9 ...
    /// </summary>
    internal class PiCalculator
    {
        private static readonly BigDecimal one = new BigDecimal(BigInteger.Parse("1"), 0);
        private BigDecimal _result = new BigDecimal(BigInteger.Parse("1"), 0);
        private BigDecimal _divison = new BigDecimal(BigInteger.Parse("3"), 0);
        private int _sign = -1;

        public string Pi
        {
            get
            {
                BigDecimal pi = _result * 4;
                return pi.Mantissa.ToString().Insert(1, NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
            }
        }

        public void Run(int iterations)
        {
            for (int i = 0; i < iterations; _divison += 2, _sign = -_sign, i++)
            {
                _result += _sign * (one / _divison);
            }
        }
    }

    // Пример на Java
    // http://javahowto.blogspot.com/2011/08/example-of-expensive-computation.html
}
