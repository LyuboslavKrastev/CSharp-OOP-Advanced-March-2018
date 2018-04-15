using System;
using System.Collections.Generic;
using System.Text;

namespace P02_KingsGambit.Models
{
    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) : base(name)
        {
        }

        public override void KingIsUnderAttack(object sender, EventArgs ea)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }
    }
}
