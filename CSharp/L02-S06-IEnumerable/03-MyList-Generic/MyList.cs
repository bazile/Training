using System;
using System.Collections;
using System.Collections.Generic;

namespace TrainingCenter.EnumerableDemo
{
    /// <summary>
    /// Простой аналог класса System.Collections.Generic&lt;T&gt; поддерживающий только строки
    /// Отличается от варианта из проекта 02-MyList поддержкой обобщений
    /// </summary>
    class MyList<T> : IEnumerable<T>
    {
        #region Основные члены класса

        T[] items;
        int count;

        public int Count
        {
            get { return count; }
        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count) throw new ArgumentOutOfRangeException();
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count) throw new ArgumentOutOfRangeException();
                items[index] = value;
            }
        }

        public int Capacity { get { return items.Length; } }

        public MyList()
        {
            items = Array.Empty<T>();
        }

        public void Add(T item)
        {
            if (count == Capacity)
            {
                Array.Resize(ref items, Capacity == 0 ? 4 : Capacity * 2);
            }
            items[count++] = item;
        }

        public void Clear()
        {
            if (count > 0)
            {
                Array.Clear(items, 0, count);
                count = 0;
            }
        }

        #endregion

        #region Реализация IEnumerable<T> и IEnumerator<T>

        public IEnumerator<T> GetEnumerator()
        {
            return new MyListEnumerator(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        // Вложенный класс реализующий интерфейс IEnumerator
        class MyListEnumerator : IEnumerator<T>
        {
            MyList<T> list;
            int index;

            public MyListEnumerator(MyList<T> list)
            {
                this.list = list;
                index = -1;
            }

            public T Current { get { return list.items[index]; } }
            object IEnumerator.Current { get { return list.items[index]; } }

            public bool MoveNext()
            {
                if (index >= list.count - 1) return false;

                index++;
                return true;
            }

            public void Reset()
            {
                index = -1;
            }

            void IDisposable.Dispose()
            {
            }
        }

        #endregion
    }
}
