using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListyIterator<T> : IEnumerable<T>
{
    private List<T> collection;

    private int internalIndex;

    public ListyIterator(ICollection<T> collection)
    {
        this.collection = collection.ToList();
    }

    public bool Move()
    {
        if (internalIndex + 1 < this.collection.Count)
        {
            internalIndex++;
            return true;
        }
        return false;
    }

    public bool HasNext()
    {
        if (internalIndex + 1 < this.collection.Count)
        {
            return true;
        }
        return false;
    }

    public void Print()
    {
        if (!this.collection.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        Console.WriteLine(collection[internalIndex]);
    }
    public void PrintAll()
    {
        if (!this.collection.Any())
        {
            throw new InvalidOperationException("Invalid Operation!");
        }
        var result = string.Join(" ", this);
        Console.WriteLine(result);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.collection.Count; i++)
        {
            yield return this.collection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}

