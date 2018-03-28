using System;
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
        var threeupleFactory = new ThreeupleFactory();

        var input = Console.ReadLine().Split();

        var citizen = threeupleFactory.GetNameAndAddressThreeuple(input);
        result.AppendLine(citizen.ToString());

        input = Console.ReadLine().Split();

        var drunk = threeupleFactory.GetDrunkThreeuple(input);
        result.AppendLine(drunk.ToString());

        input = Console.ReadLine().Split();

        var banker = threeupleFactory.GetBankThreeuple(input);
        result.AppendLine(banker.ToString());

        Console.WriteLine(result.ToString().TrimEnd());
    }
}

