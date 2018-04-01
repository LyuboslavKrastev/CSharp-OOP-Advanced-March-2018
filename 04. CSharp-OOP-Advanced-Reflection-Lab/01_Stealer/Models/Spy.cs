﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;


public class Spy
{
    public string StealFieldInfo(string className, params string[] fieldNames)
    {
        Type classType = Type.GetType(className);
        FieldInfo[] classFields = classType
            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });

        sb.AppendLine($"Class under investigation: {className}");

        foreach (FieldInfo field in classFields.Where(f => fieldNames.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().TrimEnd();
    }
}


