using RandomDice;

namespace RolePlaySetTests.Common
{
    public class Dice1 : Dice
    {
        public string getName()
        {
            return "d1";
        }

        public DiceValue rollADice()
        {
            return DiceValue.PlusOne;
        }
    }
}
