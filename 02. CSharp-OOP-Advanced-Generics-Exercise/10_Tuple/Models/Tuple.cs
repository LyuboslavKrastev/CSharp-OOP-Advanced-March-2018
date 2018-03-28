public class Tuple<TFirst, TSecond>
{
    private TFirst firstElement { get; }
    private TSecond secondElement { get; }

    public Tuple(TFirst firstElement, TSecond secondElement)
    {
        this.firstElement = firstElement;
        this.secondElement = secondElement;
    }

    public override string ToString()
    {
        return $"{this.firstElement} -> {this.secondElement}";
    }
}


