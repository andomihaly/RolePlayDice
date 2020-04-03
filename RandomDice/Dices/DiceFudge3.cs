using System;

namespace RandomDice.Dices
{
    public class DiceFudge3 : Dice
    {
        enum DiceFudge3Value
        {
            MinusOne = DiceValue.MinusOne,
            Zero = DiceValue.Zero,
            PlusOne = DiceValue.PlusOne,
        }
        private IntervalRandomGenerator randomGenerator;

        public DiceFudge3(IntervalRandomGenerator randomGenerator)
        {
            this.randomGenerator = randomGenerator;
        }

        public DiceValue throwADice()
        {
            DiceFudge3Value value;

            int generatedNumber = randomGenerator.generateRandomNumber(-1, 1);
            if (Enum.IsDefined(typeof(DiceFudge3Value), generatedNumber) && Enum.IsDefined(typeof(DiceValue), generatedNumber))
            {
                value = (DiceFudge3Value)generatedNumber;
            }
            else
                throw new InvalidDiceValueException("df3-value: " + generatedNumber);
            return (DiceValue)value;
        }
    }
}
