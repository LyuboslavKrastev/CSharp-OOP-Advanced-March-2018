using P07_InfernoInfinity.Core.Attributes;
using P07_InfernoInfinity.Interfaces;

namespace P07_InfernoInfinity.Core.Commands
{
    class RemoveCommand : Command
    {
        [Inject]
        private IRepository repository;

        public RemoveCommand(string[] data, IRepository repository)
            : base(data)
        {
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get => repository;
            private set => repository = value;
        }

        public override string Execute()
        {
            var weaponName = this.data[1];
            var index = int.Parse(this.data[2]);
            var weapon = this.Repository.GetWeapon(weaponName);
            weapon.RemoveGem(index);
            return string.Empty;
        }
    }
}