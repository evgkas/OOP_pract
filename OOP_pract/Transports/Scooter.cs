using OOP_pract.ExceptionHandler;
using OOP_pract.Parts;

namespace OOP_pract.Cars
{
    public class Scooter : Car
    {
        public double luggageVolume = 0;

        public Scooter(string brand, double luggageVolume, Engine engine, Transmission transmission, Chassis chassis) : base(brand,
            engine, transmission, chassis)
        {
            try
            {
                if ((luggageVolume < 0) || (luggageVolume > 50))
                {
                    throw new InitializationException(" luggageVolume must be in range from 0 to 50");
                }

                this.luggageVolume = luggageVolume;

                if (chassis.wheelsNumber < 2 || chassis.wheelsNumber > 3)
                {
                    chassis.wheelsNumber = 2;
                    throw new InitializationException($"number of wheels must be in range from 2 to 3. wheelsNumber changed" +
                        $"to {chassis.wheelsNumber}");
                }
            }
            catch (InitializationException) { }
        }

        public new void Print()
        {
            Console.WriteLine($"Scooter {brand} id = {id}");
            engine.Print();
            transmission.Print();
            chassis.Print();
        }
    }
}
