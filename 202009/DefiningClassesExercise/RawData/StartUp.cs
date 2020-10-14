using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RawData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] tokens = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string model = tokens[0];

                int engineSpeed = int.Parse(tokens[1]);
                int enginePower = int.Parse(tokens[2]);

                int cargoWeight = int.Parse(tokens[3]);
                string cargoType = tokens[4];

                double tire1Pressure = double.Parse(tokens[5]);
                int tire1Age = int.Parse(tokens[6]);

                double tire2Pressure = double.Parse(tokens[7]);
                int tire2Age = int.Parse(tokens[8]);

                double tire3Pressure = double.Parse(tokens[9]);
                int tire3Age = int.Parse(tokens[10]);

                double tire4Pressure = double.Parse(tokens[11]);
                int tire4Age = int.Parse(tokens[12]);

                Car car = new Car(model, engineSpeed, enginePower, cargoWeight, cargoType,
                        tire1Pressure, tire1Age, tire2Pressure, tire2Age,
                        tire3Pressure, tire3Age, tire4Pressure, tire4Age);

                cars.Add(car);
            }

            StringBuilder result = new StringBuilder();

            string command = Console.ReadLine();

            if (command == "fragile")
            {
                // print all cars whose cargo is "fragile" with a tire, whose pressure is  < 1

                foreach (var car in cars.Where(x => x.Cargo.CargoType == "fragile" && x.Tires.Any(p => p.TirePressure < 1)))
                {
                    result.AppendLine(car.Model);
                }

            }
            else if (command == "flamable")
            {
                // print all of the cars, whose cargo is "flamable" and have engine power > 250

                foreach (var car in cars
                    .Where(x => x.Cargo.CargoType == "flamable")
                    .Where(x => x.Engine.EnginePower > 250))
                {
                    result.AppendLine(car.Model);
                }
            }

            Console.WriteLine(result.ToString());
        }
    }
}
