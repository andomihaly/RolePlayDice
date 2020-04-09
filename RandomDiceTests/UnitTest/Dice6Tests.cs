using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.Dices;
using RandomDice;

namespace RandomDiceTests.UnitTest
{
    [TestClass()]
    public class Dice6Tests
    {
        [TestMethod()]
        public void throw1d6Test()
        {
            Dice dice = new Dice6(new FakeRandomGenerator());
            Assert.AreEqual(DiceValue.PlusOne, dice.rollADice());
        }
    }
}