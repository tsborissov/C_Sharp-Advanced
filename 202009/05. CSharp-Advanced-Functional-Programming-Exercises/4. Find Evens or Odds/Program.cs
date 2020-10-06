using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] tokens = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = tokens[0];
            int end = tokens[1];

            string query = Console.ReadLine();

            Predicate<int> predicate = (query) == "even" ?
                new Predicate<int>(num => num % 2 == 0) :
                new Predicate<int>(num => num % 2 != 0);

            List<int> result = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (predicate(i))
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(string.Join(' ', result));
        }
    }
}
