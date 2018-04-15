using P07_InfernoInfinity.Models;
using P07_InfernoInfinity.Models.Attributes;
using P07_InfernoInfinity.Models.Weapons;
using System.Linq;

namespace P07_InfernoInfinity.Core.Commands
{
    public class AuthorCommand : Command
    {

        public AuthorCommand(string[] data) : base(data)
        {
        }

        public override string Execute()
        {
            var field = this.data[0];

            var weaponAtr = typeof(Weapon).GetCustomAttributes(false).FirstOrDefault();
            WeaponAttribute fieldToPrint = (WeaponAttribute)weaponAtr;

            var result = fieldToPrint.PrintInfo(field);

            return result;
        }
    }
}
