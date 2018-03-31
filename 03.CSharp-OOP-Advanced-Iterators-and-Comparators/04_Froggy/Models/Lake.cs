using System.Collections;
using System.Collections.Generic;

public class Lake : IEnumerable<int>
{
    private int[] stones;
    public string FrogPath => string.Join(", ", this);

    public Lake(int[] stones)
    {
        this.stones = stones;
    }

    public IEnumerator<int> GetEnumerator()
    {
        for (int i = 0; i < this.stones.Length; i += 2)
        {
            yield return this.stones[i];
        }

        var lastIndex = this.stones.Length - 1;

        if (lastIndex % 2 == 0)
        {
            lastIndex--;
        }

        for (int i = lastIndex; i > 0; i-=2)
        {
            yield return this.stones[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }


}

