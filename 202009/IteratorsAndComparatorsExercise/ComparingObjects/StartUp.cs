using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] personDetails = input
                    .Split()
                    .ToArray();

                string name = personDetails[0];
                int age = int.Parse(personDetails[1]);
                string town = personDetails[2];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            int targetPosition = int.Parse(Console.ReadLine());
            targetPosition--;

            int countOfMatches = 1;

            Person targetPerson = people[targetPosition];

            foreach (var person in people)
            {
                if (person.CompareTo(targetPerson) == 0 && !person.Equals(targetPerson))
                {
                    countOfMatches++;
                }
            }

            if (countOfMatches == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{countOfMatches} {people.Count - countOfMatches} {people.Count}");
            }
        }
    }
}
