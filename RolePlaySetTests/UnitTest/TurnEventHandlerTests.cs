using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet.Core;
using RolePlaySetTests.Common;

namespace RolePlaySetTests.UnitTest
{
    [TestClass()]
    public class TurnEventHandlerTests
    {
        private Dice[] dices;
        private TurnEventHandler teh;
        [TestInitialize()]
        public void setup()
        {
            Dice[] dices = { new Dice1() };
            this.dices = dices;
            teh = new TurnEventHandler(dices, new FakeTextBuilder());
        }

        [TestMethod()]
        public void generateTurnOpponentEventWinTest()
        {
            CalculatedTurnResult ctr = teh.generateTurnOpponentEvent("b", "a", 4, 3, 2, "d1", 1, false);
            Assert.AreEqual("b|a|4|3|2|1|0|win", ctr.generatedText);
            Assert.AreEqual(1, ctr.rolledDices.Length);
            Assert.AreEqual("1|d1|1|d1|", ctr.rolledDices[0]);
        }

        [TestMethod()]
        public void generateTurnOpponentEventLoseTest()
        {
            CalculatedTurnResult ctr = teh.generateTurnOpponentEvent("a", "b", 0, 1, 1, "d1", 3, true);
            Assert.AreEqual("a|b|0|1|1|3|1|lose", ctr.generatedText);
            Assert.AreEqual(2, ctr.rolledDices.Length);
            Assert.AreEqual("1|d1|", ctr.rolledDices[0]);
            Assert.AreEqual("1|d1|", ctr.rolledDices[1]);
        }
        [TestMethod()]
        public void generateTurnOpponentEventDrawTest()
        {
            CalculatedTurnResult ctr = teh.generateTurnOpponentEvent("a", "a", 0, 0, 2, "d1", 0, true);
            Assert.AreEqual("a|a|0|0|2|0|2|draw", ctr.generatedText);
            Assert.AreEqual(2, ctr.rolledDices.Length);
            Assert.AreEqual("1|d1|1|d1|", ctr.rolledDices[0]);
            Assert.AreEqual("1|d1|1|d1|", ctr.rolledDices[1]);
        }

        [TestMethod()]
        public void generateTurnTaskEventTest()
        {
            CalculatedTurnResult ctr = teh.generateTurnTaskEvent("a", "b", 0, 1, 2, "d1", new RolePlayEntity.TaskType("c", 7));
            Assert.AreEqual("a|b|0|1|2|c|7", ctr.generatedText);
            Assert.AreEqual(1, ctr.rolledDices.Length);
            Assert.AreEqual("1|d1|1|d1|", ctr.rolledDices[0]);
        }

        [TestMethod()]
        public void getBackTheLastRollTest()
        {

            CalculatedTurnResult ctr = teh.generateTurnTaskEvent("c", "d", 5, 5, 1, "d1", new RolePlayEntity.TaskType("z", 5));
            Assert.AreEqual("c|d|5|5|1|z|5", ctr.generatedText);
            Assert.AreEqual(1, ctr.rolledDices.Length);
            Assert.AreEqual("1|d1|", ctr.rolledDices[0]);
        }

        [ExpectedException(typeof(NotSupportedDiceTypeException))]
        [TestMethod()]
        public void diceTypeIsNotExistTest()
        {
            teh.generateTurnOpponentEvent("a", "a", 0, 0, 2, "", 0, true);
        }
    }
}