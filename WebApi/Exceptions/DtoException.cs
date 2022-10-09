using System;

namespace WebApi.Exceptions
{
    public class DtoException : Exception
    {
        public DtoException() : base()
        {
        }

        public DtoException(string message) : base(message)
        {
        }

        public DtoException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}