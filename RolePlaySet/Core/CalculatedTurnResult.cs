using System;
namespace RolePlaySet.Core
{
    public class CalculatedTurnResult
    {
        public String generatedText;
        public String[] rolledDices;

        public CalculatedTurnResult(string generatedText, string[] rolledDices)
        {
            this.generatedText = generatedText;
            this.rolledDices = rolledDices;
        }
    }
}
