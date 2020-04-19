using System;
using RolePlaySet;

namespace RolePlaySetTests.Common
{
    class SpyRolledDice : RolePlayPresenter
    {
        
        public string[,] lastRolledDices;
        public string[,] lastMinusOneRolledDices;
        public void rolledDicesInTurn(string[,] rolledDice)
        {
            if (lastRolledDices != null)
            {
                lastMinusOneRolledDices = lastRolledDices;
            }
            lastRolledDices = rolledDice;
            
        }

        public void changeStory(string[] story)
        {
            throw new NotImplementedException();
        }

        public void loadedGameContext(string[] gameContext)
        {
            throw new NotImplementedException();
        }

        public void displayError(string[] error)
        {
            throw new NotImplementedException();
        }
    }
}
