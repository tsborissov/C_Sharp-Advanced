using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericSwapMethodIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> inputList = new List<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                inputList.Add(int.Parse(Console.ReadLine());
            }

            Box<int> box = new Box<int>(inputList);

            int[] swapIndexes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            box.Swap(box.Values, swapIndexes[0], swapIndexes[1]);

            Console.WriteLine(box);
        }
    }
}
