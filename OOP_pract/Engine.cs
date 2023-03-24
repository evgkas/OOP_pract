//power, volume, type ,serial number
//parent class

namespace OOP_pract
{
    public class Engine
    {
        public double power { get; set; }
        public double volume { get; set; }
        public string EngineType { get; set; }
        public string EngineSerial { get; set; }


        public Engine(double power, double volume, string EngineType, string EngineSerial)
        {
            this.power = power;
            this.volume = volume;
            this.EngineType = EngineType;
            this.EngineSerial = EngineSerial;

        }


        public Engine()
        {
            power = 1;
            volume = 1;
            EngineType = "v6";
            EngineSerial = "111111AAA";

        }


        public void Print()
        {
            Console.WriteLine("Engine:");
            Console.WriteLine($"Power: {power}, Volume {volume} Engine type: {EngineType}, " +
                $"Serial number: {EngineSerial}");
        }
    }
}
