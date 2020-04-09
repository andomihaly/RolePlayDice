using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RandomDice.Dices;
using RandomDice;

namespace RandomDiceTests.PackageTest
{
    [TestClass()]
    public class DiceFudgeTests
    {
        [TestMethod()]
        public void throwSeveraldf3Test()
        {
            Dice dice = new DiceFudge(new VisualStudioRandomGenerator());
            for (int i = 0; i < 100; i++)
            {
                int dvalue = (int)dice.rollADice();
                Assert.IsTrue(-1 <= dvalue && dvalue <= 1, "value not fit for dF:" + dvalue);
            }
        }
    }
}