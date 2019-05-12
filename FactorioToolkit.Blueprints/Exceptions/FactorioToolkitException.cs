using System;

namespace FactorioToolkit.Infrastructure.Exceptions
{
    public class FactorioToolkitException : Exception
    {
        public FactorioToolkitException()
        {
        }

        public FactorioToolkitException(string message)
            : base(message)
        {
        }

        public FactorioToolkitException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}