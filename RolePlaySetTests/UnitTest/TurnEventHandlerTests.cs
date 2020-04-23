using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet.Core;
using RolePlaySetTests.Common;

namespace RolePlaySetTests.UnitTest
{
    [TestClass()]
    public class TurnEventHandlerTests
    {
        private SpyUIPresenter spyRolledDice;
        private Dice[] dices;
        private TurnEventHandler teh;
        [TestInitialize()]
        public void setup()
        {
            spyRolledDice = new SpyUIPresenter();
            Dice[] dices = { new Dice1() };
            this.dices = dices;
            teh = new TurnEventHandler(dices, new FakeTextBuilder(), spyRolledDice);
        }

        [TestMethod()]
        public void generateTurnOpponentEvent()
        {
            Assert.AreEqual("a|b|0|1|2|3|2|lose", teh.generateTurnOpponentEvent("a", "b", 0, 1, 2, "d1", 3, true));
            Assert.AreEqual("b|a|4|3|2|1|0|win", teh.generateTurnOpponentEvent("b", "a", 4, 3, 2, "d1", 1, false));
        }

        [TestMethod()]
        public void generateTurnTaskEventTest()
        {
            Assert.AreEqual("a|b|0|1|2|c|7", teh.generateTurnTaskEvent("a", "b", 0, 1, 2, "d1", new RolePlayEntity.TaskType("c", 7)));
        }

        [TestMethod()]
        public void getBackTheLastRoll()
        {
            
            teh.generateTurnTaskEvent("a", "a", 0, 0, 1, "d1", new RolePlayEntity.TaskType("c", 7));
            Assert.AreEqual(1, spyRolledDice.lastRolledDices.Length);
            Assert.AreEqual("1|d1|", spyRolledDice.lastRolledDices[0]);
        }
        [TestMethod()]
        public void getBackTheLastRolls()
        {
            teh.generateTurnTaskEvent("a", "a", 0, 0, 2, "d1", new RolePlayEntity.TaskType("c", 7));
            Assert.AreEqual(1, spyRolledDice.lastRolledDices.Length);
            Assert.AreEqual("1|d1|1|d1|", spyRolledDice.lastRolledDices[0]);
        }

        [TestMethod()]
        public void getBackTheLastRollsWithOpponent()
        { 
            teh.generateTurnOpponentEvent("a", "a", 0, 0, 2, "d1",0,true);
            Assert.AreEqual(2, spyRolledDice.lastRolledDices.Length);
            Assert.AreEqual("1|d1|1|d1|", spyRolledDice.lastRolledDices[0]);
            Assert.AreEqual("1|d1|1|d1|", spyRolledDice.lastRolledDices[1]);
        }

        [ExpectedException(typeof(NotSupportedDiceTypeException))]
        [TestMethod()]
        public void diceTypeIsNotExist()
        {
            teh.generateTurnOpponentEvent("a", "a", 0, 0, 2, "", 0, true);
        }
    }
}