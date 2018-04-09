using System;
using System.Collections.Generic;
using System.Linq;

namespace P01_Database
{
    public class Database
    {
        private const int DefaultCapacity = 16;
        private int[] innerCollection;
        public readonly int Capacity = DefaultCapacity;

        private int currentIndex;

        public int Count => this.currentIndex;

        public Database(IEnumerable<int> values)
        {
            this.InnerCollection = values.ToArray();
        }

        public int GetLastElement()
        {
            return this.InnerCollection[Count - 1];
        }

        public int[] InnerCollection
        {
            get
            {
                return this.innerCollection;
            }
            set
            {
                if (value.Length > 16 || value.Length < 1)
                {
                    throw new InvalidOperationException();
                }

                this.innerCollection = new int[DefaultCapacity];

                for (int i = 0; i < value.Length; i++)
                {
                    this.innerCollection[i] = value[i];
                }

                this.currentIndex = value.Length;
            }
        }

        public void Add(int element)
        {
            if (this.currentIndex == DefaultCapacity)
            {
                throw new InvalidOperationException("The Database is Full!");
            }

            this.innerCollection[currentIndex] = element;

            currentIndex++;
        }

        public void Remove()
        {
            if(this.currentIndex == 0)
            {
                throw new InvalidOperationException("The Database is Empty!");
            }

            this.innerCollection[currentIndex] = default(int);
            currentIndex--;
        }


        public int[] Fetch()
        {
            var elements = this.innerCollection;
            return elements;
        }
    }
}
