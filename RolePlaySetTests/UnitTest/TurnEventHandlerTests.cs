using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet.Core;
using RolePlaySetTests.Common;

namespace RolePlaySetTests.UnitTest
{
    [TestClass()]
    public class TurnEventHandlerTests
    {
        [TestMethod()]
        public void generateTurnOpponentEvent()
        {
            Dice[] dices = { new Dice1() };
            TurnEventHandler teh = new TurnEventHandler(dices, new FakeTextBuilder());
            Assert.AreEqual("a|b|0|1|2|3|2|lose", teh.generateTurnOpponentEvent("a", "b", 0, 1, 2, "d1", 3, true));
            Assert.AreEqual("b|a|4|3|2|1|0|win", teh.generateTurnOpponentEvent("b", "a", 4, 3, 2, "d1", 1, false));
        }

        [TestMethod()]
        public void generateTurnTaskEventTest()
        {
            Dice[] dices = { new Dice1() };
            TurnEventHandler teh = new TurnEventHandler(dices, new FakeTextBuilder());
            Assert.AreEqual("a|b|0|1|2|c|7", teh.generateTurnTaskEvent("a", "b", 0, 1, 2, "d1", new RolePlayEntity.TaskType("c", 7)));
        }

        [TestMethod()]
        public void getBackTheLastRoll()
        {
            SpyUIPresenter spyRolledDice = new SpyUIPresenter();
            Dice[] dices = { new Dice1() };
            TurnEventHandler teh = new TurnEventHandler(dices, new FakeTextBuilder(), spyRolledDice);
            teh.generateTurnTaskEvent("a", "a", 0, 0, 1, "d1", new RolePlayEntity.TaskType("c", 7));

            Assert.AreEqual(2, spyRolledDice.lastRolledDices.Length);
            Assert.AreEqual("1", spyRolledDice.lastRolledDices[0,0]);
            Assert.AreEqual("d1", spyRolledDice.lastRolledDices[0, 1]);
            Assert.IsNull(spyRolledDice.lastMinusOneRolledDices);
        }
        [TestMethod()]
        public void getBackTheLastRolls()
        {
            SpyUIPresenter spyRolledDice = new SpyUIPresenter();
            Dice[] dices = { new Dice1() };
            TurnEventHandler teh = new TurnEventHandler(dices, new FakeTextBuilder(), spyRolledDice);
            teh.generateTurnTaskEvent("a", "a", 0, 0, 4, "d1", new RolePlayEntity.TaskType("c", 7));

            Assert.AreEqual(8, spyRolledDice.lastRolledDices.Length);
            Assert.AreEqual("1", spyRolledDice.lastRolledDices[0, 0]);
            Assert.AreEqual("d1", spyRolledDice.lastRolledDices[0, 1]);
            Assert.AreEqual("1", spyRolledDice.lastRolledDices[3, 0]);
            Assert.AreEqual("d1", spyRolledDice.lastRolledDices[3, 1]);
            Assert.IsNull(spyRolledDice.lastMinusOneRolledDices);
        }

        [TestMethod()]
        public void getBackTheLastRollsWithOpponent()
        {
            SpyUIPresenter spyRolledDice = new SpyUIPresenter();
            Dice[] dices = { new Dice1() };
            TurnEventHandler teh = new TurnEventHandler(dices, new FakeTextBuilder(), spyRolledDice);
            teh.generateTurnOpponentEvent("a", "a", 0, 0, 4, "d1",0,true);
            Assert.AreEqual(8, spyRolledDice.lastMinusOneRolledDices.Length);
            Assert.AreEqual("1", spyRolledDice.lastMinusOneRolledDices[0, 0]);
            Assert.AreEqual("d1", spyRolledDice.lastMinusOneRolledDices[0, 1]);
            Assert.AreEqual("1", spyRolledDice.lastMinusOneRolledDices[3, 0]);
            Assert.AreEqual("d1", spyRolledDice.lastMinusOneRolledDices[3, 1]);
        }
    }
}