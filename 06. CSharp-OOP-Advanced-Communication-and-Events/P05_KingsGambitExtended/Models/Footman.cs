using System;

namespace P05_KingsGambitExtended.Models
{
    class Footman : Soldier
    {
        

        public Footman(string name) : base(name)
        {
            this.Health = 2;
        }

        public override void KingIsUnderAttack(object sender, EventArgs ea)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
        }
    }
}
