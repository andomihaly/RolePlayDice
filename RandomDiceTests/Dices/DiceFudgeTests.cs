using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RandomDice.Dices;

namespace RandomDice.Tests
{
    [TestClass()]
    public class DiceFudgeTests
    {
        [TestMethod()]
        public void throwAdf3Test()
        {
            Dice dice = new DiceFudge(new VisualStudioRandomGenerator());
            int dvalue = (int)dice.throwADice();
            for (int i = 0; i < 100; i++)
            {
                Assert.IsTrue(-1 <= dvalue && dvalue <= 1, "value not fit for dF:" + dvalue);
            }
        }
    }
}