using System;
using System.Runtime.Serialization;

namespace RolePlaySet
{
    [Serializable]
    internal class NotSupportedDiceType : Exception
    {
        public NotSupportedDiceType()
        {
        }

        public NotSupportedDiceType(string message) : base(message)
        {
        }

        public NotSupportedDiceType(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected NotSupportedDiceType(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}