using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Interfaces
{
    public interface IWeapon
    {
        string WeaponName { get; }

        WeaponType WeaponType { get; }

        int MinDamageStat { get; }
        int MaxDamageStat { get; }

        IGem[] Sockets { get; }
        Rarity Rarity { get; }

        int Strength { get; }
        int Agility { get; }
        int Vitality { get; }

        void AddGem(int index, IGem gem);
        void RemoveGem(int index);

        void AddRarityBonus();
    }
}
