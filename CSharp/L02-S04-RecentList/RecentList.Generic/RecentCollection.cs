using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;

// TODO: thread-safe версия
// TODO: read-only версию?

namespace TrainingCenter.RecentListDemo
{
	/// <summary>
	/// Коллекция для хранения последних "использованных" элементов любого типа.
	/// </summary>
	/// <remarks>
	/// Элементы добавляются в список с помощью метода Add(). Этот элемент 
	///		получает индекс 0. Если элемент уже был в коллекции, то он перемешается
	///		в начало. Элемент который ранее имел индекс 0 получает индекс 1 и т.д.
	/// Размер списка ограничивается при его создании. Если при очередном вызове
	///		метода Add() выяснится, что список уже полный, то последний элемент
	///		удаляется, давая место новому. Если элемент переданный в Add() уже 
	///		есть в списке, то удаления не произойдет. Будет только произведена
	///		необходимая перестановка элементов.
	/// Удалять элементы из списка можно с помощью метода Remove()
	/// Экземплярные методы не гарантируют потоко-безопасность
	/// </remarks>
	/// <typeparam name="T">Тип элемента в коллекции</typeparam>
	[Serializable]
	public class RecentCollection<T> : ICollection, ICollection<T>, ISerializable
	{
		private static readonly IEqualityComparer<T> comparer = EqualityComparer<T>.Default;
		private readonly object syncRoot = new object();
		private readonly T[] items;
		private int used;
		private int version;
		
		/// <param name="maxSize">Максимальное количество элементов в списке. Должно быть положительным числом не равным нулю</param>
		/// <exception cref="System.ArgumentOutOfRangeException">Если максимальный размер равен нулю или меньше нуля</exception>
		public RecentCollection(int maxSize)
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

		/// <summary>
		/// Возврашает true если список заполнен полность, иначе false
		/// </summary>
		public bool IsFull
		{
			get { return Capacity == Count; }
		}

		/// <summary>
		/// Возврашает true если в списке нет ни одного элемента, иначе false
		/// </summary>
		public bool IsEmpty
		{
			get { return Count == 0; }
		}

		/// <summary>
		/// Добавление элемента в список. Элемент становится первым в списке.
		/// Если элемент уже был в списке, то он перемешается на первое место.
		/// Если список полностью заполнен и добавляется новый элемент, то последний элемент удаляется из списка.
		/// </summary>
		/// <param name="item">Элемент который требуется добавить</param>
		public void Add(T item)
		{
			if (typeof(T).IsClass && comparer.Equals(item, default(T)))
			{
				throw new NotSupportedException();
			}

			//if (IsReadOnly)
			//{
			//    throw new NotSupportedException();
			//}

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

		/// <summary>
		/// Удаление элемента из списка
		/// </summary>
		/// <param name="item">Элемент который требуется удалить</param>
		/// <returns>true если элемент был удален, false если указанный элемент отсутствует в списке</returns>
		public bool Remove(T item)
		{
			//if (IsReadOnly)
			//{
			//    throw new NotSupportedException();
			//}

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

		/// <summary>
		/// Удаляет все элементы из списка.
		/// </summary>
		public void Clear()
		{
			//if (IsReadOnly)
			//{
			//    throw new NotSupportedException();
			//}

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

		/// <summary>
		/// Проверяет содержит ли коллекция указанный элемент
		/// </summary>
		/// <returns>
		/// true if <paramref name="item"/> is found in the <see cref="T:System.Collections.Generic.ICollection`1"/>; otherwise, false.
		/// </returns>
		/// <param name="item">The object to locate in the <see cref="T:System.Collections.Generic.ICollection`1"/>.</param>
		public bool Contains(T item)
		{
			return (Array.IndexOf(items, item, 0, used) != -1);
		}

		#region Реализация IEnumerable и IEnumerable<T>

		IEnumerator IEnumerable.GetEnumerator()
		{
			return new RecentCollectionEnumerator(this);
		}

		public IEnumerator<T> GetEnumerator()
		{
			return new RecentCollectionEnumerator(this);
		}

		#region Реализация IEnumerator<T>

		/// <summary>
		/// Реализация IEnumerator для RecentCollection
		/// </summary>
		public struct RecentCollectionEnumerator : IEnumerator<T>
		{
			private RecentCollection<T> list;
			private T current;
			private readonly int version;
			private int index;

			object IEnumerator.Current { get { return current; } }
			public T Current { get { return current; } }

			internal RecentCollectionEnumerator(RecentCollection<T> list)
			{
				this.list = list;
				version = list.version;
				index = 0;
				current = default(T);
			}

			public void Dispose()
			{
				list = null;
				current = default(T);
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

		protected RecentCollection(SerializationInfo info, StreamingContext context)
		{
			if (info == null) throw new ArgumentNullException("info");

			items = (T[])info.GetValue("items", typeof(T[]));
			used = info.GetInt32("used");
			version = -1;
		}

		public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
		{
			if (info == null) throw new ArgumentNullException("info");

			info.AddValue("used", used);
			info.AddValue("items", items);
		}

		#endregion
	}
}
