namespace OOP_pract
{
    public class Car : Transmission
    {
        public string CarType = "Undefined";

        public Car(string CarType, string TransmissionType, int GearsNumber, string manufacture, int WheelsNumber,
            string ChassisSerial, double MaxWeight, double power, double volume, string EngineType,
            string EngineSerial) : base(TransmissionType, GearsNumber, manufacture, WheelsNumber,
            ChassisSerial, MaxWeight, power, volume, EngineType, EngineSerial)
        {
            this.CarType = CarType;
        }

        public new void Print()
        {
            Console.WriteLine(CarType);
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
