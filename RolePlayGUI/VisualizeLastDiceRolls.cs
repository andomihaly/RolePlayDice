using System;
using RolePlaySet;

namespace RolePlayGUI
{
    public class VisualizeLastDiceRolls : DiceRollNotification
    {
        private RolePlayBoard rolePlayBoard;
        public void connectToBoard(RolePlayBoard rolePlayBoard)
        {
            this.rolePlayBoard = rolePlayBoard;
        }

        public void rolledDice(string[,] rolledDice)
        {
            if (rolePlayBoard != null)
            {
                rolePlayBoard.VisualizeLastDiceRolls(rolledDice);
            }
        }
    }
}
