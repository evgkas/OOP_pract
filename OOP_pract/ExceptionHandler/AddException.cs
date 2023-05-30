namespace OOP_pract.ExceptionHandler
{
    public class AddException : Exception
    {
        public AddException() : base() { }

        public AddException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public AddException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine(message);
        }
    }
}
