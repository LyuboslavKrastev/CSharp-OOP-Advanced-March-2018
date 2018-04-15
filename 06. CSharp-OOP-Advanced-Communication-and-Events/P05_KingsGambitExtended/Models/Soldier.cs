using System;

namespace P05_KingsGambitExtended.Models
{
    public abstract class Soldier 
    {

        public Soldier(string name)
        {
            this.Name = name;
            this.isDead = false;
        }

        protected int Health { get;  set; }

        public bool isDead;

        public string Name { get; }

        public abstract void KingIsUnderAttack(object sender, EventArgs ea);

        public void TakeDamage()
        {
            this.Health--;
            if (this.Health == 0)
            {
                this.isDead = true;
            }
        }

        //public void RespondToAttack()
        //{
        //    this.HitsLeft--;
        //    if (this.HitsLeft == 0)
        //    {

        //    }
        //}

        //protected void OnSoldierDeath(SoldierDeathEventArgs args)
        //{
        //    if (OnSoldierDeath != null)
        //    {
        //        SoldierDeath(this, args);
        //    }
        //}
    }
}
