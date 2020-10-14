namespace RawData
{
    public class Car
    {

        public Car(string model,
            int engineSpeed, int enginePower,
            int cargoWeight, string cargoType,
            double tire1Pressure, int tire1Age,
            double tire2Pressure, int tire2Age,
            double tire3Pressure, int tire3Age,
            double tire4Pressure, int tire4Age)
        {
            Model = model;
            Engine.EngineSpeed = engineSpeed;
            Engine.EnginePower = enginePower;
            Cargo.CargoWeight = cargoWeight;
            Cargo.CargoType = cargoType;

            Tires[0] = new Tire();
            Tires[0].TirePressure = tire1Pressure;
            Tires[0].TireAge = tire1Age;

            Tires[1] = new Tire();
            Tires[1].TirePressure = tire2Pressure;
            Tires[1].TireAge = tire2Age;

            Tires[2] = new Tire();
            Tires[2].TirePressure = tire3Pressure;
            Tires[2].TireAge = tire3Age;

            Tires[3] = new Tire();
            Tires[3].TirePressure = tire4Pressure;
            Tires[3].TireAge = tire4Age;


        }

        public string Model { get; set; }
        public Engine Engine { get; set; } = new Engine();
        public Cargo Cargo { get; set; } = new Cargo();
        public Tire[] Tires { get; set; } = new Tire[4];


    }
}
