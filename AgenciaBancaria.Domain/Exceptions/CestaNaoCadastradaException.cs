using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    internal class CestaNaoCadastradaException : Exception
    {
        public CestaNaoCadastradaException() : this("Valor inválido!")
        {
        }

        public CestaNaoCadastradaException(string message) : base(message)
        {
        }

        public CestaNaoCadastradaException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CestaNaoCadastradaException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}