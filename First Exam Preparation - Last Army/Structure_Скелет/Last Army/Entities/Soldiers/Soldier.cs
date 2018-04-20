using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const double maxEndurance = 100;
    private const int BaseRegenerationIncrease = 10; 
    
    private double endurance;

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public double Endurance
    {
        get { return this.endurance; }
        private set
        {
            this.endurance = Math.Min(value, maxEndurance);
        }
    }

    protected virtual int RegenerationIncrease => BaseRegenerationIncrease;

    protected abstract double OverallSkillMultiplier { get; }

    public double OverallSkill => (this.Age + this.Experience) * this.OverallSkillMultiplier;

    protected abstract List<string> WeaponsAllowed { get; }

    public IDictionary<string, IAmmunition> Weapons { get; }

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = new Dictionary<string, IAmmunition>();

        foreach (var weapon in WeaponsAllowed)
        {
            Weapons.Add(weapon, null);
        }

    }

    public void CompleteMission(IMission mission)
    {
        this.Experience += mission.EnduranceRequired;
        this.Endurance -= mission.EnduranceRequired;

        foreach (var weapon in Weapons.Values.Where(w => w != null).ToList())
        {
            weapon.DecreaseWearLevel(mission.WearLevelDecrement);

            if (weapon.WearLevel <= 0)
            {
                this.Weapons[weapon.Name] = null;
            }
        }
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasMissingEquipment = this.Weapons.Values.Any(weapon => weapon == null);

        if (hasMissingEquipment)
        {
            return false;
        }

        bool allEquipmentIsFunctional = this.Weapons.Values.All(weapon => weapon.WearLevel > 0);

        return allEquipmentIsFunctional;
    }

    public void Regenerate()
    {
        this.Endurance += this.Age + this.RegenerationIncrease;
    }

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);


    //private void AmmunitionRevision(double missionWearLevelDecrement)
    //{
    //    IEnumerable<string> keys = this.Weapons.Keys.ToList();
    //    foreach (string weaponName in keys)
    //    {
    //        this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

    //        if (this.Weapons[weaponName].WearLevel <= 0)
    //        {
    //            this.Weapons[weaponName] = null;
    //        }
    //    }
    //}
}