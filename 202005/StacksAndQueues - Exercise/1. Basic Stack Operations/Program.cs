using System;
using System.Collections.Generic;
using System.Linq;

namespace _1._Basic_Stack_Operations
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

            Stack<int> numStack = new Stack<int>();

            string result = string.Empty;

            for (int i = 0; i < n; i++)
            {
                numStack.Push(inputNumbers[i]);
            }

            for (int i = 0; i < s; i++)
            {
                if(!numStack.TryPop(out int output))
                {
                    break;
                }
            }

            if (numStack.Contains(x))
            {
                result = "true";
            }
            else
            {
                if (numStack.Any())
                {
                    result = numStack.Min().ToString();
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
