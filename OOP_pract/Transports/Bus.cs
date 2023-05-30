using OOP_pract.ExceptionHandler;
using OOP_pract.Parts;

namespace OOP_pract.Cars
{
    public class Bus : Car
    {
        public int maxPassengers = 9;

        public Bus(string brand, int maxPassengers, Engine engine, Transmission transmission, Chassis chassis) :
            base(brand, engine, transmission, chassis)
        {
            try
            {
                if (maxPassengers < 9)
                {
                    throw new InitializationException("maxPassengers for Bus must be above 8. maxPassengers set to 9");
                }

                this.maxPassengers = maxPassengers;
            }
            catch (InitializationException) { }
        }

        public new void Print()
        {
            Console.WriteLine($"Bus {brand} id = {id}");
            engine.Print();
            transmission.Print();
            chassis.Print();
        }
    }
}
