using System;
using System.Runtime.Serialization;

namespace AgenciaBancaria.Domain.Exceptions
{
    [Serializable]
    internal class TipoContaNaoExisteExcepetion : Exception
    {
        public TipoContaNaoExisteExcepetion() : this("Valor inválido!")
        {
        }

        public TipoContaNaoExisteExcepetion(string message) : base(message)
        {
        }

        public TipoContaNaoExisteExcepetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected TipoContaNaoExisteExcepetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}