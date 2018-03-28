using System;
using System.Collections;
using System.Collections.Generic;

namespace _CustomList.Models
{
    public class CustomList<T> : IEnumerable<T> where T : IComparable<T>
    {
        private T[] data;

        public CustomList()
        {
            this.data = new T[0];
        }

        public CustomList(int initialSize)
        {
            this.data = new T[initialSize];
        }

        public bool isEmpty => this.Count == 0;

        public int Capacity => this.data.Length;

        public int Count { get; private set; }

        // Indexer property so we can iterate trough the collection.
        public T this[int index] 
        {
            get
            {
                return this.data[index];
            }
            set
            {
                this.data[index] = value;
            }
        } 

        public void Add(T element)
        {
            int newDataSize = this.isEmpty ? 4 : this.Capacity * 2;
            this.Count++;

            if (this.Count > this.Capacity)
            {               
                T[] newData = new T[newDataSize];
                Array.Copy(this.data, newData, this.Capacity);
                this.data = newData;
            }

          
            this.data[this.Count - 1] = element;
        }

        public T Remove(int index)
        {
            this.Count--;
            this.ValidateIndex(index);
            T element = this.data[index];

            for (int i = index; i < this.Count; i++)
            {
                this.data[i] = this.data[i + 1];
            }

            this.data[this.Count] = default(T);

            if (this.Count < (this.Capacity / 3))
            {
                T[] newData = new T[this.Capacity / 2];
                Array.Copy(this.data, newData, this.Count);
                this.data = newData;
            }

            return element;
        }

        public bool Contains(T element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Equals(element))
                {
                    return true;
                }
            }
            return false;
        }

        public void Swap(int indexA, int indexB)
        {
            T temp = this.data[indexA];
           this.ValidateIndex(indexA);
           this.ValidateIndex(indexB);
            this.data[indexA] = this.data[indexB];
            this.data[indexB] = temp;
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index> this.Count -1)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public int CountGreaterThan(T element)
        {
            var counter = 0;

            for (int i = 0; i < this.Count; i++)
            {
                T currentElement = this.data[i];
                if (currentElement.CompareTo(element) == 1)
                {
                    counter++;
                }
            }
            return counter;
        }

        public T Min()
        {
            CheckIfEmpty();

            T minElement = this.data[0];

            for (int i = 1; i < this.Count; i++)
            {
                T currentElement = this.data[i];
                if (currentElement.CompareTo(minElement) == -1)
                {
                    minElement = currentElement;
                }
            }
            return minElement;
        }

        public T Max()
        {
            CheckIfEmpty();
            T maxElement = this.data[0];

            for (int i = 1; i < this.Count; i++)
            {
                T currentElement = this.data[i];
                if (currentElement.CompareTo(maxElement) == 1)
                {
                    maxElement = currentElement;
                }
            }
            return maxElement;
        }

        public void Sort()
        {
            Array.Sort(this.data, 0, this.Count);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.Count; i++)
            {
                yield return this.data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void CheckIfEmpty()
        {
            if (this.isEmpty)
            {
                throw new InvalidOperationException("The list is empty.");
            }
        }
    }
}
