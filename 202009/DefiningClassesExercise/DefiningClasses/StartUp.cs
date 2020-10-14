using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Family people = new Family();
            
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();
                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                Person person = new Person(name, age);

                people.AddMember(person);
            }

            StringBuilder result = new StringBuilder();


            foreach (var person in people.GetPeople())
            {
                result.AppendLine($"{person.Name} - {person.Age}");
            }

            Console.WriteLine(result.ToString());
        }
    }
}
