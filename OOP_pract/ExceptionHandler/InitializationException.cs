namespace OOP_pract.ExceptionHandler
{
    public class InitializationException : Exception
    {
        public InitializationException() : base() { }

        public InitializationException(string message) : base(message)
        {
            Console.WriteLine("Vechile can not be initialized: " + message);
        }

        public InitializationException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine(message);
        }
    }
}
