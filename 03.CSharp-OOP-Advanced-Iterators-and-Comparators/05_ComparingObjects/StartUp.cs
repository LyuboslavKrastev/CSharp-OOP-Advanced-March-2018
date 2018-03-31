using System;
using System.Collections.Generic;

namespace _05_ComparingObjects
{
    class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var tokens = input.Split();
                var name = tokens[0];
                var age = int.Parse(tokens[1]);
                var town = tokens[2];

                var person = new Person(name, age, town);

                people.Add(person);
            }

            var personIndex = int.Parse(Console.ReadLine()) - 1;
            var personToCompare = people[personIndex];

            var matches = 0;

            foreach (var person in people)
            {
                if (person.CompareTo(personToCompare) == 0)
                {
                    matches++;
                }
            }

            if (matches > 1)
            {
                Console.WriteLine($"{matches} {people.Count  - matches} {people.Count}");
            }
            else
            {
                Console.WriteLine("No matches");
            }
        }
    }
}
