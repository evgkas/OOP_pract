namespace OOP_pract
{
    public class Transmission
    {
        public string type;
        public int gearsNumber;
        public string manufacture;

        public Transmission(string type, int gearsNumber, string manufacture)
        {
            this.type = type;
            this.gearsNumber = gearsNumber;
            this.manufacture = manufacture;
        }

        public void Print()
        {
            Console.WriteLine("Transmission:");
            Console.WriteLine($"Transmission type: {type}, number of gears: {gearsNumber}, manufacture: {manufacture}");
        }
    }
}
