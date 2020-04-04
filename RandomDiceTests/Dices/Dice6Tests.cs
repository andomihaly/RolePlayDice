using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RandomDice.Dices;

namespace RandomDice.Tests
{
    [TestClass()]
    public class Dice6Tests
    {
        [TestMethod()]
        public void throwAd3Test()
        {
            Dice dice = new Dice6(new VisualStudioRandomGenerator());
            int dvalue = (int)dice.throwADice();
            for (int i=0; i<100; i++)
            { 
                Assert.IsTrue(1 <= dvalue && dvalue <= 6, "value not fit for d6:" + dvalue);
            }
        }
    }
}