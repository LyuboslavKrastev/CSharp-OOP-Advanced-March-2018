using _CustomList.Models;
using System;
using System.Text;


public class Engine
{
    private StringBuilder result;

    public Engine()
    {
        result = new StringBuilder();
    }

    public void Run()
    {
        string input;
        var list = new CustomList<string>();
        while ((input = Console.ReadLine()) != "END")
        {
            var commandArgs = input.Split();
            var command = commandArgs[0];

            switch (command)
            {
                case "Add":
                    list.Add(commandArgs[1]);
                    break;

                case "Remove":
                    var index = int.Parse(commandArgs[1]);
                    list.Remove(index);
                    break;

                case "Contains":
                    var output = list.Contains(commandArgs[1]);
                    result.AppendLine(output.ToString());
                    break;

                case "Swap":
                    var indexA = int.Parse(commandArgs[1]);
                    var indexB = int.Parse(commandArgs[2]);
                    list.Swap(indexA, indexB);
                    break;

                case "Greater":
                    var count = list.CountGreaterThan(commandArgs[1]);
                    result.AppendLine(count.ToString());
                    break;

                case "Max":
                    var max = list.Max();
                    result.AppendLine(max.ToString());
                    break;

                case "Min":
                    var min = list.Min();
                    result.AppendLine(min.ToString());

                    break;

                case "Print":
                    foreach (var element in list)
                    {
                        result.AppendLine(element.ToString());
                    }
                    break;

                case "Sort":
                    list.Sort();
                    break;
            }
        }
        Console.WriteLine(result.ToString().TrimEnd());
    }
}

