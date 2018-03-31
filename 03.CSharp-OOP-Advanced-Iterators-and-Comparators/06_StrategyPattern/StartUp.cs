using System;
using System.Collections.Generic;

namespace _06_StrategyPattern
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var peopleNames = new SortedSet<Person>(new PersonNameComparer());

            var peopleAges = new SortedSet<Person>(new PersonAgeComparer());

            var numberOfPeople = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfPeople; i++)
            {
                ProcessInput(peopleNames, peopleAges);
            }

            PrintCollections(peopleNames, peopleAges);
        }

        private static void ProcessInput(SortedSet<Person> peopleNames, SortedSet<Person> peopleAges)
        {
            var input = Console.ReadLine().Split();
            var age = int.Parse(input[1]);
            var name = input[0];

            var person = new Person(name, age);

            peopleAges.Add(person);
            peopleNames.Add(person);
        }

        private static void PrintCollections(SortedSet<Person> peopleNames, SortedSet<Person> peopleAges)
        {
            Console.WriteLine(string.Join(Environment.NewLine, peopleNames));
            Console.WriteLine(string.Join(Environment.NewLine, peopleAges));
        }
    }
}
