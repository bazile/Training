using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace MyVector.Generic
{
	public class Vector<T> : IEnumerable<T>
		where T : IComparable<T>
	{
		private const int GrowBy = 10;

		/// <summary>Содержимое вектора</summary>
		private T[] _values;

		#region Constructors

		/// <summary>Создает пустой Vector заданного размера</summary>
		/// <param name="initialSize">Текуший размер вектора</param>
		public Vector(int initialSize)
		{
			Size = 0;
			_values = new T[initialSize];
		}

		/// <summary>Создает Vector заданного размера заполненный указанным значением</summary>
		/// <param name="initialSize"></param>
		/// <param name="value"></param>
		public Vector(int initialSize, T value)
			: this(initialSize)
		{
			for (int i=0; i<initialSize; i++)
			{
				_values[i] = value;
			}
			Size = initialSize; // !!!
		}

		#endregion

		#region Properties

		/// <summary>Возвращает количеств элементов под которые выделена память</summary>
		public int Capacity
		{
			get { return _values.Length; }
		}

		/// <summary>Возвращает текущее количество элементов в векторе</summary>
		public int Size { get; private set; }

		/// <summary>Возвращает элемент по заданному индексу. Нумерация элементов начинается с нуля.</summary>
		/// <param name="index">Порядковый номер элемента в векторе</param>
		/// <returns></returns>
		/// <exception cref="System.IndexOutOfRangeException">Если заданный индекс выходит за пределы размеров вектора</exception>
		public T this[int index]
		{
			get
			{
				if (index<0 || index >= Size)
				{
					throw new IndexOutOfRangeException(String.Format("Index {0} is bigger than current size of {1}", index, Size));
				}

				return _values[index];
			}
			set
			{
				if (index < Size && index >= 0)
				{
					_values[index] = value;
				}
			}
		}

		#endregion

		#region Methods

		/// <summary>Добавляет переданное значение в конец вектора, увеличивая его размер при необходимости</summary>
		/// <param name="v">Число которое будет добавлено в конец вектора</param>
		public void Push(T v)
		{
			if (Size == _values.Length)
			{
				T[] values = new T[_values.Length+GrowBy];
				Array.Copy(_values, values, _values.Length);
				_values = values;
			}

			_values[Size++] = v;
		}

		/// <summary>Возвращает значение последнего элемента вектора</summary>
		/// <remarks>Размер вектора при этом уменьшается на единицу.</remarks>
		/// <returns></returns>
		/// <exception cref="System.InvalidOperationException">Если вектор пуст</exception>
		public T Pop()
		{
			if (Size == 0)
			{
				throw new InvalidOperationException("Vector is empty");
			}

			return _values[Size--];
		}

		#endregion

		#region Operators

		public static bool operator==(Vector<T> a, Vector<T> b)
		{
			return AreEquals(a, b);
		}

		public static bool operator!=(Vector<T> a, Vector<T> b)
		{
			return !AreEquals(a, b);
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
			Vector<T> other = obj as Vector<T>;
			if (other == null) return false;

			return AreEquals(this, other);
		}

		private static bool AreEquals(Vector<T> a, Vector<T> b)
		{
			if (ReferenceEquals(a, b)) return true;

			// Мы не можем использовать здесь конструкцию if (a==null || b==null) т.к. это приведет к зацикливанию программы
			if (ReferenceEquals(a, null)) return false;
			if (ReferenceEquals(b, null)) return false;

			if (a.Size != b.Size) return false;

			for (int i=0; i<a.Size; i++)
			{
				if (a[i].CompareTo(b[i]) != 0) return false;
			}

			return true;
			
		}

		/// <summary>Расчет хеш-кода</summary>
		/// <remarks>http://stackoverflow.com/a/263416</remarks>
		/// <returns></returns>
		public override int GetHashCode()
		{
			unchecked // Игнорируем переполнение
			{
				// Два "случайных" простых числа
				const int multiplier = 13;
				int hash = 1427;

				Debug.Assert(_values != null);
				
				foreach (T t in _values)
				{
					hash = hash*multiplier + t.GetHashCode();
				}
				
				return hash;
			}
		}

		#endregion

		#region IEnumerable<T> implementation

		public IEnumerator<T> GetEnumerator()
		{
			for (int i = 0; i < _values.Length; i++)
			{
				yield return _values[i];
			}
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return GetEnumerator();
		}

		#endregion
	}
}
