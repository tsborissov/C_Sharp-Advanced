using System;
using System.Collections.Generic;
using System.Linq;

namespace StackSum
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var stack = new Stack<int>(arr);
            int stackSum = 0;

            string command = string.Empty;

            while ((command = Console.ReadLine().ToLower()) != "end")
            {
                string[] tokens = command.Split().ToArray();
                
                switch (tokens[0].ToLower())
                {
                    case "add":

                        stack.Push(int.Parse(tokens[1]));
                        stack.Push(int.Parse(tokens[2]));

                        break;

                    case "remove":

                        int removeCount = int.Parse(tokens[1]);

                        if (stack.Count >= removeCount)
                        {
                            for (int i = 0; i < removeCount; i++)
                            {
                                stack.Pop();
                            }
                        }

                        break;
                }
            }

            while (stack.Count > 0)
            {
                stackSum += stack.Pop();
            }

            Console.WriteLine($"Sum: {stackSum}");
        }
    }
}
