using System;

namespace RandomDice.Dices
{
    public class Dice1 : Dice
    {
        enum Dice1Value
        {
            PlusOne = DiceValue.PlusOne,
        }
        private IntervalRandomGenerator randomGenerator;

        public Dice1(IntervalRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public DiceValue throwADice()
        {
            Dice1Value value;

            int generatedNumber = randomGenerator.generateRandomNumber(1, 1);
            if (Enum.IsDefined(typeof(Dice1Value), generatedNumber) && Enum.IsDefined(typeof(DiceValue), generatedNumber))
            {
                value = (Dice1Value)generatedNumber;
            }
            else
                throw new InvalidDiceValueException("d1 value: " + generatedNumber);
            return (DiceValue)value;
        }
    }
}
