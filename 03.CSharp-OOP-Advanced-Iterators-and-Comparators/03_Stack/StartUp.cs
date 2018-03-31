using System;
using System.Linq;

namespace _03_Stack
{
    class StartUp
    {
        static void Main(string[] args)
        {
            string input;

            var myStack = new Stack<string>();

            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                switch (command)
                {
                    case "Push":
                        var elements = tokens.Skip(1).ToArray();
                        myStack.Push(elements);
                        break;
                    case "Pop":
                        try
                        {
                            myStack.Pop();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                }
            }

            if (myStack.Any())
            {
                Console.WriteLine(string.Join(Environment.NewLine, myStack));
            }          
        }
    }
}
