using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduling
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> tasks = new Stack<int>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> threads = new Queue<int>(
                Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int taskToKillValue = int.Parse(Console.ReadLine());

            while (true)
            {
                int currentThread = threads.Peek();
                int currentTask = tasks.Peek();

                if (taskToKillValue == currentTask)
                {
                    Console.WriteLine($"Thread with value {currentThread} killed task {tasks.Pop()}");
                    Console.WriteLine(string.Join(' ', threads));

                    break;
                }

                if (currentThread >= currentTask)
                {
                    threads.Dequeue();
                    tasks.Pop();
                }
                else
                {
                    threads.Dequeue();
                }
            }

        }
    }
}
