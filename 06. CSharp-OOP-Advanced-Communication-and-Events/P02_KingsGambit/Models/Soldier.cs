using System;

namespace P02_KingsGambit.Models
{
   public abstract class Soldier
    {
        public Soldier(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public abstract void KingIsUnderAttack(object sender, EventArgs ea);
    }
}
