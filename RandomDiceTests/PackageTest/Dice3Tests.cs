using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RandomDice.Dices;
using RandomDice;

namespace RandomDiceTests.PackageTest
{
    [TestClass()]
    public class Dice3Tests
    {
        [TestMethod()]
        public void throwSeverald3Test()
        {
            Dice dice = new Dice3(new VisualStudioRandomGenerator());
            for (int i=0; i<100; i++)
            { 
                int dvalue = (int)dice.throwADice();
                Assert.IsTrue(1 <= dvalue && dvalue <= 3, "value not fit for d3:" + dvalue);
            }
        }
    }
}