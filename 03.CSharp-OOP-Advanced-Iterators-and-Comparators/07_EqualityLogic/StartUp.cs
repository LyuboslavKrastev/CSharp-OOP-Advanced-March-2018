using System;
using System.Collections.Generic;

namespace _07_EqualityLogic
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var sortedPeople = new SortedSet<Person>();

            var hashsetPeople = new HashSet<Person>();

            var numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                ProcessInput(sortedPeople, hashsetPeople);
            }

            PrintCollections(sortedPeople, hashsetPeople);
        }

        private static void ProcessInput(SortedSet<Person> sortedPeople, HashSet<Person> hashsetPeople)
        {
            var input = Console.ReadLine().Split();
            var age = int.Parse(input[1]);
            var name = input[0];

            var person = new Person(name, age);

            hashsetPeople.Add(person);
            sortedPeople.Add(person);
        }

        private static void PrintCollections(SortedSet<Person> sortedPeople, HashSet<Person> hashsetPeople)
        {
            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(hashsetPeople.Count);
        }
    }
}
