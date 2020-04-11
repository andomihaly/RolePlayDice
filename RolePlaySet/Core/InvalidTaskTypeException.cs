using System;
using System.Runtime.Serialization;

namespace RolePlaySet.Core
{
    [Serializable]
    internal class InvalidTaskTypeException : Exception
    {
        public InvalidTaskTypeException()
        {
        }

        public InvalidTaskTypeException(string message) : base(message)
        {
        }

        public InvalidTaskTypeException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidTaskTypeException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}