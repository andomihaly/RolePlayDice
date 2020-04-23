using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet.Core;
using RolePlaySetTests.Common;

namespace RolePlaySetTests.PackageTest
{
    [TestClass()]
    public class GameCoordinatorPackageTests
    {
        [TestMethod()]
        public void addTurnTaskEventTest()
        {
            SpyUIPresenter spyRolledDice = new SpyUIPresenter();
            Dice[] dices = { new Dice1() };
            Assert.AreEqual(0, spyRolledDice.lastStory.Length);
            RolePlayGameCoordinator gameCoordinator = new RolePlayGameCoordinator(new StubStoreGateway(), dices, spyRolledDice);
            gameCoordinator.addTurnTaskEvent("a", "a", 0, 0, 1, "d1", "Átlagos");
            Assert.AreEqual("", spyRolledDice.lastErrorCode);
            Assert.AreEqual(1, spyRolledDice.lastStory.Length);
            Assert.AreEqual(1, spyRolledDice.lastRolledDices.Length);
        }

        [TestMethod()]
        public void addTurnOpponentEventTest()
        {
            SpyUIPresenter spyRolledDice = new SpyUIPresenter();
            Dice[] dices = { new Dice1() };
            Assert.AreEqual(0, spyRolledDice.lastStory.Length);
            RolePlayGameCoordinator gameCoordinator = new RolePlayGameCoordinator(new StubStoreGateway(), dices, spyRolledDice);
            gameCoordinator.addTurnOpponentEvent("a", "a", 0, 1, 1, "d1", 0, false);
            Assert.AreEqual("", spyRolledDice.lastErrorCode);
            Assert.AreEqual(1, spyRolledDice.lastStory.Length);
            Assert.AreEqual(1, spyRolledDice.lastRolledDices.Length);
        }

        [TestMethod()]
        public void throwWithNotExistsDiceTest()
        {
            SpyUIPresenter spyRolledDice = new SpyUIPresenter();
            Dice[] dices = { new Dice1() };
            Assert.AreEqual(0, spyRolledDice.lastStory.Length);
            RolePlayGameCoordinator gameCoordinator = new RolePlayGameCoordinator(new StubStoreGateway(), dices, spyRolledDice);
            gameCoordinator.addTurnOpponentEvent("a", "a", 0, 1, 1, "1", 0, false);
            Assert.AreEqual("NotSupportedDiceType|1", spyRolledDice.lastErrorCode);
        }
    }
}
