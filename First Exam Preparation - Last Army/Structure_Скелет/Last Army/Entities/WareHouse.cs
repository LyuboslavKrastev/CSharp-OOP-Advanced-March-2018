using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitionQuantities;
    private IAmmunitionFactory ammunitionFactory;

    public WareHouse()
    {
        this.ammunitionQuantities = new Dictionary<string, int>();
        this.ammunitionFactory = new AmmunitionFactory();
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            this.TryEquipSoldier(soldier);
        }
    }

    public bool TryEquipSoldier(ISoldier soldier)
    {
        var missingWeapons = soldier.Weapons.Where(w => w.Value == null)
            .Select(w => w.Key).ToList();
        bool isSoldierEquiped = true;

        foreach (var weapon in missingWeapons)
        {
            if (this.ammunitionQuantities.ContainsKey(weapon) &&
                    ammunitionQuantities[weapon] > 0)
            {
                IAmmunition newWeapon = this.ammunitionFactory.CreateAmmunition(weapon);
                soldier.Weapons[weapon] = newWeapon;
                this.ammunitionQuantities[weapon]--;
            }
            else
            {
                isSoldierEquiped = false;
            }
        }

        return isSoldierEquiped;
    }

    public void AddAmmunition(string ammunitionName, int quantity)
    {
        if (ammunitionQuantities.ContainsKey(ammunitionName))
        {
            ammunitionQuantities[ammunitionName] += quantity;
        }
        else
        {
            ammunitionQuantities.Add(ammunitionName, quantity);
        }
    }
}

