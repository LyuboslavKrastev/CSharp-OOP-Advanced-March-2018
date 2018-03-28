using System;

namespace _GenericBox.Models
{
    public class Box<T> : IComparable<Box<T>>
        where T: IComparable<T>
    {
        private T value;

        public Box(T value)
        {
            this.value = value;
        }

        public int CompareTo(Box<T> other)
        {
            return this.value.CompareTo(other.value);
        }

        public override string ToString()
        {
            return $"{this.value.GetType().FullName}: {value}";
        }
    }
}
