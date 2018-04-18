using Forum.App.Contracts;
using System;
using System.Linq;
using System.Reflection;

namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;

        public MenuFactory(IServiceProvider serviceProvide)
        {
            this.serviceProvider = serviceProvide;
        }

        public IMenu CreateMenu(string menuName)
        {
            Type menuType = Assembly.GetExecutingAssembly()
                .GetTypes().FirstOrDefault(t => t.Name == menuName);

            if (menuType == null)
            {
                throw new ArgumentException($"{menuType} not found!");
            }


            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuName} is not a IMenu!!");
            }

            ParameterInfo[] constructorParams = menuType
                .GetConstructors().First()
                .GetParameters();

            object[] arguments = new object[constructorParams.Length];

            for (int i = 0; i < constructorParams.Length; i++)
            {
                arguments[i] = this.serviceProvider.GetService(constructorParams[i].ParameterType);
            }

            IMenu menu = (IMenu)Activator.CreateInstance(menuType, arguments);

            return menu;
        }
    }
}
