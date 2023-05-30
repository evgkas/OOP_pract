namespace OOP_pract.Parts
{
    public class Engine
    {
        public double power;
        public double volume;
        public string type;
        public string serialNumber;

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
