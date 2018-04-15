using System;

namespace P05_KingsGambitExtended.Models
{
    public class RoyalGuard : Soldier
    {
        public RoyalGuard(string name) : base(name)
        {
            this.Health = 3;
        }

        public override void KingIsUnderAttack(object sender, EventArgs ea)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");           
        }
    }
}
