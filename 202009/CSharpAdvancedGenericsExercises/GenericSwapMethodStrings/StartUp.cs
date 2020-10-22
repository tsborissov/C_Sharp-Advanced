using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodStrings
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                input.Add(Console.ReadLine());
            }

            Box<string> box = new Box<string>(input);

            int[] swapIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            box.Swap(box.Values, swapIndexes[0], swapIndexes[1]);

            Console.WriteLine(box);

        }
    }
}
