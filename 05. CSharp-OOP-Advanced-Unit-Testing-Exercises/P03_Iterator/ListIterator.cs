using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator
{
    private List<string> collection;

    private int internalIndex;

    public ListyIterator(ICollection<string> collection)
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

