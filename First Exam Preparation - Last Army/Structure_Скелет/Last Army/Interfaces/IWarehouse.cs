public interface IWareHouse
{
    void EquipArmy(IArmy army);
    void AddAmmunition(string ammunitionName, int quantity);
    bool TryEquipSoldier(ISoldier soldier);
}

