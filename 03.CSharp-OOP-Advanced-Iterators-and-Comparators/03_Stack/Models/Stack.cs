using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class Stack<T> : IEnumerable<T>
{
    private List<T> innerCollection;

    public Stack()
    {
        this.innerCollection = new List<T>();
    }

    public Stack(ICollection<T> collection)
    {
        this.innerCollection = collection.ToList();
    }

    public void Push(params T[] elements)
    {
        innerCollection.AddRange(elements);
    }

    public T Pop()
    {
        if (!this.innerCollection.Any())
        {
            throw new InvalidOperationException("No elements");
        }
        var index = innerCollection.Count - 1;
        var element = innerCollection[index];
        innerCollection.RemoveAt(index);

        return element;
    }
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = innerCollection.Count-1; i >= 0; i--)
        {
            yield return innerCollection[i];
        }
        for (int i = innerCollection.Count-1; i >= 0; i--)
        {
            yield return innerCollection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

