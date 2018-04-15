using P07_InfernoInfinity.Core.Attributes;
using P07_InfernoInfinity.Interfaces;

namespace P07_InfernoInfinity.Core.Commands
{
    class PrintCommand : Command
    {
        [Inject]
        private IRepository repository;

        public PrintCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        public IRepository Repository
        {
            get => this.repository;
            private set => this.repository = value;
        }

        public override string Execute()
        {
            var weaponName = this.data[1];
            var weapon = this.Repository.GetWeapon(weaponName);

            return weapon.ToString();
        }

    }
}
