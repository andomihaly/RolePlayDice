using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RandomDice.Dices;

namespace RandomDice.Tests
{
    [TestClass()]
    public class Dice1Tests
    {
        [TestMethod()]
        public void throwAd1Test()
        {
            Dice dice = new Dice1();
            int dvalue = (int)dice.throwADice();
            for (int i=0; i<100; i++)
            { 
                Assert.IsTrue(1 <= dvalue && dvalue <= 1, "value not fit for d1:" + dvalue);
            }
        }
    }
}