using System;
using RolePlaySet;

namespace RolePlaySetTests.Common
{
    class SpyUIPresenter : RolePlayPresenter
    {
        
        public string[] lastRolledDices = new string[] { };
        public string[] lastStory = new string[] { };
        public string[] lastGameContext = new string[] { };
        public string[] lastInitContext = new string[] { };

        public void rolledDicesInTurn(string[] rolledDice)
        {
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

        public void initRolePlayContext(string[] initContext)
        {
            lastInitContext = initContext;
        }
    }
}
