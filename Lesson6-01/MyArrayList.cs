using System;
using System.Collections;
using System.Collections.Generic;


namespace Collections
{
    
    class MyArrayIntList<T> : ICollection<T>, IList<T>, IEnumerator<T> where T : IEquatable<T>
    {
        #region filds
        private T[] arr;
        int count = 0;
        #endregion
        #region .ctors

        /// <summary>
        /// Constructor MyArrayIntList
        /// </summary>
        /// <param name="capacity">Initial capecity of arrayList</param>
        public MyArrayIntList(int capacity = 10)
        {
            arr = new T[capacity];
        }
        #endregion

        #region Properties and Indexator

        public int Count
        {
            get => count;
        }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get => arr[index];
            set => arr[index] = value;
        }
        #endregion
        #region Methods
        public void Add(T val)
        {
            if (count == arr.Length)
            {
                T[] tmp = new T[arr.Length + arr.Length / 2 + 1];
                for (int i = 0; i < count; ++i)
                {
                    tmp[i] = arr[i];
                }
                arr = tmp;
            }
            arr[count++] = val;
        }

        public void Clear()
        {
            count = 0;
        }

        public bool Contains(T val)
        {
            for (int i = 0; i < count; ++i)
                if (arr[i].Equals(val)) return true;
            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            for (int i = 0; i < count; ++i)
                array[arrayIndex++] = arr[i];
        }

        public int IndexOf(T val)
        {
            for (int i = 0; i < count; ++i)
            {
                if (arr[i].Equals(val)) return i;
            }
            return -1;
        }

        public bool Remove(T val)
        {
            int i = IndexOf(val);
            if (i < 0) return false;
            RemoveAt(i);
            return true;
        }

        public void RemoveAt(int index)
        {
            for (++index; index < count; ++index)
            {
                arr[index - 1] = arr[index];
            }
            --count;
        }

        public void Insert(int index, T item)
        {
            if (index < 0 || index > arr.Length) throw new Exception("Index out of bounds");

            if (count == arr.Length)
            {
                T[] tmp = new T[arr.Length + arr.Length / 2 + 1];
                for (int i = 0; i < index; ++i)
                {
                    tmp[i] = arr[i];
                }

                for (int i = index; i < count; ++i)
                {
                    tmp[i + 1] = arr[i];
                }
                arr = tmp;

            }
            else
            {
                for (int i = count; i > index; --i)
                {
                    arr[i] = arr[i - 1];
                }
            }
            arr[index] = item;
            count++;
        }
        #endregion
        #region IEnumerable
        public IEnumerator<T> GetEnumerator()
        {
            return this;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        #endregion
        #region IEnumerator 
        public T Current
        {
            get => arr[currentIndex];
        }

        object IEnumerator.Current => Current;
        private int currentIndex = -1;

        public bool MoveNext()
        {
            ++currentIndex;
            return currentIndex <= count;
        }
        public void Reset()
        {
            currentIndex = -1;
        }
        public void Dispose()
        {
            Reset();
        }
        #endregion
    }
}