using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course.Task11
{
    class MyList<T> : IList<T>
    {
        private List<T> myList;

        public MyList(List<T> myList)
        {
            this.myList = myList;
        }

        public MyList()
        {
            myList = new List<T>();
        }

        public T this[int index]
        {
            get
            {
                if (index < myList.Count && index >= 0)
                {
                    return myList[index];
                }
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (index < myList.Count && index >= 0)
                {
                    myList[index] = value;
                }
                throw new IndexOutOfRangeException();
            }
        }

        public void Sort(Comparer<T> comparer)
        {
            myList.Sort(comparer);
        }

        private int FindIndex(int left, int right, T item, Comparer<T> comparer)
        {
            if (right - left <= 0)
            {
                return myList[left].Equals(item) ? left : -1;
            }

            int middle = (left + right) / 2;

            if (myList[left].Equals(item))
            {
                return middle;
            }

            if (comparer.Compare(item, myList[left]) < 0)
            {
                right = middle;
            }
            else
            {
                left = middle;
            }
            return FindIndex(left, right, item, comparer);
        }

        public int FindIndex(T item, Comparer<T> comparer)
        {
            int left = 0;
            int right = myList.Count;

            myList.Sort();

            return FindIndex(left, right, item, comparer);
        }

        public int Count => myList.Count;

        public bool IsReadOnly => throw new NotImplementedException();

        public void AddRange(IEnumerable<T> collection)
        {
            myList.AddRange(collection);
        }

        public void Add(T item) => myList.Add(item);
        public void Clear() => myList.Clear();

        public bool Contains(T item)
        {
            return myList.Contains(item);
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            myList.CopyTo(array, arrayIndex);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return myList.GetEnumerator();
        }

        public int IndexOf(T item)
        {
            return myList.IndexOf(item);
        }

        public void Insert(int index, T item)
        {
            myList.Insert(index, item);
        }

        public bool Remove(T item)
        {
            return myList.Remove(item);
        }

        public void RemoveAt(int index)
        {
            myList.RemoveAt(index);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return myList.GetEnumerator();
        }

        public override string ToString()
        {
            string result = "";
            foreach (T item in myList)
                result += item.ToString() + " ";
            return result;
        }
    }
}
