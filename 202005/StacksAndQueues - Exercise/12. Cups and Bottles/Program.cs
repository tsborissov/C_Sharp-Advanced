using System;
using System.Collections.Generic;
using System.Linq;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {

            Queue<int> cups = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            Stack<int> bottles = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            int wastedWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int currentCup = cups.Peek();

                while (bottles.Any())
                {
                    int currentBottle = bottles.Pop();

                    currentCup -= currentBottle;

                    if (currentCup <= 0)
                    {
                        cups.Dequeue();
                        wastedWater += Math.Abs(currentCup);
                        break;
                    }
                }
            }

            if (!cups.Any())
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }
            else
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            }

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
