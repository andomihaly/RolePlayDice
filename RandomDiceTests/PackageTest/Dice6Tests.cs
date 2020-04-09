using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RandomDice.Dices;
using RandomDice;

namespace RandomDiceTests.PackageTest
{
    [TestClass()]
    public class Dice6Tests
    {
        [TestMethod()]
        public void throwSeverald3Test()
        {
            Dice dice = new Dice6(new VisualStudioRandomGenerator());
            for (int i=0; i<100; i++)
            {
                int dvalue = (int)dice.rollADice();
                Assert.IsTrue(1 <= dvalue && dvalue <= 6, "value not fit for d6:" + dvalue);
            }
        }
    }
}