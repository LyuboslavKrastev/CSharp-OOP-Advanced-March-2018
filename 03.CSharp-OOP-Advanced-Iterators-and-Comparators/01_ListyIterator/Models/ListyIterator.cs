using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ListyIterator<T>
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
}

