using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {

            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            string command = string.Empty;

            while((command = Console.ReadLine()) != "end")
            {
                Func<int, int> arithmeticFunction = command switch
                {
                    "add" => n => n + 1,
                    "multiply" => n => n * 2,
                    "subtract" => n => n - 1,
                    _ => n => n
                };

                numbers = numbers
                    .Select(arithmeticFunction)
                    .ToList();

                if (command == "print")
                {
                    Console.WriteLine(String.Join(' ', numbers));
                }
            }
        }
    }
}
