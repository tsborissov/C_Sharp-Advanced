using System;
using System.Collections.Generic;

namespace Problem_2._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {

            string[] lengths = Console.ReadLine().Split();

            int n = int.Parse(lengths[0]);
            int m = int.Parse(lengths[1]);

            HashSet<int> firstSet = new HashSet<int>();
            HashSet<int> secondSet = new HashSet<int>();
            HashSet<int> commonSet = new HashSet<int>();
 
            for (int i = 0; i < n; i++)
            {
                int firstSetInput = int.Parse(Console.ReadLine());

                firstSet.Add(firstSetInput);
            }

            for (int i = 0; i < m; i++)
            {
                int secondSetInput = int.Parse(Console.ReadLine());

                secondSet.Add(secondSetInput);
            }

            if (firstSet.Count <= secondSet.Count)
            {
                foreach (var firstSetItem in firstSet)
                {
                    if (secondSet.Contains(firstSetItem))
                    {
                        commonSet.Add(firstSetItem);
                    }
                }
            }
            else
            {
                foreach (var secondSetItem in secondSet)
                {
                    if (firstSet.Contains(secondSetItem))
                    {
                        commonSet.Add(secondSetItem);
                    }
                }
            }
            

            if (commonSet.Count > 0)
            {
                Console.WriteLine(string.Join(' ', commonSet));
            }
        }
    }
}
