﻿namespace OOP_pract.ExceptionHandler
{
    public class RemoveAutoException : Exception
    {
        public RemoveAutoException() : base() { }

        public RemoveAutoException(string message) : base(message)
        {
            Console.WriteLine(message);
        }

        public RemoveAutoException(string message, Exception innerException) : base(message, innerException)
        {
            Console.WriteLine(message);
        }
    }
}
