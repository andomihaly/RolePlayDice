using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet;
using RolePlaySet.Core;
using RolePlaySetTests.Common;

namespace RolePlaySetTests.UnitTest
{
    [TestClass()]
    public class GameCoordinatorExceptionTests
    {
        private RolePlayGameCoordinator rolePlayCoordinator;
        private SpyUIPresenter spyUIPresenter;

        [TestInitialize()]
        public void setup()
        {
            Dice[] dices = { new FakeDice() };
            spyUIPresenter = new SpyUIPresenter();
            rolePlayCoordinator = new RolePlayGameCoordinator(new StubStoreGateway(), dices, spyUIPresenter);
        }

        [TestMethod()]
        public void chechEmptyGameNameTest()
        {
            rolePlayCoordinator.loadGame("");
            Assert.AreEqual(ErrorCode.GameNameIsNotValid.ToString(), spyUIPresenter.lastErrorCode);
        }

        [TestMethod()]
        public void chechNullGameNameTest()
        {
            rolePlayCoordinator.loadGame(null);
            Assert.AreEqual(ErrorCode.GameNameIsNotValid.ToString(), spyUIPresenter.lastErrorCode);
        }

        [TestMethod()]
        public void chechOnlySpacesGameNameTest()
        {
            rolePlayCoordinator.loadGame("   ");
            Assert.AreEqual(ErrorCode.GameNameIsNotValid.ToString(), spyUIPresenter.lastErrorCode);
        }
        
        [TestMethod()]
        public void loadGameWithValidNameButGameNotExistsTest()
        {
            rolePlayCoordinator.loadGame("fake_game");
            Assert.AreEqual(ErrorCode.GameIsNotFound.ToString()+"|fake_game", spyUIPresenter.lastErrorCode);
        }

        [TestMethod()]
        public void generateNewEmptyGameNameTest()
        {
            rolePlayCoordinator.generateNewGame("");
            Assert.AreEqual(ErrorCode.GameNameIsNotValid.ToString(), spyUIPresenter.lastErrorCode);
        }

        [TestMethod()]
        public void generateNewNullGameNameTest()
        {
            rolePlayCoordinator.generateNewGame(null);
            Assert.AreEqual(ErrorCode.GameNameIsNotValid.ToString(), spyUIPresenter.lastErrorCode);
        }

        [TestMethod()]
        public void generateNewOnlySpacesGameNameTest()
        {
            rolePlayCoordinator.generateNewGame("   ");
            Assert.AreEqual(ErrorCode.GameNameIsNotValid.ToString(), spyUIPresenter.lastErrorCode);
        }

        [TestMethod()]
        public void errorDuringCreateingNewGameTest()
        {
            rolePlayCoordinator.generateNewGame("createingNewGameIssue");
            Assert.AreEqual(ErrorCode.CouldNotCreateNewGame.ToString()+ "|createingNewGameIssue", spyUIPresenter.lastErrorCode);
        }
    }
}