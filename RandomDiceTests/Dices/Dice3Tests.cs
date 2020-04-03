using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RandomDice.Dices;

namespace RandomDice.Tests
{
    [TestClass()]
    public class Dice3Tests
    {
        [TestMethod()]
        public void throwAd3Test()
        {
            Dice dice = new Dice3(new VisualStudioRandomGenerator());
            int dvalue = (int)dice.throwADice();
            for (int i=0; i<100; i++)
            { 
                Assert.IsTrue(1 <= dvalue && dvalue <= 3, "value not fit for d3:" + dvalue);
            }
        }
    }
}