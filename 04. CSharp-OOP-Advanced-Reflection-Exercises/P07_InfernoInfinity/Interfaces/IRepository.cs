namespace P07_InfernoInfinity.Interfaces
{
    public interface IRepository
    {
        void AddWeapon(IWeapon weapon);
        IWeapon GetWeapon(string weaponName);
    }
}
