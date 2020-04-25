using RandomDice;

namespace RolePlaySetTests.Common
{
    public class DiceMinus1 : Dice
    {
        public string getName()
        {
            return "dM1";
        }

        public DiceValue rollADice()
        {
            return DiceValue.MinusOne;
        }
    }
}
