using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Exceptions
{
    public class DbNoDataException : Exception
    {
        public DbNoDataException() : base()
        {
        }

        public DbNoDataException(string message) : base(message)
        {
        }

        public DbNoDataException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}