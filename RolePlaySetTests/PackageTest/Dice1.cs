using RandomDice;

namespace RolePlaySetTests
{
    public class Dice1 : Dice
    {
        public string getName()
        {
            return "d1";
        }

        public DiceValue throwADice()
        {
            return DiceValue.PlusOne;
        }
    }
}
