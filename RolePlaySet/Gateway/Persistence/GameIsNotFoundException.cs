using System;

namespace RolePlaySet.Gateway.Persistence
{
    public class GameIsNotFoundException : Exception
    {
        public GameIsNotFoundException(string message) : base(message)
        {
        }
    }
}