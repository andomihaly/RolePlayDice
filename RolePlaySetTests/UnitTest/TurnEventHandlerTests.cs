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
    }
}