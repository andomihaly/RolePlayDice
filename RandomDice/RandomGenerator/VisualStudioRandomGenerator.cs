using System;

namespace RandomDice.RandomGenerator
{
    public class VisualStudioRandomGenerator : IntervalRandomGenerator
    {
        private Random randomGenerator;

        public VisualStudioRandomGenerator()
        {
            this.randomGenerator = new Random();
        }

        public int generateRandomNumber(int lowerBound, int upperBound)
        {
            return randomGenerator.Next(lowerBound, upperBound+1);
        }
    }
}
