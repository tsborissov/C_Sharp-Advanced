using System;
using System.Linq;

namespace _2._Sum_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, int> funcIntParse = n => int.Parse(n);

            int[] numbers = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(funcIntParse)
                .ToArray();

            Console.WriteLine(numbers.Length);
            Console.WriteLine(numbers.Sum());

        }
    }
}
