namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory //REFLECTION FACTORY
    {
        public IUnit CreateUnit(string unitType)
        {
            Type type = Type.GetType("_03BarracksFactory.Core.Models.Units." + unitType);

            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t => t.Name == unitType);

            CheckForErrors(unitType, model);

            IUnit unit = (IUnit)Activator.CreateInstance(model);
            return unit;
        }

        private static void CheckForErrors(string unitType, Type model)
        {
            if (model == null)
            {
                throw new ArgumentException("Invalid unit type!");
            }

            if (!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{unitType} is not a valid unit type!");
            }
        }
    }
}
