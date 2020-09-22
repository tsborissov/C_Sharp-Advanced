using System;
using System.Collections.Generic;

namespace _5._Record_Unique_Names
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            HashSet<string> uniqueNames = new HashSet<string>();

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                uniqueNames.Add(input);
            }

            foreach (var name in uniqueNames)
            {
                Console.WriteLine(name);
            }

        }
    }
}
