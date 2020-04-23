using System;

namespace RolePlaySet.Core
{
    public class NotSupportedDiceTypeException : Exception
    {
        public NotSupportedDiceTypeException(string message) : base(message)
        {
        }
    }
}