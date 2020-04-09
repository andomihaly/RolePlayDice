using System;

namespace RandomDice.Dices
{
    public class DiceFudge : Dice
    {
        public string getName()
        {
            return "dF";
        }

        enum DiceFudge3Value
        {
            MinusOne = DiceValue.MinusOne,
            Zero = DiceValue.Zero,
            PlusOne = DiceValue.PlusOne,
        }
        private IntervalRandomGenerator randomGenerator;

        public DiceFudge(IntervalRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public DiceValue rollADice()
        {
            DiceFudge3Value value;

            int generatedNumber = randomGenerator.generateRandomNumber(-1, 1);
            if (Enum.IsDefined(typeof(DiceFudge3Value), generatedNumber) && Enum.IsDefined(typeof(DiceValue), generatedNumber))
            {
                value = (DiceFudge3Value)generatedNumber;
            }
            else
                throw new InvalidDiceValueException("dF-value: " + generatedNumber);
            return (DiceValue)value;
        }
    }
}
