using System;
using System.Collections;
using System.Collections.Generic;

namespace BelhardTraining.Collections
{
    public class CircularArray<T> : IEnumerable<T>
    {
        T[] _items;
        int _headIdx;
        bool _isFull;

        public CircularArray(int size)
        {
            _items = new T[size];
        }

        public T this[int index]
        {
            get
            {
                if (index >= Count) throw new IndexOutOfRangeException();

                if (_isFull && _headIdx != 0) index = (index + _headIdx) % _items.Length;
                return _items[index];
            }
        }

        public int Count
        {
            get { return _isFull ? _items.Length : _headIdx; }
        }

        public void Clear()
        {
            _headIdx = 0;
            _isFull = false;
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i] = default(T);
            }
        }

        public void Add(T item)
        {
            _items[_headIdx++] = item;
            if (_headIdx == _items.Length)
            {
                _headIdx = 0;
                _isFull = true;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = _headIdx; i < Count; i++)
            {
                yield return _items[i];
            }
            for (int i = 0; i < _headIdx && i < Count; i++)
            {
                yield return _items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    //public class CircularArray<T> : IList<T>
    //{
    //    T[] _items;
    //    int _headIdx;
    //    bool _isFull;

    //    public CircularArray(int size)
    //    {
    //        _items = new T[size];
    //    }

    //    public T this[int index]
    //    {
    //        get
    //        {
    //            if (index >= Count) throw new IndexOutOfRangeException();

    //            if (_isFull && _headIdx != 0) index = (index + _headIdx)%_items.Length;
    //            return _items[index];
    //        }
    //        set { throw new NotSupportedException(); }
    //    }

    //    public int Count
    //    {
    //        get { return _isFull ? _items.Length : _headIdx; }
    //    }

    //    public bool IsReadOnly { get { return false; } }

    //    void ICollection<T>.Add(T item)
    //    {
    //        Push(item);
    //    }

    //    public void Clear()
    //    {
    //        _headIdx = 0;
    //        _isFull = false;
    //        for (int i = 0; i < _items.Length; i++)
    //        {
    //            _items[i] = default(T);
    //        }
    //    }

    //    public bool Contains(T item)
    //    {
    //        if (Count == 0) return false;
    //        return (-1 != Array.IndexOf(_items, item, 0, Count));
    //    }

    //    public void CopyTo(T[] array, int startIndex)
    //    {
    //        if (array == null) throw new ArgumentNullException("array");
    //        if (startIndex + Count > array.Length) throw new ArgumentOutOfRangeException("startIndex");

    //        if (!_isFull || (_isFull && _headIdx == 0))
    //        {
    //            Array.Copy(_items, 0, array, startIndex, Count);
    //        }
    //        else
    //        {
    //            for (int srcIdx = _headIdx, destIdx = 0; destIdx < Count; destIdx++, srcIdx = (srcIdx + 1)%Count)
    //            {
    //                array[destIdx] = _items[srcIdx];
    //            }
    //        }
    //    }

    //    IEnumerator IEnumerable.GetEnumerator()
    //    {
    //        return GetEnumerator();
    //    }

    //    public IEnumerator<T> GetEnumerator()
    //    {
    //        return new CircularArrayEnumerator<T>(this);
    //    }

    //    public int IndexOf(T item)
    //    {
    //        if (!_isFull || (_isFull && _headIdx == 0))
    //        {
    //            return Array.IndexOf(_items, item, 0, Count);
    //        }
    //        for (int srcIdx = _headIdx, idx = 0; idx < Count; idx++, srcIdx = (srcIdx + 1) % Count)
    //        {
    //            if (Equals(item, _items[srcIdx])) return idx;
    //        }
    //        return -1;
    //    }

    //    public void Push(T item)
    //    {
    //        _items[_headIdx++] = item;
    //        if (_headIdx == _items.Length)
    //        {
    //            _headIdx = 0;
    //            _isFull = true;
    //        }
    //    }

    //    #region Not supported members

    //    bool ICollection<T>.Remove(T item)
    //    {
    //        throw new NotSupportedException();
    //    }

    //    void IList<T>.Insert(int index, T item)
    //    {
    //        throw new NotSupportedException();
    //    }

    //    void IList<T>.RemoveAt(int index)
    //    {
    //        throw new NotSupportedException();
    //    }

    //    #endregion

    //    class CircularArrayEnumerator<TIter> : IEnumerator<TIter>
    //    {
    //        TIter[] _orderedItems;
    //        int _currIdx;

    //        public CircularArrayEnumerator(CircularArray<TIter> array)
    //        {
    //            _currIdx = -1;
    //            _orderedItems = new TIter[array.Count];
    //            array.CopyTo(_orderedItems, 0);
    //        }

    //        public TIter Current { get { return _orderedItems[_currIdx]; } }

    //        object IEnumerator.Current
    //        {
    //            get { return Current; }
    //        }

    //        public bool MoveNext()
    //        {
    //            _currIdx++;
    //            return _currIdx < _orderedItems.Length;
    //        }

    //        public void Reset()
    //        {
    //            _currIdx = -1;
    //        }

    //        public void Dispose()
    //        {
    //            _orderedItems = null;
    //        }
    //    }
    //}
}
