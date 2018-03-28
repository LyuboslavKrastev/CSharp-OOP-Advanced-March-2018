public class ThreeupleFactory
{
    public Threeuple<string, double, string> GetBankThreeuple(string[] input)
    {
        var name = input[0];
        var accountBalance = double.Parse(input[1]);
        var bankName = input[2];

        return new Threeuple<string, double, string>(name, accountBalance, bankName);
    }

    public Threeuple<string, int, bool> GetDrunkThreeuple(string[] input)
    {
        var name = input[0];
        var littersOfBeer = int.Parse(input[1]);
        var drunk = false;

        if (input[2] == "drunk")
        {
            drunk = true;
        }

        return new Threeuple<string, int, bool>(name, littersOfBeer, drunk);
    }

    public Threeuple<string, string, string> GetNameAndAddressThreeuple(string[] input)
    {
        var name = $"{input[0]} {input[1]}";
        var address = input[2];
        var town = input[3];
        return new Threeuple<string, string, string>(name, address, town);
    }
}

