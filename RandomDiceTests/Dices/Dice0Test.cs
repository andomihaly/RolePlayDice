using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RandomDice.Dices;

namespace RandomDice.Tests
{
    [TestClass()]
    public class Dice0Tests
    {
        [TestMethod()]
        public void throwAd0Test()
        {
            Dice dice = new Dice0();
            int dvalue = (int)dice.throwADice();
            for (int i=0; i<100; i++)
            { 
                Assert.IsTrue(0 <= dvalue && dvalue <= 0, "value not fit for d0:" + dvalue);
            }
        }
    }
}