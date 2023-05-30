using OOP_pract.Parts;

namespace OOP_pract.Cars
{
    public class Car
    {
        public string brand = "Undefined";
        private static int counter = 111110;
        public int id;
        public Engine engine;
        public Transmission transmission;
        public Chassis chassis;

        public Car(string brand, Engine engine, Transmission transmission, Chassis chassis)
        {
            this.engine = engine;
            this.transmission = transmission;
            this.chassis = chassis;
            this.brand = brand;
            counter++;
            id = counter;
        }

        public void Print()
        {
            Console.WriteLine($"{brand} with id = {id}");
            engine.Print();
            transmission.Print();
            chassis.Print();
            Console.WriteLine("=================================================");
        }
    }
}
