using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CarManufacturer
{
    public class Car
    {
        private string make;
        private string model;
        private int year;
        private double fuelQuantity;
        private double fuelConsumption;

        public Car()
        {
            this.Make = "VW";
            this.Model = "Golf";
            this.Year = 2025;
            this.FuelQuantity = 200;
            this.FuelConsumption = 10;
        }

        public Car(string make, string model, int year)
            : this()
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption)
            : this (make, model, year)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
        }

        public Car(string make, string model, int year, double fuelQuantity, double fuelConsumption, Engine engine, Tire[] tires)
            : this (make, model, year, fuelQuantity, fuelConsumption)
        {
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make
        {
            get { return this.make; }
            set { this.make = value;  }
        }
        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }
        public int Year
        {
            get { return this.year; }
            set
            {
                if (value > 0)
                {
                    this.year = value;
                }
            }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                if (value >= 0)
                {
                    this.fuelQuantity = value;
                }
            }
        }
        public double FuelConsumption
        {
            get { return this.fuelConsumption; }
            set
            {
                if (value >= 0)
                {
                    this.fuelConsumption = value;
                }
            }
        }

        public Engine Engine { get; set; }
        
        public Tire[] Tires { get; set; }
        

        public void Drive(double distance)
        {
            double neededFuel = distance * this.FuelConsumption;
            bool isEnoughFuel = this.FuelQuantity - neededFuel > 0;

            if (isEnoughFuel)
            {
                this.FuelQuantity -= neededFuel;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string CarSpecifications()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Make {this.Make}");
            sb.AppendLine($"Model: {this.Model}");
            sb.AppendLine($"Year: {this.Year}");
            sb.AppendLine($"Fuel: {this.FuelQuantity:F2}L");

            return sb.ToString();
        }

    }
}
