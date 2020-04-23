using System;

namespace RolePlaySet.Gateway.Persistence
{
    public class CouldNotCreateNewGameException : Exception
    {
        public CouldNotCreateNewGameException(string message) : base(message)
        {
        }
    }
}