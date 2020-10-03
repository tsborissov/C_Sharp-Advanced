using System;
using System.Linq;

namespace _1._Sort_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] evenSortedNumbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .Where(x => x % 2 == 0)
                .OrderBy(x => x)
                .ToArray();

            Console.WriteLine(string.Join(", ", evenSortedNumbers));
        }
    }
}
