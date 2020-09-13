using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {

            int greenLight = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();
            int passCounter = 0;
            string input = string.Empty;
            bool isCrash = false;

            while ((input = Console.ReadLine()) != "END")
            {
                if (input != "green")
                {
                    cars.Enqueue(input);
                }
                else
                {
                    int currentGreenLight = greenLight;
                    int currentFreeWindow = freeWindow;

                    while (cars.Any())
                    {
                        string currentCar = cars.Peek();

                        if (currentGreenLight > 0)
                        {
                            currentGreenLight -= currentCar.Length;

                            if (currentGreenLight > 0)
                            {
                                passCounter++;
                                cars.Dequeue();
                            }
                            else
                            {
                                currentFreeWindow += currentGreenLight;

                                if (currentFreeWindow >= 0)
                                {
                                    passCounter++;
                                    cars.Dequeue();
                                    break;
                                }
                                else
                                {
                                    isCrash = true;

                                    int hitIndex = currentCar.Length + currentFreeWindow;

                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{currentCar} was hit at {currentCar[hitIndex]}.");

                                    break;
                                }
                            }
                        }
                        else
                        {
                            break;
                        }
                    }
                }

                if (isCrash)
                {
                    break;
                }
            }

            if (!isCrash)
            {
                Console.WriteLine("Everyone is safe.");
                Console.WriteLine($"{passCounter} total cars passed the crossroads.");
            }
         }
    }
}
