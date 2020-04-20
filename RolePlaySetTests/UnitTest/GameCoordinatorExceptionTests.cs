using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet.Core;
using RolePlaySetTests.Common;

namespace RolePlaySetTests.UnitTest
{
    [TestClass()]
    public class GameCoordinatorExceptionTests
    {
        private RolePlayGameCoordinator sg;

        [TestInitialize()]
        public void setup()
        {
            Dice[] dices = { new FakeDice() };
            sg = new RolePlayGameCoordinator(new StubStoreGateway(), dices, new SpyUIPresenter());
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void chechEmptyGameNameTest()
        {
            sg.loadGame("");
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void chechNullGameNameTest()
        {
            sg.loadGame(null);
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void chechOnlySpacesGameNameTest()
        {
            sg.loadGame("   ");
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void generateNewEmptyGameNameTest()
        {
            sg.generateNewGame("");
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void generateNewNullGameNameTest()
        {
            sg.generateNewGame(null);
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void generateNewOnlySpacesGameNameTest()
        {
            sg.generateNewGame("   ");
        }
    }
}