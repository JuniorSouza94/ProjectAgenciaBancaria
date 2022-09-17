using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Infra.Data.Exceptions
{
    [Serializable]
    internal class ClienteNotFoundException : Exception
    {
        public ClienteNotFoundException() : this("Cliente não encontrado!")
        {
        }

        public ClienteNotFoundException(string message) : base(message)
        {
        }

        public ClienteNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ClienteNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}