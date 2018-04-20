public abstract class Ammunition : IAmmunition
{
    private const int WearLevelMultiplier = 100;

    public string Name => this.GetType().Name;

    public abstract double Weight { get; }

    public double WearLevel { get; private set; }

    public Ammunition()
    {
        this.WearLevel = Weight * WearLevelMultiplier;
    }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}