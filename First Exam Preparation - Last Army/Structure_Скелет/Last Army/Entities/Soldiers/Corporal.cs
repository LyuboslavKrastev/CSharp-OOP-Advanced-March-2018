
using System.Collections.Generic;

public class Corporal : Soldier
{
    private const double overallSkillMiltiplier = 2.5;

    private readonly List<string> weaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "Helmet",
            "Knife",
        };

    protected override double OverallSkillMultiplier => overallSkillMiltiplier;

    protected override List<string> WeaponsAllowed => this.weaponsAllowed;

    public Corporal(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
    }
}

