using System;

namespace RandomDice.Dices
{
    public class Dice0 : Dice
    {
        enum Dice0Value
        {
            PlusZero = DiceValue.Zero,
        }
        private IntervalRandomGenerator randomGenerator;

        public Dice0(IntervalRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public DiceValue throwADice()
        {
            Dice0Value value;

            int generatedNumber = 0;
            if (Enum.IsDefined(typeof(Dice0Value), generatedNumber) && Enum.IsDefined(typeof(DiceValue), generatedNumber))
            {
                value = (Dice0Value)generatedNumber;
            }
            else
                throw new InvalidDiceValueException("d0 value: " + generatedNumber);
            return (DiceValue)value;
        }
    }
}
