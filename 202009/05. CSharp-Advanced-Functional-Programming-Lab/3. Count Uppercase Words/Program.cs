using System;
using System.Linq;

namespace _3._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {

            Func<string, bool> startUpper = n => n[0] == n.ToUpper()[0];

            string input = Console.ReadLine();

            string[] upperCaseWords = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(startUpper)
                .ToArray();

            foreach (var word in upperCaseWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
