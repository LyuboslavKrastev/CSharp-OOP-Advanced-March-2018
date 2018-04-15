using P07_InfernoInfinity.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace P07_InfernoInfinity.Models
{

    public class WeaponRepository : IRepository
    {
        private List<IWeapon> weapons;

        public WeaponRepository()
        {
            this.weapons = new List<IWeapon>();
        }

        public void AddWeapon(IWeapon weapon)
        {
            this.weapons.Add(weapon);
        }

        public IWeapon GetWeapon(string weaponName)
        {
            return this.weapons.FirstOrDefault(w => w.WeaponName == weaponName);
        }

    }
}
