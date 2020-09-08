using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {

            int passingCapacity = int.Parse(Console.ReadLine());

            var carsQueue = new Queue<string>();
            int carsCounter = 0;

            string token = string.Empty;

            while ((token = Console.ReadLine()) != "end")
            {
                if (token != "green")
                {
                    carsQueue.Enqueue(token);
                }
                else
                {
                    for (int i = 0; i < passingCapacity; i++)
                    {
                        if (carsQueue.Count > 0)
                        {
                            Console.WriteLine($"{carsQueue.Dequeue()} passed!");

                            carsCounter++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            Console.WriteLine($"{carsCounter} cars passed the crossroads.");

        }
    }
}
