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
        public void chechValidGameNameTest()
        {
            gameCoordinator.loadGame("ValidName");
            Assert.AreEqual(3, spyUIPresenter.lastGameContext.Length);
            Assert.AreEqual(0, spyUIPresenter.lastStory.Length);
            gameCoordinator.loadGame("*");
            Assert.AreEqual(3, spyUIPresenter.lastGameContext.Length);
            Assert.AreEqual(0, spyUIPresenter.lastStory.Length);
        }

        [TestMethod()]
        public void loadNotExistsGameNameTest()
        {
            gameCoordinator.loadGame("InvalidGame");
            Assert.AreEqual(3, spyUIPresenter.lastGameContext.Length);
            Assert.AreEqual(0, spyUIPresenter.lastStory.Length);
        }

        [TestMethod()]
        public void loadValidGameTest()
        {
            gameCoordinator.loadGame("ValidGame");
            Assert.AreEqual(3, spyUIPresenter.lastStory.Length);
            Assert.AreEqual(5, spyUIPresenter.lastGameContext.Length);
            Assert.AreEqual("A Player||b|0|", spyUIPresenter.lastGameContext[3]);
            Assert.AreEqual("A Player||b|0|", spyUIPresenter.lastGameContext[4]);
            
        }

        [TestMethod()]
        public void diceNameListTest()
        {
            gameCoordinator.loadGame("InvalidGame");
            Assert.AreEqual(3, spyUIPresenter.lastGameContext.Length);
            Assert.AreEqual("fakeDice|", spyUIPresenter.lastGameContext[2]);
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
