using System;
using System.Runtime.Serialization;

namespace RolePlayFileBasedStorage
{
    [Serializable]
    internal class CouldNotCreateNewGameFileStructure : Exception
    {
        public CouldNotCreateNewGameFileStructure()
        {
        }

        public CouldNotCreateNewGameFileStructure(string message) : base(message)
        {
        }

        public CouldNotCreateNewGameFileStructure(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected CouldNotCreateNewGameFileStructure(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}