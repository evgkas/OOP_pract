//type, number of gears, manufacture

namespace OOP_pract
{
    public class Transmission : Chassis
    {
        public string TransmissionType;
        public int GearsNumber;
        public string manufacture;


        public Transmission(string TransmissionType, int GearsNumber, string manufacture)
        {
            this.TransmissionType = TransmissionType;
            this.GearsNumber = GearsNumber;
            this.manufacture = manufacture;
        }


        public Transmission(string TransmissionType, int GearsNumber, string manufacture, int WheelsNumber, string ChassisSerial,
            double MaxWeight) : base(WheelsNumber, ChassisSerial, MaxWeight)
        {
            this.TransmissionType = TransmissionType;
            this.GearsNumber = GearsNumber;
            this.manufacture = manufacture;
        }


        public Transmission(string TransmissionType, int GearsNumber, string manufacture, int WheelsNumber, 
            string ChassisSerial, double MaxWeight, double power, double volume, string EngineType, 
            string EngineSerial) : base(WheelsNumber, ChassisSerial, MaxWeight, power, volume, EngineType, EngineSerial)
        {
            this.TransmissionType = TransmissionType;
            this.GearsNumber = GearsNumber;
            this.manufacture = manufacture;
        }

        public Transmission()
        {
            this.TransmissionType = "auto";
            this.GearsNumber = 4;
            this.manufacture = "Undefined";
        }


        public new void Print()
        {
            Console.WriteLine("Transmission:");
            Console.WriteLine($"Transmission type: {TransmissionType}, number of gears: {GearsNumber}, manufacture: {manufacture}");
            Console.WriteLine("Chasis:");
            Console.WriteLine($"Number of wheels: {WheelsNumber}, Chassis number: {ChassisSerial}, Max weight: {MaxWeight}");
            Console.WriteLine("Engine:");
            Console.WriteLine($"Power: {power}, Volume {volume} Engine type: {EngineType}, Serial number: {EngineSerial}");
            Console.WriteLine("=======================================================");
        }
    }
}
