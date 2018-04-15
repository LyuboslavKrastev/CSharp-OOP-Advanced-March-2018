using P07_InfernoInfinity.Core.Attributes;
using P07_InfernoInfinity.Core.Factories;
using P07_InfernoInfinity.Interfaces;
using System.Linq;


namespace P07_InfernoInfinity.Core.Commands
{
    public class CreateCommand : Command
    {
        [Inject]
        private WeaponFactory weaponFactory;
        [Inject]
        private IRepository repository;

        public CreateCommand(string[] data, WeaponFactory weaponFactory, IRepository repository)
            : base(data)
        {
            this.WeaponFactory = weaponFactory;
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get => repository;
            private set => repository = value;
        }

        protected WeaponFactory WeaponFactory
        {
            get => weaponFactory;
            private set => weaponFactory = value;
        }

        public override string Execute()
        {
            string rarity = this.data[1].Split().First();
            string weaponType = this.data[1].Split().Last();
            string name = this.data[2];
            IWeapon weaponToAdd = this.WeaponFactory.Create(weaponType, rarity, name);

            this.Repository.AddWeapon(weaponToAdd);
            return string.Empty;
        }
    }
}
