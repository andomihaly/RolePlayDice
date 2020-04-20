using System;
using RolePlaySet;

namespace RolePlaySetTests.Common
{
    class SpyUIPresenter : RolePlayPresenter
    {
        
        public string[,] lastRolledDices;
        public string[,] lastMinusOneRolledDices;
        public string[] lastStory = new string[] { };
        public string[] lastGameContext = new string[] { };

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
            lastStory = story;
        }

        public void loadedGameContext(string[] gameContext)
        {
            lastGameContext = gameContext;
        }

        public void displayError(string[] error)
        {
            throw new NotImplementedException();
        }
    }
}
