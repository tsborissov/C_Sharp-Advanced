using System;
using System.Collections.Generic;

namespace Problem_3._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());

            SortedSet<string> uniqueChemicalElements = new SortedSet<string>();

            for (int i = 0; i < n; i++)
            {
                string[] compounds = Console.ReadLine().Split();

                uniqueChemicalElements.UnionWith(compounds);
            }

            Console.WriteLine(string.Join(' ', uniqueChemicalElements));
        }
    }
}
