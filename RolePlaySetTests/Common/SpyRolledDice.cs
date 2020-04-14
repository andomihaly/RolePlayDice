using RolePlaySet;

namespace RolePlaySetTests.Common
{
    class SpyRolledDice : DiceRollNotification
    {
        
        public string[,] lastRolledDices;
        public string[,] lastMinusOneRolledDices;
        public void rolledDice(string[,] rolledDice)
        {
            if (lastRolledDices != null)
            {
                lastMinusOneRolledDices = lastRolledDices;
            }
            lastRolledDices = rolledDice;
            
        }
    }
}
