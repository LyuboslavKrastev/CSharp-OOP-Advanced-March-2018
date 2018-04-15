using System;
using System.Text;

namespace P03_DependencyInversion
{
    class StartUp
    {
        static void Main(string[] args)
        {
            PrimitiveCalculator calculator = new PrimitiveCalculator();       
            StringBuilder result = new StringBuilder();

            string input;

            while ((input = Console.ReadLine()) != "End")
            {
                string[] inputArgs = input.Split();

                if (inputArgs[0] == "mode")
                {
                    char @operator = char.Parse(inputArgs[1]);

                    calculator.changeStrategy(@operator);
                }
                else
                {
                    int firstOperand = int.Parse(inputArgs[0]);
                    int secondOperand = int.Parse(inputArgs[1]);

                    int calculation = calculator.performCalculation(firstOperand, secondOperand);

                    result.AppendLine(calculation.ToString());
                }
            }

            Console.WriteLine(result.ToString().TrimEnd());
        }
    }
}
