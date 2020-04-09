using RandomDice;

namespace RolePlaySetTests.SystemTest
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
