using System;
using System.Collections;

namespace TrainingCenter.EnumerableDemo
{
    /// <summary>
    /// Простой аналог класса System.Collections.Generic&lt;T&gt; поддерживающий только строки
    /// Обобщенный вариант данного класса смотрите в проекте 03-MyList
    /// </summary>
    class MyList : IEnumerable
    {
        #region Основные члены класса

        string[] items;
        int count;

        public int Count { get { return count; } }
        public int Capacity { get { return items.Length; } }

        public string this[int index]
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

        public MyList()
        {
            items = Array.Empty<string>();
        }

        public void Add(string item)
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

        #region Реализация IEnumerable и IEnumerator

        public IEnumerator GetEnumerator()
        {
            return new MyListEnumerator(this);
        }

        // Вложенный класс реализующий интерфейс IEnumerator
        class MyListEnumerator : IEnumerator
        {
            MyList list;
            int index;

            public MyListEnumerator(MyList list)
            {
                this.list = list;
                index = -1;
            }

            public object Current { get { return list.items[index]; } }

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
        }

        #endregion
    }
}
