using System;
using RolePlaySet;

namespace RolePlayGUI
{
    public class RolePlayGameGUIPresenter : RolePlayPresenter
    {
        private RolePlayBoard rolePlayBoard;

        public void changeStory(string[] story)
        {
            rolePlayBoard.refillStoryBox(story);
        }

        public void connectToBoard(RolePlayBoard rolePlayBoard)
        {
            this.rolePlayBoard = rolePlayBoard;
        }

        public void displayError(string[] error)
        {
            throw new NotImplementedException();
        }

        public void loadedGameContext(string[] gameContext)
        {
            throw new NotImplementedException();
        }

        public void rolledDicesInTurn(string[,] rolledDice)
        {
            if (rolePlayBoard != null)
            {
                rolePlayBoard.VisualizeLastDiceRolls(rolledDice);
            }
        }
    }
}
