
namespace OOP_pract.Parts
{
    public class Chassis
    {
        public int wheelsNumber;
        public string chassisSerial;
        public double maxWeight;

        public Chassis(int wheelsNumber, string chassisSerial, double maxWeight)
        {
            this.wheelsNumber = wheelsNumber;
            this.chassisSerial = chassisSerial;
            this.maxWeight = maxWeight;
        }

        public void Print()
        {
            Console.WriteLine("Chasis:");
            Console.WriteLine($"Number of wheels: {wheelsNumber}, Chassis number: {chassisSerial}, Max weight: {maxWeight}");
        }
    }
}
