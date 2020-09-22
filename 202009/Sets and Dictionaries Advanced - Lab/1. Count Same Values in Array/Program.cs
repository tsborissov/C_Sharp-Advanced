using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] numbers = Console.ReadLine()
                .Split()
                .Select(double.Parse)
                .ToArray();

            Dictionary<double, int> counts = new Dictionary<double, int>();

            foreach (var num in numbers)
            {
                if (!counts.ContainsKey(num))
                {
                    counts.Add(num, 0);
                }

                counts[num]++;
            }

            foreach (var keyValue in counts)
            {
                Console.WriteLine($"{keyValue.Key} - {keyValue.Value} times");
            }
        }
    }
}
