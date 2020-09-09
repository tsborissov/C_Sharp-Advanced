using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] inputParameters = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int n = inputParameters[0];
            int s = inputParameters[1];
            int x = inputParameters[2];

            int[] inputNumbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> numsQueue = new Queue<int>();

            string result = string.Empty;

            for (int i = 0; i < n; i++)
            {
                numsQueue.Enqueue(inputNumbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                if (!numsQueue.TryDequeue(out int output))
                {
                    break;
                }
            }

            if (numsQueue.Contains(x))
            {
                result = "true";
            }
            else
            {
                if (numsQueue.Any())
                {
                    result = numsQueue.Min().ToString();
                }
                else
                {
                    result = "0";
                }
            }

            Console.WriteLine(result);
        }
    }
}
