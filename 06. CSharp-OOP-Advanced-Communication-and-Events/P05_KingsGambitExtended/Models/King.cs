using System;

namespace P05_KingsGambitExtended.Models
{
    public class King
    {
        private const int RoyalGuardHits = 3;

        public event EventHandler UnderAttack;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public void OnUnderAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            if (UnderAttack != null)
            {
                UnderAttack(this, new EventArgs());
            }
        }
    }
}
