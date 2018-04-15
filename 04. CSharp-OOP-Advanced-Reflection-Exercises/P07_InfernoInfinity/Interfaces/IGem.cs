using P07_InfernoInfinity.Enums;

namespace P07_InfernoInfinity.Interfaces
{
    public interface IGem
    {
        Clarity Clarity { get; }
        int StrengthBonus { get; }
        int AgilityBonus { get; }
        int VitalityBonus { get; }

        void AddBonusFromClarity();
        int AddMinDamageBoost();
        int AddMaxDamageBoost();
    }
}
  

