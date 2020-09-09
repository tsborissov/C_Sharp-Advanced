using System;
using System.Collections.Generic;
using System.Linq;

namespace _4._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {

            int foodQuantity = int.Parse(Console.ReadLine());

            Queue<int> orders = new Queue<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());

            Console.WriteLine(orders.Max());

            while (true)
            {
                if (orders.TryPeek(out int currentOrder))
                {
                    if (foodQuantity >= currentOrder)
                    {
                        orders.Dequeue();
                        foodQuantity -= currentOrder;
                    }
                    else
                    {
                        break;
                    }
                }
                else
                {
                    break;
                }
            }

            if (!orders.Any())
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(' ', orders)}");
            }

        }
    }
}
