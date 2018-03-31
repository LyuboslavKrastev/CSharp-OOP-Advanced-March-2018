using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Engine
{
    private StringBuilder result;

    public Engine()
    {
        this.result = new StringBuilder();
    }

    public void Run()
    {
        var commandCount = int.Parse(Console.ReadLine());
        var pets = new List<Pet>();
        var clinics = new List<PetClinic>();

        for (int i = 0; i < commandCount; i++)
        {
            var input = Console.ReadLine().Split();

            var command = input[0];

            var commandArgs = input.Skip(1).ToArray();

            switch (command)
            {
                case "Create":
                    try
                    {
                        if (commandArgs[0] == "Pet")
                        {
                            var name = commandArgs[1];
                            var age = int.Parse(commandArgs[2]);
                            var kind = commandArgs[3];

                            var pet = new Pet(name, age, kind);
                            pets.Add(pet);
                        }
                        else
                        {
                            var roomCount = int.Parse(commandArgs[2]);
                            var clinicName = commandArgs[1];
                            var clinic = new PetClinic(clinicName, roomCount);
                            clinics.Add(clinic);
                        }
                    }
                    catch (Exception e)
                    {

                        result.AppendLine(e.Message);
                    }
                    break;

                case "Add":
                    var petName = commandArgs[0];
                    var petToAdd = pets.FirstOrDefault(p => p.Name == petName);
                    var clinicToAdd = clinics.FirstOrDefault(c => c.Name == commandArgs[1]);
                    result.AppendLine(clinicToAdd.Add(petToAdd).ToString());
                    break;

                case "Release":
                    var clinicToRelease = clinics.FirstOrDefault(c => c.Name == commandArgs[0]);
                    result.AppendLine(clinicToRelease.Release().ToString());
                    break;

                case "HasEmptyRooms":
                    var clinicTocheck = clinics.FirstOrDefault(c => c.Name == commandArgs[0]);
                    result.AppendLine(clinicTocheck.HasEmptyRooms.ToString());
                    break;
                case "Print":
                    var clinicToPrint = clinics.FirstOrDefault(c => c.Name == commandArgs[0]);
                    if (commandArgs.Length == 2)
                    {
                        var roomNumber = int.Parse(commandArgs[1]);
                        result.AppendLine(clinicToPrint.Print(roomNumber));
                    }
                    else
                    {
                        result.AppendLine(clinicToPrint.Print());
                    }
                    break;
            }
        }

        Console.WriteLine(this.result.ToString().TrimEnd());
    }
}

