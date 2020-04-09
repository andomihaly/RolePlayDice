using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.Dices;
using RandomDice;

namespace RandomDiceTests.UnitTest
{
    [TestClass()]
    public class DiceFudgeTests
    {
        [TestMethod()]
        public void throw1dF3Test()
        {
            Dice dice = new DiceFudge(new FakeRandomGenerator());
            Assert.AreEqual(DiceValue.PlusOne, dice.rollADice());
        }
    }
}