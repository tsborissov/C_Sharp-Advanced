using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {

            int queriesNumber = int.Parse(Console.ReadLine());

            Stack<int> stack = new Stack<int>();

            for (int i = 0; i < queriesNumber; i++)
            {
                string[] input = Console.ReadLine().Split().ToArray();

                switch (input[0])
                {
                    case "1":

                        stack.Push(int.Parse(input[1]));

                        break;

                    case "2":

                        stack.TryPop(out int result);

                        break;

                    case "3":

                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Max());
                        }

                        break;

                    case "4":

                        if (stack.Any())
                        {
                            Console.WriteLine(stack.Min());
                        }

                        break;
                }

            }

            Console.WriteLine(string.Join(", ", stack));

        }
    }
}
