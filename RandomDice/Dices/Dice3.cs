using System;

namespace RandomDice.Dices
{
    public class Dice3 : Dice
    {
        public string getName()
        {
            return "d3";
        }

        enum Dice3Value
        {
            PlusOne = DiceValue.PlusOne,
            PlusTwo = DiceValue.PlusTwo,
            PlusThree = DiceValue.PlusThree,
        }
        private IntervalRandomGenerator randomGenerator;

        public Dice3(IntervalRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public DiceValue throwADice()
        {
            Dice3Value value;

            int generatedNumber = randomGenerator.generateRandomNumber(1, 3);
            if (Enum.IsDefined(typeof(Dice3Value), generatedNumber) && Enum.IsDefined(typeof(DiceValue), generatedNumber))
            {
                value = (Dice3Value)generatedNumber;
            }
            else
                throw new InvalidDiceValueException("d3 value: " + generatedNumber);
            return (DiceValue)value;
        }
    }
}
