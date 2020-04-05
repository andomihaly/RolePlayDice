using System;
using System.Runtime.Serialization;

namespace RandomDice
{
    [Serializable]
    public class InvalidDiceValueException : Exception
    {
        public InvalidDiceValueException()
        {
        }

        public InvalidDiceValueException(string message) : base(message)
        {
        }

        public InvalidDiceValueException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidDiceValueException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}