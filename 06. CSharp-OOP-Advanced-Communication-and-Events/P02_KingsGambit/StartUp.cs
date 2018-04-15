using P02_KingsGambit.Model;
using P02_KingsGambit.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace P02_KingsGambit
{
    class StartUp
    {
        static void Main()
        {
            

            List<Soldier> defenders = new List<Soldier>();

                King king = new King(Console.ReadLine());
                string[] royalGuards = Console.ReadLine().Split();

                foreach (var royalGuardName in royalGuards)
                {
                    RoyalGuard royalGuard = new RoyalGuard(royalGuardName);
                    defenders.Add(royalGuard);
                    king.UnderAttack += royalGuard.KingIsUnderAttack;
                }
                string[] footmen = Console.ReadLine().Split();

                foreach (var footmanName in footmen)
                {
                    Footman footman = new Footman(footmanName);
                    defenders.Add(footman);
                    king.UnderAttack += footman.KingIsUnderAttack;
                }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] commandArgs = input.Split();
                string command = commandArgs[0];
                commandArgs = commandArgs.Skip(1).ToArray();
                InterpretCommand(defenders, king, commandArgs, command);
            }
        }

        private static void InterpretCommand(List<Soldier> defenders, King king, string[] commandArgs, string command)
        {
            switch (command)
            {
                case "Kill":
                    Soldier soldier = defenders.FirstOrDefault(s => s.Name == commandArgs[0]);
                    king.UnderAttack -= soldier.KingIsUnderAttack;
                    defenders.Remove(soldier);
                    break;

                case "Attack":
                    king.OnUnderAttack();
                    break;
                default:
                    break;
            }
        }
    }
}
