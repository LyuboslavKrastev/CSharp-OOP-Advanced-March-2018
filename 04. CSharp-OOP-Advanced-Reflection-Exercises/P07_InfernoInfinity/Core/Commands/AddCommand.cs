using P07_InfernoInfinity.Core.Attributes;
using P07_InfernoInfinity.Core.Factories;
using P07_InfernoInfinity.Interfaces;
using System.Linq;

namespace P07_InfernoInfinity.Core.Commands
{
    public class AddCommand : Command
    {
        [Inject]
        private GemFactory gemFactory;
        [Inject]
        private IRepository repository;

        public AddCommand(string[] data, GemFactory gemFactory, IRepository repository)
            : base(data)
        {
            this.GemFactory = gemFactory;
            this.Repository = repository;
        }

        protected IRepository Repository
        {
            get => repository;
            private set => repository = value;
        }

        protected GemFactory GemFactory
        {
            get => gemFactory;
            private set => gemFactory = value;
        }

        public override string Execute()
        {
            string nameOfWeapon = this.data[1];
            int index = int.Parse(this.data[2]);

            string claryty = this.data[3].Split().First();
            string gemType = this.data[3].Split().Last();
            IGem gemToAdd = this.GemFactory.Create(gemType, claryty);

            var weapon = this.Repository.GetWeapon(nameOfWeapon);
            weapon.AddGem(index, gemToAdd);

            return string.Empty;
        }
    }
}
