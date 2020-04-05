using System;

namespace RandomDice.Dices
{
    public class Dice1 : Dice
    {
        public DiceValue throwADice()
        {
            return DiceValue.PlusOne;
        }
    }
}
