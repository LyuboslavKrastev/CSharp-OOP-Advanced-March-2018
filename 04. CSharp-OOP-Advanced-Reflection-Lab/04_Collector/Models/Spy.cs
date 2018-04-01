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

    public string CollectGettersAndSetters(string className)
    {
        Type classType = Type.GetType(className);

        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("get")))
        {
            stringBuilder.AppendLine($"{method.Name} will return {method.ReturnType}");
        }
        foreach (MethodInfo method in classMethods.Where(m => m.Name.StartsWith("set")))
        {
            stringBuilder.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
        }

        return stringBuilder.ToString().TrimEnd();
    }

    public string AnalyzeAcessModifiers(string className)
    {
        Type classType = Type.GetType(className);

        FieldInfo[] classFields = classType
            .GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (FieldInfo field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }
        foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }
        foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");
        }


        return sb.ToString().TrimEnd();
    }

    public string RevealPrivateMethods(string className)
    {
        Type classType = Type.GetType(className);
        MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        sb.AppendLine($"All Private Methods of Class: {className}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (MethodInfo method in classMethods)
        {
            sb.AppendLine(method.Name);
        }

        return sb.ToString().TrimEnd();
    }
}


