using System;
using System.Collections.Generic;
using System.Text;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;

        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;

            data = new List<Car>();
        }

        public string Type { get; set; }
        public int Capacity { get; set; }

        public int Count
        {
            get { return this.data.Count; }
        }

        public void Add(Car car)
        {
            if (this.data.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }

        public bool Remove(string manufacturer, string model)
        {
            bool isCarAvailable = false;

            for (int i = 0; i < data.Count; i++)
            {
                Car currentCar = data[i];
                
                if (currentCar.Manufacturer == manufacturer && currentCar.Model == model)
                {
                    isCarAvailable = true;

                    data.RemoveAt(i);

                    break;
                }
            }

            return isCarAvailable;
        }

        public Car GetLatestCar()
        {
            int latestCarYear = 0;

            Car latestCar = new Car("", "", -1);

            foreach (var car in data)
            {
                if (car.Year > latestCarYear)
                {
                    latestCarYear = car.Year;

                    latestCar = car;
                }
            }

            if (latestCar.Year == -1)
            {
                return null;
            }
            else
            {
                return latestCar;
            }
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car targetCar = new Car("", "", -1);

            foreach (var car in this.data)
            {
                if (car.Manufacturer == manufacturer && car.Model == model)
                {
                    targetCar = car;
                }
            }


            if (targetCar.Year == -1)
            {
                return null;
            }
            else
            {
                return targetCar;
            }
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");

            foreach (var car in data)
            {
                sb.AppendLine(car.ToString());
            }

            return sb.ToString();
        }

    }
}
