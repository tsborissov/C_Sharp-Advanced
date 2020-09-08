using System;
using System.Collections.Generic;
using System.Linq;

namespace _7._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {

            int pumpsCount = int.Parse(Console.ReadLine());

            Queue<string> pumps = new Queue<string>();

            for (int i = 0; i < pumpsCount; i++)
            {
                pumps.Enqueue(Console.ReadLine());
            }

            int firstPointIndex = 0;
            bool isTripCompleted = false;

            for (int i = 0; i < pumpsCount; i++)
            {
                int petrolTotal = 0;

                string[] pumpsTempArr = pumps.ToArray();

                for (int j = 0; j < pumpsCount; j++)
                {
                    string currentPump = pumpsTempArr[j];
                    int currentPetrol = int.Parse(currentPump.Split().ToArray()[0]);
                    int distance = int.Parse(currentPump.Split().ToArray()[1]);

                    petrolTotal += currentPetrol;

                    if (petrolTotal < distance)
                    {
                        isTripCompleted = false;
                        petrolTotal = 0;
                        break;
                    }
                    else
                    {
                        isTripCompleted = true;
                        petrolTotal -= distance;
                    }
                }

                if (isTripCompleted)
                {
                    firstPointIndex = i;
                    break;
                }
                

                pumps.Enqueue(pumps.Dequeue());
            }

            Console.WriteLine(firstPointIndex);
        }
    }
}
