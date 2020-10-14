using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpeedRacing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Car> cars = new Dictionary<string, Car>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] tokens = Console.ReadLine().Split().ToArray();

                string model = tokens[0];
                double fuelAmount = double.Parse(tokens[1]);
                double fuelConsumption = double.Parse(tokens[2]);

                if (!cars.ContainsKey(model))
                {
                    Car car = new Car(model, fuelAmount, fuelConsumption);

                    cars.Add(model, car);
                }
            }

            string commandInput = string.Empty;

            while((commandInput = Console.ReadLine()) != "End")
            {
                string[] tokens = commandInput.Split().ToArray();

                string modelToDrive = tokens[1];
                double distanceToDrive = double.Parse(tokens[2]);

                Car currentCar = cars[modelToDrive];

                currentCar.Drive(distanceToDrive);
            }

            StringBuilder result = new StringBuilder();

            foreach (var car in cars)
            {
                result.AppendLine($"{car.Value.Model} {car.Value.FuelAmount:F2} {car.Value.TravelledDistance}");
            }

            Console.WriteLine(result.ToString());
        }
    }
}
