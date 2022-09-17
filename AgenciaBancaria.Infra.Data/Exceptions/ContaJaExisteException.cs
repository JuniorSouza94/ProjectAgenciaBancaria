using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Infra.Data.Exceptions
{
    [Serializable]
    internal class ContaJaExisteException : Exception
    {
        public ContaJaExisteException() : this("Conta já existe!")
        {
        }

        public ContaJaExisteException(string message) : base(message)
        {
        }

        public ContaJaExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContaJaExisteException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}