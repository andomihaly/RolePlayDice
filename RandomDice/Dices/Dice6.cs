using System;

namespace RandomDice.Dices
{
    public class Dice6 : Dice
    {
        enum Dice6Value
        {
            PlusOne = DiceValue.PlusOne,
            PlusTwo = DiceValue.PlusTwo,
            PlusThree = DiceValue.PlusThree,
        }
        private IntervalRandomGenerator randomGenerator;

        public Dice6(IntervalRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public DiceValue throwADice()
        {
            Dice6Value value;

            int generatedNumber = randomGenerator.generateRandomNumber(1, 3);
            if (Enum.IsDefined(typeof(Dice6Value), generatedNumber) && Enum.IsDefined(typeof(DiceValue), generatedNumber))
            {
                value = (Dice6Value)generatedNumber;
            }
            else
                throw new InvalidDiceValueException("d6 value: " + generatedNumber);
            return (DiceValue)value;
        }
    }
}
