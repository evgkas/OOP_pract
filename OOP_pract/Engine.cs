namespace OOP_pract
{
    public class Engine
    {
        public double power { get; set; }
        public double volume { get; set; }
        public string type { get; set; }
        public string serialNumber { get; set; }

        public Engine(double power, double volume, string type, string serialNumber)
        {
            this.power = power;
            this.volume = volume;
            this.type = type;
            this.serialNumber = serialNumber;
        }

        public void Print()
        {
            Console.WriteLine("Engine:");
            Console.WriteLine($"Power: {power}, Volume: {volume}, Engine type: {type}, Serial number: {serialNumber}");
        }
    }
}
