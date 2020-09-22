using System;
using System.Collections.Generic;

namespace _6._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {

            HashSet<string> cars = new HashSet<string>();

            string input = string.Empty;

            while (true)
            {
                input = Console.ReadLine();
                if (input == "END")
                {
                    break;
                }

                string[] tokens = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);

                string direction = tokens[0];
                string carNumber = tokens[1];

                switch (direction)
                {
                    case "IN":

                        cars.Add(carNumber);

                        break;

                    case "OUT":

                        cars.Remove(carNumber);

                        break;
                }
            }

            if (cars.Count == 0)
            {
                Console.WriteLine("Parking Lot is Empty");
            }
            else
            {
                foreach (var car in cars)
                {
                    Console.WriteLine(car);
                }
            }
        }
    }
}
