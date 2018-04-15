using P07_InfernoInfinity.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace P07_InfernoInfinity.Core.Factories
{
    public class GemFactory
    {
        public IGem Create(string typeOfGem, string clarity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == typeOfGem);

            if (type == null)
            {
                throw new ArgumentException("Invalid Gem Type!");
            }

            if (!typeof(IGem).IsAssignableFrom(type))
            {
                throw new ArgumentException($"{typeOfGem} is not a Gem Type!");
            }

            var instance = (IGem)Activator.CreateInstance(type, clarity);

            return instance;
        }
    }
}
