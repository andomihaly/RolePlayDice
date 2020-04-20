using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet.Core;
using RolePlaySetTests.Common;

namespace RolePlaySetTests.UnitTest
{
    [TestClass()]
    public class GameCoordinatorTests
    {
        private RolePlayGameCoordinator gameCoordinator;
        private SpyUIPresenter spyUIPresenter;

        [TestInitialize()]
        public void setup()
        {
            spyUIPresenter = new SpyUIPresenter();
            Dice[] dices = { new FakeDice() };
            gameCoordinator = new RolePlayGameCoordinator(new StubStoreGateway(), dices, spyUIPresenter);
        }

        [TestMethod()]
        public void initRolePlayBoardTest()
        {
            gameCoordinator.initRolePlayBoard();
            Assert.AreEqual("fakeDice|", spyUIPresenter.lastInitContext[0]);
            Assert.AreEqual("Legendás|8|Epikus|7|Fantasztikus|6|Szuper|5|Nagyszerű|4|Jó|3|Fair|2|Átlagos|1|Középszerű|0|Gyenge|-1|Szörnyű|-2|", 
                spyUIPresenter.lastInitContext[1]);
        }

        [TestMethod()]
        public void chechValidGameNameWithInvalidCharacterTest()
        {
            gameCoordinator.loadGame("*");
            Assert.AreEqual(2, spyUIPresenter.lastGameContext.Length);
            Assert.AreEqual("_", spyUIPresenter.lastGameContext[0]);
            Assert.AreEqual(0, spyUIPresenter.lastStory.Length);
        }

        [TestMethod()]
        public void loadValidGameTest()
        {
            gameCoordinator.loadGame("ValidGame");
            Assert.AreEqual(3, spyUIPresenter.lastStory.Length);
            Assert.AreEqual(4, spyUIPresenter.lastGameContext.Length);
            Assert.AreEqual("ValidGame", spyUIPresenter.lastGameContext[0]);
            Assert.AreEqual("", spyUIPresenter.lastGameContext[1]);
            Assert.AreEqual("A Player||b|0|", spyUIPresenter.lastGameContext[2]);
            Assert.AreEqual("A Player||b|0|", spyUIPresenter.lastGameContext[3]);
        }

        [TestMethod()]
        public void loadGameWithNotExistsGameNameTest()
        {
            gameCoordinator.loadGame("InvalidGame");
            Assert.AreEqual(2, spyUIPresenter.lastGameContext.Length);
            Assert.AreEqual("InvalidGame", spyUIPresenter.lastGameContext[0]);
            Assert.AreEqual("", spyUIPresenter.lastGameContext[1]);
            Assert.AreEqual(0, spyUIPresenter.lastStory.Length);
        }

        [TestMethod()]
        public void addNarration()
        {
            gameCoordinator.loadGame("ValidGame");
            string narration = "AM";
            Assert.AreEqual(3, spyUIPresenter.lastStory.Length);
            gameCoordinator.addNarration(narration);
            int numberOfStory = spyUIPresenter.lastStory.Length;
            Assert.AreEqual(4, numberOfStory);
            Assert.AreEqual(narration, spyUIPresenter.lastStory[numberOfStory - 1]);
        }
    }
}
