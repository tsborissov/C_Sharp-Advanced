using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {

            var inputQueue = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            var evenNumbers = new List<int>();

            while (inputQueue.Count > 0)
            {
                if (inputQueue.Peek() % 2 == 0)
                {
                    evenNumbers.Add(inputQueue.Dequeue());
                }
                else
                {
                    inputQueue.Dequeue();
                }
            }

            Console.WriteLine(string.Join(", ", evenNumbers));

        }
    }
}
