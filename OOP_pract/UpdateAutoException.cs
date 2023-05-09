namespace OOP_pract
{
    internal class UpdateAutoException : Exception
    {
        public UpdateAutoException() : base() { }

        public UpdateAutoException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
        public UpdateAutoException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine(message);
        }
    }
}
