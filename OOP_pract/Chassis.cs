//number of wheels, serial number, max weight

namespace OOP_pract
{
    public class Chassis : Engine
    {
        public int WheelsNumber;
        public string ChassisSerial;
        public double MaxWeight;


        public Chassis(int WheelsNumber, string ChassisSerial, double MaxWeight, double power, double volume,
            string EngineType, string EngineSerial) : base(power, volume, EngineType, EngineSerial)
        {
            this.WheelsNumber = WheelsNumber;
            this.ChassisSerial = ChassisSerial;
            this.MaxWeight = MaxWeight;
        }


        public Chassis(int WheelsNumber, string ChassisSerial, double MaxWeight)
        {
            this.WheelsNumber = WheelsNumber;
            this.ChassisSerial = ChassisSerial;
            this.MaxWeight = MaxWeight;
        }


        public Chassis()
        {
            WheelsNumber = 4;
            ChassisSerial = "AA0000";
            MaxWeight = 1000;
        }


        public new void Print()
        {
            Console.WriteLine("Chasis:");
            Console.WriteLine($"Number of wheels: {WheelsNumber}, Chassis number: {ChassisSerial}, Max weight: {MaxWeight}");
            Console.WriteLine("Engine:");
            Console.WriteLine($"Power: {power}, Volume {volume} Engine type: {EngineType}, " +
                $"Serial number: {EngineSerial}");
        }

    }
}
