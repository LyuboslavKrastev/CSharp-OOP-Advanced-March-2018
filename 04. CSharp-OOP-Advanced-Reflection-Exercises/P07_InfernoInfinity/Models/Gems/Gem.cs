using P07_InfernoInfinity.Enums;
using P07_InfernoInfinity.Interfaces;
using System;

namespace P07_InfernoInfinity.Models.Gems
{
    public abstract class Gem : IGem
    {
        public Gem(string clarity)
        {
            this.Clarity = (Clarity)Enum.Parse(typeof(Clarity), clarity);
        }

        public int StrengthBonus { get; protected set; }

        public int AgilityBonus { get; protected set; }

        public int VitalityBonus { get; protected set; }

        public Clarity Clarity { get; protected set; }

        public void AddBonusFromClarity()
        {
            int bonus = (int)this.Clarity;
            this.StrengthBonus += bonus;
            this.AgilityBonus += bonus;
            this.VitalityBonus += bonus;
        }

        public int AddMaxDamageBoost()
        {
            int maxDamageBoost = (this.StrengthBonus * 3) + (this.AgilityBonus * 4);
            return maxDamageBoost;
        }

        public int AddMinDamageBoost()
        {
            int minDamageBoost = (this.StrengthBonus * 2) + (this.AgilityBonus * 1);
            return minDamageBoost;
        }
    }
}