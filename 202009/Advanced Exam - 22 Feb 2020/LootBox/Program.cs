using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace LootBox
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> firstBox = new Queue<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            Stack<int> secondBox = new Stack<int>
                (Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            List<int> claimedItems = new List<int>();

            while (firstBox.Any() && secondBox.Any())
            {
                int currentItem = firstBox.Peek() + secondBox.Peek();

                if (currentItem % 2 == 0)
                {
                    claimedItems.Add(currentItem);
                    firstBox.Dequeue();
                    secondBox.Pop();
                }
                else
                {
                    firstBox.Enqueue(secondBox.Pop());
                }
            }

            if (!firstBox.Any())
            {
                Console.WriteLine("First lootbox is empty");
            }

            if (!secondBox.Any())
            {
                Console.WriteLine("Second lootbox is empty");
            }

            int claimedItemsSum = claimedItems.Sum();

            if (claimedItemsSum >= 100)
            {
                Console.WriteLine($"Your loot was epic! Value: {claimedItemsSum}");
            }
            else
            {
                Console.WriteLine($"Your loot was poor... Value: {claimedItemsSum}");
            }
        }
    }
}
