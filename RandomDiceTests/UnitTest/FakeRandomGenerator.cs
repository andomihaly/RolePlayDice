namespace RandomDiceTests.UnitTest
{
    class FakeRandomGenerator : RandomDice.IntervalRandomGenerator
    {
        public int generateRandomNumber(int lowerBound, int upperBound)
        {
            return 1;
        }
    }
}
