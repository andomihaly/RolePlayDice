using System;

namespace RandomDice.Dices
{
    public class Dice6 : Dice
    {
        public string getName()
        {
            return "d6";
        }

        enum Dice6Value
        {
            PlusOne = DiceValue.PlusOne,
            PlusTwo = DiceValue.PlusTwo,
            PlusThree = DiceValue.PlusThree,
            PlusFour = DiceValue.PlusFour,
            PlusFive = DiceValue.PlusFive,
            PlusSix = DiceValue.PlusSix,
        }
        private IntervalRandomGenerator randomGenerator;

        public Dice6(IntervalRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public DiceValue throwADice()
        {
            Dice6Value value;

            int generatedNumber = randomGenerator.generateRandomNumber(1, 6);
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
