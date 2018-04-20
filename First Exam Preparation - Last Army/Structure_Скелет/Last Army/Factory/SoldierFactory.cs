using System;
using System.Linq;
using System.Reflection;

public class SoldierFactory : ISoldierFactory
{
    public ISoldier CreateSoldier(string soldierTypeName, string name, int age, double experience, double endurance)
    {
        Type soldierType = Assembly.GetCallingAssembly() // АКО НЕ СА ИЗТРИТИ NAMESPACES
        .GetTypes().FirstOrDefault(t => t.Name == soldierTypeName);

        if (soldierType == null)
        {
            throw new ArgumentException($"{name} is not a valid Soldier type!");
        }

        if (!typeof(ISoldier).IsAssignableFrom(soldierType))
        {
            throw new InvalidOperationException($"{name} does not inherit ISoldier!");
        }

        // Type ammunitionType = Type.GetType(name); АКО СА ИЗТРИТИ NAMESPACES

        ISoldier soldier = (ISoldier)Activator
            .CreateInstance(soldierType, name, age, experience, endurance);

        return soldier;
    }
}
