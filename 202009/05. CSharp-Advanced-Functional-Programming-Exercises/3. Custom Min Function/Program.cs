﻿using System;
using System.Linq;

namespace _3._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int[], int> customMinFn = (arr) =>
            {
                int minValue = int.MaxValue;

                foreach (var num in arr)
                {
                    if (num < minValue)
                    {
                        minValue = num;
                    }
                }

                return minValue;
            };

            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(customMinFn(numbers));
        }
    }
}
