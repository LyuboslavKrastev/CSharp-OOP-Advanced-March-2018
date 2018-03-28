public class Threeuple<TFirst, TSecond, TThird>
{
    private TFirst firstElement { get; }
    private TSecond secondElement { get; }
    private TThird thirdElement { get; }

    public Threeuple(TFirst firstElement, TSecond secondElement, TThird thirdElement)
    {
        this.firstElement = firstElement;
        this.secondElement = secondElement;
        this.thirdElement = thirdElement;
    }

    public override string ToString()
    {
        return $"{this.firstElement} -> {this.secondElement} -> {this.thirdElement}";
    }
}


