using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CarSalesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Engine> engines = new Dictionary<string, Engine>();

            int numberOfEngines = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfEngines; i++)
            {
                string[] engineParameters = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                EngineEntry(engineParameters, engines);
            }


            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carInput = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                CarEntry(carInput, cars, engines);
            }

            Console.WriteLine(GetCarsInfo(cars, engines));
        }

        public static string GetCarsInfo(List<Car> cars, Dictionary<string, Engine> engines)
        {
            StringBuilder result = new StringBuilder();

            foreach (var car in cars)
            {
                int currentEnginePower = engines[car.Engine].Power;

                string currentEngineDisplacement = "n/a";

                if (engines[car.Engine].Displacement != -1)
                {
                    currentEngineDisplacement = engines[car.Engine].Displacement.ToString();
                }

                string currentEngineEfficiency = engines[car.Engine].Efficiency;

                string currentCarWeight = "n/a";

                if (car.Weight != -1)
                {
                    currentCarWeight = car.Weight.ToString();
                }

                result.AppendLine($"{car.Model}:");
                result.AppendLine($" {car.Engine}:");
                result.AppendLine($"  Power: {currentEnginePower}");
                result.AppendLine($"  Displacement: {currentEngineDisplacement}");
                result.AppendLine($"  Efficiency: {currentEngineEfficiency}");
                result.AppendLine($" Weight: {currentCarWeight}");
                result.AppendLine($" Color: {car.Color}");
            }

            return result.ToString();
        }

        public static void CarEntry(string[] carInput, List<Car> cars, Dictionary<string, Engine> engines)
        {
            string model = carInput[0];
            string engine = carInput[1];
            int weight = -1;
            string color = "n/a";

            if (carInput.Length == 4)
            {
                weight = int.Parse(carInput[2]);
                color = carInput[3];
            }
            else if (carInput.Length == 3)
            {
                if (int.TryParse(carInput[2], out int result))
                {
                    weight = result;
                }
                else
                {
                    color = carInput[2];
                }
            }

            if (engines.ContainsKey(engine))
            {
                Car currentCar = new Car(model, engine, weight, color);

                cars.Add(currentCar);
            }
        }

        public static void EngineEntry(string[] engineParameters, Dictionary<string, Engine> engines)
        {
            string engineModel = engineParameters[0];
            int power = int.Parse(engineParameters[1]);
            int displacement = -1;
            string efficiency = "n/a";

            if (engineParameters.Length == 4)
            {
                displacement = int.Parse(engineParameters[2]);
                efficiency = engineParameters[3];
            }
            else if (engineParameters.Length == 3)
            {
                if (int.TryParse(engineParameters[2], out int result))
                {
                    displacement = result;
                }
                else
                {
                    efficiency = engineParameters[2];
                }
            }

            if (!engines.ContainsKey(engineModel))
            {
                Engine currentEngine = new Engine(engineModel, power, displacement, efficiency);

                engines.Add(engineModel, currentEngine);
            }
        }
    }
}
