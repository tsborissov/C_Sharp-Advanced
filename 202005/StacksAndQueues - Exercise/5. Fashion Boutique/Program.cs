using System;
using System.Collections.Generic;
using System.Linq;

namespace _5._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<int> clothes = new Stack<int>(Console.ReadLine().Split().Select(int.Parse).ToArray());
            int rackCapacity = int.Parse(Console.ReadLine());

            int racksCounter = 0;

            while (clothes.Any())
            {

                int rackCapacityUsed = 0;

                while (true)
                {
                    if (clothes.TryPeek(out int currentClothe))
                    {
                        if (rackCapacityUsed + currentClothe <= rackCapacity)
                        {
                            rackCapacityUsed += currentClothe;
                            clothes.Pop();
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

                racksCounter++;
            }

            Console.WriteLine(racksCounter);

        }
    }
}
