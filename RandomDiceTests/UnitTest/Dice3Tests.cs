using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.Dices;
using RandomDice;

namespace RandomDiceTests.UnitTest
{
    [TestClass()]
    public class Dice3Tests
    {
        [TestMethod()]
        public void throw1d3Test()
        {
            Dice dice = new Dice3(new FakeRandomGenerator());
            Assert.AreEqual(DiceValue.PlusOne, dice.rollADice());
        }
    }
}