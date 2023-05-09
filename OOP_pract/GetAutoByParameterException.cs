namespace OOP_pract
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
