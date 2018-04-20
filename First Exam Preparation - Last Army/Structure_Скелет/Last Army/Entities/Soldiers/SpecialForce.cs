using System.Collections.Generic;

public class SpecialForce : Soldier
{
    private const double overallSkillMiltiplier = 3.5;
    private const int regenerationIncrease = 30;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };

    protected override List<string> WeaponsAllowed => this.weaponsAllowed;

    protected override int RegenerationIncrease => regenerationIncrease;

    protected override double OverallSkillMultiplier => overallSkillMiltiplier;

    public SpecialForce(string name, int age, double experience, double endurance)
        : base(name, age, experience, endurance)
    {
    }
}
