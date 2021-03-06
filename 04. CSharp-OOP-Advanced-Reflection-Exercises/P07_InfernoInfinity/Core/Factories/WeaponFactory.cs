﻿using P07_InfernoInfinity.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace P07_InfernoInfinity.Core.Factories
{
    public class WeaponFactory
    {
        public IWeapon Create(string weaponType, string rarity, string name)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type type = assembly.GetTypes().FirstOrDefault(t => t.Name == weaponType);

            if (type == null)
            {
                throw new ArgumentException("Invalid Weapon Type!");
            }

            if (!typeof(IWeapon).IsAssignableFrom(type))
            {
                throw new ArgumentException($"{weaponType} is not a Weapon Type!");
            }

            var instance = (IWeapon)Activator.CreateInstance(type, weaponType, rarity, name);

            return instance;
        }
    }
}
