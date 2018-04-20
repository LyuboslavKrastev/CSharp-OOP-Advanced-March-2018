using System;
using System.Linq;
using System.Reflection;

public class MissionFactory : IMissionFactory
{
    public IMission CreateMission(string difficultyLevel, double neededPoints)
    {
        Type missionType = Assembly.GetCallingAssembly() //Assembly.GetCallingAssembly() е необходимо АКО НЕ СА ИЗТРИТИ NAMESPACES
        .GetTypes().FirstOrDefault(t => t.Name == difficultyLevel);

        if (missionType == null)
        {
            throw new ArgumentException($"{difficultyLevel} is not a valid Mission type!");
        }

        if (!typeof(IMission).IsAssignableFrom(missionType))
        {
            throw new InvalidOperationException($"{difficultyLevel} does not inherit IMission!");
        }

        // Type ammunitionType = Type.GetType(name); АКО СА ИЗТРИТИ NAMESPACES

        IMission mission = (IMission)Activator
            .CreateInstance(missionType, neededPoints);

        return mission;
    }
}

