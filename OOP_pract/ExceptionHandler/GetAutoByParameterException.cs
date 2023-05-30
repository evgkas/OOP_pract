namespace OOP_pract.ExceptionHandler
{
    public class GetAutoByParameterException : Exception
    {
        public GetAutoByParameterException() : base() { }

        public GetAutoByParameterException(string message) : base(message)
        {
            Console.WriteLine(message);
        }
    }
}
