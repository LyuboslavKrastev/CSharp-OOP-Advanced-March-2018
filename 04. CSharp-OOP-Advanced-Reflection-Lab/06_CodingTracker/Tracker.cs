using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;


    public class Tracker
    {
        public void PrintMethodsByAuthor()
    {
        var type = typeof(StartUp);

        var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.Static | BindingFlags.NonPublic);

        foreach (var methodInfo in methods)
        {
            foreach (var attribute in methodInfo.GetCustomAttributes<SoftUniAttribute>())
            {
                Console.WriteLine($"{methodInfo.Name} is written by {attribute.Name}");
            }
        }
    }
    }

