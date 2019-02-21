using System;
using System.Collections;

namespace TrainingCenter.EnumerableDemo
{
    class Vector : IEnumerable
    {
        #region Основные члены класса

        double[] values;

        public int Size { get { return values.Length; } }

        // Индексатор
        public double this[int index]
        {
            get { return values[index]; }
            set { values[index] = value; }
        }

        public Vector(int size)
        {
            values = new double[size];
        }

        #region Операторы (добавлены для полноты примера)

        /// <summary>
        /// Оператор сложения векторов
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static Vector operator +(Vector left, Vector right)
        {
            if (left.Size != right.Size) throw new InvalidOperationException("Оба вектора должны иметь одинаковый размер");

            Vector result = new Vector(left.Size);
            double[] values = result.values;
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = left.values[i] + right.values[i];
            }
            return result;
        }

        public static Vector operator -(Vector left, Vector right)
        {
            if (left.Size != right.Size) throw new InvalidOperationException("Оба вектора должны иметь одинаковый размер");

            Vector result = new Vector(left.Size);
            double[] values = result.values;
            for (int i = 0; i < values.Length; i++)
            {
                values[i] = left.values[i] - right.values[i];
            }
            return result;
        }

        #endregion

        #endregion

        #region Реализация IEnumerable

        public IEnumerator GetEnumerator()
        {
            // В данном случае тип Vector является оберткой вокруг целого массива и поэтому
            //   он может пользоваться тем что массив уже реализует IEnumerable
            return values.GetEnumerator();
        }

        #endregion
    }
}
