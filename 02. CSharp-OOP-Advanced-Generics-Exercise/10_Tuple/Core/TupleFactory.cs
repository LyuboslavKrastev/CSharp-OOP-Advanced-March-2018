using System;

public class TupleFactory
{
    public Tuple<int, double> GetNumbersTuple(string[] input)
    {
        var firstElement = int.Parse(input[0]);
        var secondElement = double.Parse(input[1]);

        return new Tuple<int, double>(firstElement, secondElement);
    }

    public Tuple<string, string> GetStringTuple(string[] input)
    {

        switch (input.Length)
        {
            case 2:
                var firstElement = input[0];
                var secondElement = input[1];
                return new Tuple<string, string>(firstElement, secondElement);
            case 3:
                firstElement = $"{input[0]} {input[1]}";
                secondElement = input[2];
                return new Tuple<string, string>(firstElement, secondElement);
            default:
                throw new ArgumentException("Invalid input length.");
        }
    }
}

