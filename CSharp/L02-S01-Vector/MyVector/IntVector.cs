using System;
using System.Collections.Generic;
using System.Text;

namespace MyVector
{
	/// <summary>
	/// Класс Vector дает возможность хранить произвольное количество целых чисел и считать их сумму
	/// </summary>
	/// <example>
	/// IntVector vector = new IntVector(3);
	/// vector.Push(101);
	/// vector.Push(102);
	/// vector.Push(103);
	/// int i = vector.Pop(); // i = 103;
	/// </example>
	/// <remarks>
	/// Данный класс является незаконченныи примером.
	/// Используйте классы System.Collections.ArrayList, System.Collections.Generic.List&lt;T&gt;, System.Collections.Generic.Stack&lt;T&gt;
	/// </remarks>
	public partial class IntVector : IEnumerable<int>
	{
		private const int GrowBy = 10;

		/// <summary>Содержимое вектора</summary>
		private int[] _numbers;

		private int _lastFreeIndex;

		#region Constructors

		/// <summary>Создает пустой Vector заданного размера</summary>
		/// <param name="initialSize">Текуший размер вектора</param>
		public IntVector(int initialSize)
		{
			Size = 0;
			_numbers = new int[initialSize];
		}

		/// <summary>Создает Vector заданного размера заполненный указанным значением</summary>
		/// <param name="initialSize"></param>
		/// <param name="value"></param>
		public IntVector(int initialSize, int value)
			: this(initialSize)
		{
			for (int i=0; i<initialSize; i++)
			{
				_numbers[i] = value;
			}
			Size = initialSize; // !!!
		}

		#endregion

		#region Properties

		/// <summary>Возвращает количеств элементов под которые выделена память</summary>
		public int Capacity
		{
			get { return _numbers.Length; }
		}

		/// <summary>Возвращает текущее количество элементов в векторе</summary>
		public int Size
		{
			get { return _lastFreeIndex; }
			private set { _lastFreeIndex = value; }
		}

		/// <summary>Возвращает элемент по заданному индексу. Нумерация элементов начинается с нуля.</summary>
		/// <param name="index">Порядковый номер элемента в векторе</param>
		/// <returns></returns>
		/// <exception cref="System.IndexOutOfRangeException">Если заданный индекс выходит за пределы размеров вектора</exception>
		public int this[int index]
		{
			get
			{
				if (index<0 || index >= Size)
				{
					throw new IndexOutOfRangeException(String.Format("Index {0} is bigger than current size of {1}", index, Size));
				}

				return _numbers[index];
			}
			set
			{
				if (index < Size && index >= 0)
				{
					_numbers[index] = value;
				}
			}
		}

		#endregion

		#region Methods

		/// <summary>Добавляет переданное значение в конец вектора, увеличивая его размер при необходимости</summary>
		/// <param name="v">Число которое будет добавлено в конец вектора</param>
		public void Push(int v)
		{
			if (Size == _numbers.Length)
			{
				int[] numbers = new int[_numbers.Length+GrowBy];
				Array.Copy(_numbers, numbers, _numbers.Length);
				_numbers = numbers;
			}

			_numbers[Size++] = v;
		}

		/// <summary>Возвращает значение последнего элемента вектора</summary>
		/// <remarks>Размер вектора при этом уменьшается на единицу.</remarks>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">Если вектор пуст</exception>
		public int Pop()
		{
			if (Size == 0)
			{
				throw new InvalidOperationException("Vector is empty");
			}

			return _numbers[Size--];
		}

		/// <summary>Возвращает сумму всех чисел хранящихся в векторе</summary>
		/// <returns></returns>
		public int GetSum()
		{
			int sum = 0;
			for (int i = 0; i < _numbers.Length; i++)
			{
				sum += _numbers[i];
			}
			return sum;
		}

		#endregion

		#region Operators

		public static bool operator==(IntVector a, IntVector b)
		{
			return AreEquals(a, b);
		}

		public static bool operator!=(IntVector a, IntVector b)
		{
			return !AreEquals(a, b);;
		}

		public static IntVector operator+(IntVector vector, int number)
		{
			for (int i=0; i<vector.Size; i++)
			{
				vector[i] += number;
			}
			return vector;
		}

		#endregion

		#region System.Object overrides

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("Vector with ");
			sb.AppendFormat("{0} element(s)", Size);
			return sb.ToString();
		}

		public override bool Equals(object obj)
		{
			IntVector other = obj as IntVector;
			if (other == null) return false;

			return AreEquals(this, other);
		}

		private static bool AreEquals(IntVector a, IntVector b)
		{
			if (Object.ReferenceEquals(a, b)) return true;

			// Мы не можем использовать здесь конструкцию if (a==null || b==null) т.к. это приведет к зацикливанию программы
			if (Object.ReferenceEquals(a, null)) return false;
			if (Object.ReferenceEquals(b, null)) return false;

			if (a.Size != b.Size) return false;

			for (int i=0; i<a.Size; i++)
			{
				if (a[i] != b[i]) return false;
			}

			return true;
			
		}

		//public override int GetHashCode()
		//{
		//	return base.GetHashCode();
		//}

		#endregion
	}
}
