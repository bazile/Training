using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

// TODO: Сериализация

namespace BelhardTraining.RecentListDemo
{
	/// <summary>
	/// Коллекция для хранения последних "использованных" элементов любого типа
	/// </summary>
	/// <remarks>
	/// Элементы добавляются в список с помощью метода Add(). Этот элемент 
	///		получает индекс 0. Если элемент уже был в коллекции, то он перемешается
	///		в начало. Элемент который ранее имел индекс получает индекс 1 и т.д.
	/// Размер списка ограничивается при его создании. Если при очередном вызове
	///		метода Add() выяснится, что список уже полный, то последний элемент
	///		удаляется, давая место новому. Если элемент переданный в Add() уже 
	///		есть в списке, то удаления не произойдет. Будет только произведена
	///		необходимая перестановка элементов.
	/// Удалять элементы из списка можно с помощью метода Remove()
	/// </remarks>
	/// <typeparam name="T">Тип элемента в коллекции</typeparam>
	[Serializable]
	public class RecentList<T> : ICollection, ICollection<T>, ISerializable
	{
		private readonly object syncRoot = new object();
		private readonly T[] items;
		private int used;
		private int version;
		
		/// <param name="maxSize">Максимальное количество элементов в списке. Должно быть положительным числом не равным нулю</param>
		/// <exception cref="System.ArgumentOutOfRangeException">Если максимальный размер равен нулю или меньше нуля</exception>
		public RecentList(int maxSize)
		{
			if (maxSize < 1)
				throw new ArgumentOutOfRangeException("maxSize", "Maximum size must be a non-negative non-zero number");

			items = new T[maxSize];
			used = 0;
			version = 1;
		}

		/// <summary>
		/// Возвращает элемент с указанным индексом
		/// </summary>
		/// <param name="index">Индекс элемента</param>
		/// <returns></returns>
		/// <exception cref="System.ArgumentOutOfRangeException"></exception>
		public T this[int index]
		{
			get
			{
				if (index < 0 || index >= used) throw new ArgumentOutOfRangeException("index");

				return items[index];
			}
		}

		/// <summary>
		/// Возвращает количество элементов в списке
		/// </summary>
		public int Count
		{
			get { return used; }
		}

		public object SyncRoot
		{
			get { return syncRoot; }
		}

		public bool IsSynchronized
		{
			get { return false; }
		}

		public bool IsReadOnly
		{
			get { return false; }
		}

		/// <summary>
		/// Возвращает максимальное число элементов которые можно добавить в список
		/// </summary>
		public int Capacity
		{
			get { return items.Length; }
		}

		public bool IsFull
		{
			get { return Capacity == Count; }
		}

		public bool IsEmpty
		{
			get { return Count == 0; }
		}

		public void Add(T item)
		{
			int index = Array.IndexOf(items, item, 0, used);

			// Элемент уже есть в списке и находится в начале
			// Ничего делать не нужно
			if (index == 0) return;

			if (index != -1)
			{
				// Элемент уже есть в списке
				// Требуется переместить его в начало
				Array.Copy(items, 0, items, 1, index);
				items[0] = item;
			}
			else
			{
				// Элемента нет в списке
				if (used == items.Length)
				{
					// Список полный. Избавляемся от последнего элемента
					Array.Copy(items, 0, items, 1, used-1);
					items[0] = item;
				}
				else
				{
					// Добавляем в начало, перемещая другие элементы
					if (used > 0)
					{
						Array.Copy(items, 0, items, 1, used);
					}

					items[0] = item;
					used++;
				}
			}

			unchecked
			{
				++version;
			}
		}

		void ICollection.CopyTo(Array array, int index)
		{
			Array.Copy(items, index, array, 0, used - index);
		}

		public void CopyTo(T[] array, int arrayIndex)
		{
			Array.Copy(items, arrayIndex, array, 0, used - arrayIndex);
		}

		public bool Remove(T item)
		{
			if (used == 0) return false;

			int index = Array.IndexOf(items, item, 0, used);
			if (index == -1) return false;

			items[index] = default(T);

			// Если удаленный находится не в конце, то нам нужно сдвинуть элементы в массиве
			if (index != used - 1)
			{
				Array.Copy(items, index+1, items, index, used - index - 1);
			}

			used--;
			unchecked
			{
				++version;
			}

			return true;
		}

		public void Clear()
		{
			for (int i = 0; i < items.Length; i++)
			{
				items[i] = default(T);
			}

			used = 0;
			unchecked
			{
				++version;
			}
		}
		
		public bool Contains(T item)
		{
			return (Array.IndexOf(items, item, 0, used) != -1);
		}

		#region Реализация IEnumerable и IEnumerable<T>

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new RecentListEnumerator(this);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new RecentListEnumerator(this);
		}

		#region Реализация IEnumerator<T>

		public struct RecentListEnumerator : IEnumerator<T>
		{
			private RecentList<T> list;
			private T current;
			private int version;
			private int index;

			object IEnumerator.Current { get { return current; } }
			public T Current { get { return current; } }

			internal RecentListEnumerator(RecentList<T> list)
			{
				this.list = list;
				version = list.version;
				index = 0;
				current = default(T);
			}

			public void Dispose()
			{
			}

			public bool MoveNext()
			{
				if (version != list.version)
				{
					throw new InvalidOperationException();
				}

				if (index >= list.used)
				{
					index = list.used + 1;
					current = default(T);
					return false;
				}

				current = list.items[index];
				++index;
				return true;
			}

			public void Reset()
			{
				if (version != list.version)
				{
					throw new InvalidOperationException();
				}

				index = 0;
				current = default(T);
			}
		}

		#endregion

		#endregion

		#region Поддержка сериализации

		protected RecentList(SerializationInfo info, StreamingContext context)
		{
			//int length = info.GetInt32("length");
			//items = new T[length];
			items = (T[])info.GetValue("items", typeof(T[]));
			used = info.GetInt32("used");
			version = -1;
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			//info.AddValue("length", items.Length);
			info.AddValue("used", used);
			info.AddValue("items", items);
		}

		#endregion
	}
}
