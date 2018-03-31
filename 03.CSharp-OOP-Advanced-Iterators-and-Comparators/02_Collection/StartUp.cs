using System;
using System.Linq;

namespace _02_Collection
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var command = Console.ReadLine();

            var collection = command.Split().Skip(1).ToArray(); // The First Command will always be "Create"

            var listyIterator = new ListyIterator<string>(collection);

            while ((command = Console.ReadLine()) != "END")
            {

                switch (command)
                {
                    case "Print":
                        try
                        {
                            listyIterator.Print();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                    case "PrintAll":
                        try
                        {
                            listyIterator.PrintAll();
                        }
                        catch (InvalidOperationException ioe)
                        {
                            Console.WriteLine(ioe.Message);
                        }
                        break;
                    case "Move":
                        Console.WriteLine(listyIterator.Move());
                        break;
                    case "HasNext":
                        Console.WriteLine(listyIterator.HasNext());
                        break;
                }
            }
        }
    }
}
