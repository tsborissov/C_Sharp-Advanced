using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            var customStack = new Stack<int>();

            string input = string.Empty;

            while ((input = Console.ReadLine()) != "END")
            {
                try
                {
                    string[] tokens = input
                    .Split(' ', 2)
                    .ToArray();

                    if (tokens[0] == "Pop")
                    {
                        customStack.Pop();
                    }
                    else if (tokens[0] == "Push")
                    {
                        int[] numbers = tokens[1]
                            .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

                        customStack.Push(numbers);
                    }
                }
                catch (Exception exception)
                {

                    Console.WriteLine(exception.Message); ;
                }
            }

            PrintCustomStack(customStack);
            PrintCustomStack(customStack);
        }

        private static void PrintCustomStack(Stack<int> customStack)
        {
            foreach (var element in customStack)
            {
                Console.WriteLine(element);
            }
        }
    }
}
