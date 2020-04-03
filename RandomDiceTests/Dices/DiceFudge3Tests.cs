using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RandomDice.Dices;

namespace RandomDice.Tests
{
    [TestClass()]
    public class DiceFudge3Tests
    {
        [TestMethod()]
        public void throwAdf3Test()
        {
            Dice dice = new DiceFudge3(new VisualStudioRandomGenerator());
            int dvalue = (int)dice.throwADice();
            for (int i = 0; i < 100; i++)
            {
                Assert.IsTrue(-1 <= dvalue && dvalue <= 1, "value not fit for df3:" + dvalue);
            }
        }
    }
}