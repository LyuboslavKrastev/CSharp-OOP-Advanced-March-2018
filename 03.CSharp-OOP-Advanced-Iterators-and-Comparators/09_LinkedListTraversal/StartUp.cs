using System;

namespace _09_LinkedListTraversal
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var myLinkedList = new LinkedList<string>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                var command = input[0];
                var element = input[1];

                if (command == "Add")
                {
                    myLinkedList.Add(element);
                }
                else if (command == "Remove")
                {
                    myLinkedList.Remove(element);
                }
            }

            Console.WriteLine(myLinkedList.GetCount());
            Console.WriteLine(myLinkedList);
        }
    }
}
