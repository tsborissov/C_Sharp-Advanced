using System;
using System.Collections.Generic;
using System.Linq;

namespace _6._Reverse_and_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            numbers.Reverse();

            int divider = int.Parse(Console.ReadLine());

            Func<int, bool> isNotDivisible = new Func<int, bool>(num => num % divider != 0);

            Console.WriteLine(String.Join(' ', numbers
                .Where(isNotDivisible)
                .ToList()));
        }
    }
}
