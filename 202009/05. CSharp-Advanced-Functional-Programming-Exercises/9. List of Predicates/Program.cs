using System;
using System.Collections.Generic;
using System.Linq;

namespace _9._List_of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int endOfRange = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            List<int> result = new List<int>();

            Func<int, int, bool> divisionCheck = (x, y) => x % y == 0;

            for (int i = 1; i <= endOfRange; i++)
            {
                int divisionCounter = 0;

                foreach (var divider in dividers)
                {
                    if (divisionCheck(i, divider))
                    {
                        divisionCounter++;
                    }
                }

                if (divisionCounter == dividers.Length)
                {
                    result.Add(i);
                }
            }

            Console.WriteLine(String.Join(' ', result));
        }
    }
}
