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
        var tupleFactory = new TupleFactory();

        for (int i = 0; i < 3; i++)
        {
            var firstElement = string.Empty;
            var secondElement = string.Empty;

            var input = Console.ReadLine().Split();

            if (int.TryParse(input[0], out int intValue))
            {
                var tuple = tupleFactory.GetNumbersTuple(input);
                this.result.AppendLine(tuple.ToString());
            }
            else
            {
                var tuple = tupleFactory.GetStringTuple(input);
                this.result.AppendLine(tuple.ToString());
            }
        }
        Console.WriteLine(result.ToString().TrimEnd());
    }
}




