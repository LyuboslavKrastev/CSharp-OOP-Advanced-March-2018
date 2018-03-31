using System;
using System.Collections;
using System.Collections.Generic;

public class LinkedList<T> : IEnumerable<T>
{
    private class Node
    {
        public Node(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }
        public Node Next { get; set; }

    }

   private Node Head { get; set; }
   private Node Tail { get; set; }
   private int Count { get; set; }

    public int GetCount()
    {
        return this.Count;
    }

    public void Add(T item) 
    {
        Node old = this.Tail;
        this.Tail = new Node(item);

        if (IsEmpty())
        {
            this.Head = this.Tail;
        }
        else
        {
            old.Next = this.Tail;
        }

        this.Count++;
    }

    private bool IsEmpty()
    {
        if (this.Count == 0)
        {
            return true;
        }
        return false;
    }

    public bool Remove(T element) 
    {
        if (IsEmpty())
        {
            throw new InvalidOperationException();
        }

        var currentItem = this.Head;

        if (currentItem.Value.Equals(element))
        {
            if (this.Count > 1)
            {
                this.Head = currentItem.Next;
            }

            currentItem = null;

            this.Count--;
            return true;
        }

        while (currentItem.Next != null)
        {
            if (currentItem.Next.Value.Equals(element))
            {
                var left = currentItem;
                var right = currentItem.Next?.Next;

                currentItem = currentItem.Next;
                currentItem = null;

                if (right == null)
                {
                    this.Tail = left;
                    left.Next = null;
                }
                else
                {
                    left.Next = right;
                }

                this.Count--;
                return true;
            }
            else
            {
                currentItem = currentItem.Next;
            }
        }

        return false;
    }


    public IEnumerator<T> GetEnumerator()
    {
        Node current = this.Head;
        while(current != null)
        {
            yield return current.Value;
            current = current.Next;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(" ", this);
    }
}

