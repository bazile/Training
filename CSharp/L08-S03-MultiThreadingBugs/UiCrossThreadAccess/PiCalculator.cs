using System;
using System.Globalization;
using System.Numerics;

namespace BelhardTraining.UiCrossThreadAccessDemo
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
        //private int _sign = -1;

        // TODO: Save/restore state

        public string PI
        {
            get
            {
                BigDecimal pi = _result * 4;
                return pi.Mantissa.ToString().Insert(1, NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
            }
        }

        public int AchievedPrecision
        {
            get
            {
                string piCalculated = PI;
                string piReference = PiReferenceValue.Replace(" ", "");
                if (piCalculated[0] != piReference[0]) return 0;

                int precision = 0;
                for (int i = 2; i < Math.Min(piCalculated.Length, piReference.Length); precision++, i++)
                {
                    if (piCalculated[i] != piReference[i]) break;
                }
                return precision;
            }
        }

        public void Run(int iterations)
        {
            if (iterations%2 != 0) iterations++;

            for (int i = 0; i < iterations; _divison += 2, i++)
            {
                _result -= one / _divison;

                i++;
                _divison += 2;

                _result += one / _divison;
            }
        }

        private const string PiReferenceValue =
            "3,1415926535 8979323846 2643383279 5028841971 6939937510 5820974944 5923078164 0628620899 8628034825 3421170679" +
              "8214808651 3282306647 0938446095 5058223172 5359408128 4811174502 8410270193 8521105559 6446229489 5493038196" +
              "4428810975 6659334461 2847564823 3786783165 2712019091 4564856692 3460348610 4543266482 1339360726 0249141273" +
              "7245870066 0631558817 4881520920 9628292540 9171536436 7892590360 0113305305 4882046652 1384146951 9415116094" +
              "3305727036 5759591953 0921861173 8193261179 3105118548 0744623799 6274956735 1885752724 8912279381 8301194912" +
              "9833673362 4406566430 8602139494 6395224737 1907021798 6094370277 0539217176 2931767523 8467481846 7669405132" +
              "0005681271 4526356082 7785771342 7577896091 7363717872 1468440901 2249534301 4654958537 1050792279 6892589235" +
              "4201995611 2129021960 8640344181 5981362977 4771309960 5187072113 4999999837 2978049951 0597317328 1609631859" +
              "5024459455 3469083026 4252230825 3344685035 2619311881 7101000313 7838752886 5875332083 8142061717 7669147303" +
              "5982534904 2875546873 1159562863 8823537875 9375195778 1857780532 1712268066 1300192787 6611195909 2164201989";
    }
}
