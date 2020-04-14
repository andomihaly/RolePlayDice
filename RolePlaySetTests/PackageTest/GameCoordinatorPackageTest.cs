using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet.Core;
using RolePlaySetTests.Common;

namespace RolePlaySetTests.PackageTest
{
    [TestClass()]
    class GameCoordinatorPackageTest
    {
        [TestMethod()]
        public void rolledDice()
        {
            SpyRolledDice spyRolledDice = new SpyRolledDice();
            Dice[] dices = { new Dice1() };
            RolePlayGameCoordinator gameCoordinator = new RolePlayGameCoordinator(new StubStoreGateway(), dices, spyRolledDice);
            gameCoordinator.addTurnTaskEvent("a", "a", 0, 0, 1, "d1", "Átlagos");

            Assert.AreEqual(2, spyRolledDice.lastRolledDices.Length);
            Assert.AreEqual(2, spyRolledDice.lastRolledDices.Length);


        }
    }
}
