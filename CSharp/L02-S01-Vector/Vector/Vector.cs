using System.Collections;
using System.Collections.Generic;

namespace MyVector
{
	public class Vector : IEnumerable<int>
	{
		/// <summary>
		/// Поле класса
		/// </summary>
		private readonly int[] _points;

		/// <summary>
		/// Конструктор с параметром
		/// </summary>
		/// <param name="maxLength"></param>
        public Vector(int maxLength)
        {
            _points = new int[maxLength];
        }

        public int GetSum()
        {
            int sum = 0;
            for (int i = 0; i < _points.Length; i++)
            {
	            sum += _points[i];
            }
            return sum;
        }

		/// <summary>
		/// Свойство
		/// </summary>
        public int Length
        {
            get { return _points.Length; }
        }

		/// <summary>
		/// Индексатор
		/// </summary>
		/// <param name="index"> </param>
		/// <returns></returns>
		public int this[int index]
        {
            get
			{
				if(index < _points.Length && index >= 0)
				{
					return _points[index];
				}
				return 0;
            }
            set
			{
                if (index < _points.Length && index >= 0)
                {
	                _points[index] = value;
                }
            }
        }

		public IEnumerator<int> GetEnumerator()
		{
			for (int i = 0;i < _points.Length; i++)
			{
				yield return _points[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}
	}
}
