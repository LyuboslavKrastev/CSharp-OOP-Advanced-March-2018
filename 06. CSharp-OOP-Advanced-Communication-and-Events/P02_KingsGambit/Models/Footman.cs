using System;
using System.Collections.Generic;
using System.Text;

namespace P02_KingsGambit.Models
{
    class Footman : Soldier
    {
        public Footman(string name) : base(name)
        {
        }

        public override void KingIsUnderAttack(object sender, EventArgs ea)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
