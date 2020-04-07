using RandomDice;

namespace RolePlaySet.Tests
{
    public class Dice0 : Dice
    {
        
        public string getName()
        {
            return "d0";
        }

        public DiceValue throwADice()
        {
            return DiceValue.Zero;
        }
    }
}
