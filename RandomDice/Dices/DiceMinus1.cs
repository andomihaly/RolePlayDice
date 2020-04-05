using System;

namespace RandomDice.Dices
{
    public class DiceMinus1 : Dice
    {
        public DiceValue throwADice()
        {
            return DiceValue.MinusOne;
        }
    }
}
