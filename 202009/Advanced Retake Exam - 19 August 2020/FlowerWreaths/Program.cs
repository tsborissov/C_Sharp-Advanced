using System;
using System.Collections.Generic;
using System.Linq;

namespace FlowerWreaths
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> lilies = new Stack<int>
                (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            Queue<int> roses = new Queue<int>
                (Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray());

            int flowersPerWreath = 15;
            int needeWreathCount = 5;
            int storedFlowersSum = 0;
            int wreathCounter = 0;

            while (true)
            {
                bool canContinue = lilies.Any() && roses.Any();

                if (!canContinue)
                {
                    break;
                }

                int currentSum = lilies.Peek() + roses.Peek();

                if (currentSum == flowersPerWreath)
                {
                    wreathCounter++;
                    lilies.Pop();
                    roses.Dequeue();
                }
                else if (currentSum > flowersPerWreath)
                {
                    int newLiliesValue = lilies.Pop() - 2;
                    lilies.Push(newLiliesValue);
                }
                else
                {
                    storedFlowersSum += lilies.Pop() + roses.Dequeue();
                }
            }

            wreathCounter += storedFlowersSum / flowersPerWreath;

            if (wreathCounter >= needeWreathCount)
            {
                Console.WriteLine($"You made it, you are going to the competition with {wreathCounter} wreaths!");
            }
            else
            {
                Console.WriteLine($"You didn't make it, you need {needeWreathCount - wreathCounter} wreaths more!");
            }
        }
    }
}
