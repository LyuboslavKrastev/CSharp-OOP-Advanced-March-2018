using P07_InfernoInfinity.Models.Gems;

namespace P07_InfernoInfinity.Models.Weapons
{
    public class Axe : Weapon
    {
        public Axe(string weaponType, string rarity, string name)
            : base(weaponType, rarity, name)
        {
            this.MinDamageStat = 5;
            this.MaxDamageStat = 10;
            this.Sockets = new Gem[4];
            this.AddRarityBonus();
        }
    }
}
