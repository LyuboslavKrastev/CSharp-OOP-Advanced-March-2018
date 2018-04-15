using P07_InfernoInfinity.Models.Gems;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Sword : Weapon
    {
        public Sword(string weaponType, string rarity, string name)
            : base(weaponType, rarity, name)
        {
            this.MinDamageStat = 4;
            this.MaxDamageStat = 6;
            this.Sockets = new Gem[3];
            this.AddRarityBonus();
        }
    }
}
