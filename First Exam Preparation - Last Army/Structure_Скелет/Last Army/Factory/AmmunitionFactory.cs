using System;
using System.Linq;
using System.Reflection;

public class AmmunitionFactory : IAmmunitionFactory
{
    public IAmmunition CreateAmmunition(string name)
    {
        Type ammunitionType = Assembly.GetCallingAssembly() // АКО НЕ СА ИЗТРИТИ NAMESPACES
            .GetTypes().FirstOrDefault(t => t.Name == name);

        if (ammunitionType == null)
        {
            throw new ArgumentException($"{name} is not a valid Ammunition type!");
        }

        if (!typeof(IAmmunition).IsAssignableFrom(ammunitionType))
        {
            throw new InvalidOperationException($"{name} does not inherit IAmmunition!");
        }

        // Type ammunitionType = Type.GetType(name); АКО СА ИЗТРИТИ NAMESPACES

        IAmmunition ammunition = (IAmmunition)Activator
            .CreateInstance(ammunitionType);

        return ammunition;       
    }   
}