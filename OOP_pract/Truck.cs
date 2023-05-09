namespace OOP_pract
{
    public class Truck : Car
    {
        public int maxTrailers;    //number of trailers may be attached to the truck
        public Truck(string brand, int maxTrailers, Engine engine, Transmission transmission, Chassis chassis)
            : base(brand, engine, transmission, chassis)
        {            
            try
            {
                if (chassis.maxWeight < 3500)
                {
                    throw new InitializationException("chassis maxWeight for Truck must be 3500 or above");
                }
                this.maxTrailers = maxTrailers;
            }
            catch (InitializationException) 
            {
                chassis.maxWeight = 3500;
                Console.WriteLine($"chassis.maxWeight set to {chassis.maxWeight}");    
            }
        }

        public new void Print()
        {
            Console.WriteLine($"Truck {brand} id = {id}");
            engine.Print();
            transmission.Print();
            chassis.Print();
        }
    }
}
