using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Filter_by_Age
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<Person>();

            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var name = tokens[0];
                var age = int.Parse(tokens[1]);

                persons.Add(new Person
                {
                    Name = name,
                    Age = age
                });
            }

            var filterText = Console.ReadLine();
            var filterAge = int.Parse(Console.ReadLine());

            Func<Person, bool> filterFunc = filterText switch
            {
                "younger" => p => p.Age < filterAge,
                "older" => p => p.Age >= filterAge,
                _ => p => true
            };

            var outputFormat = Console.ReadLine();

            Func<Person, string> formatFunc = outputFormat switch
            {
                "name" => p => p.Name,
                "age" => p => p.Age.ToString(),
                "name age" => p => $"{p.Name} - {p.Age.ToString()}",
                _ => null
            };

            var sortingFormat = Console.ReadLine(); // sort by: name or age

            Func<Person, string> sortingFunc = sortingFormat switch
            {
                "age" => p => p.Age.ToString(),
                _ => p => p.Name
            };

            persons
                .Where(filterFunc)
                .OrderBy(sortingFunc)
                .Select(formatFunc)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
}
