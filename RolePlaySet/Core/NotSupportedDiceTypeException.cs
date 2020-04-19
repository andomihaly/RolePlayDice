using System;
using System.Runtime.Serialization;

namespace RolePlaySet.Core
{
    [Serializable]
    internal class NotSupportedDiceTypeException : Exception
    {
        public NotSupportedDiceTypeException()
        {
        }

        public NotSupportedDiceTypeException(string message) : base(message)
        {
        }

        public NotSupportedDiceTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSupportedDiceTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}