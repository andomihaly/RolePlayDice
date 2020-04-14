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

        [TestInitialize()]
        public void setup()
        {
            Dice[] dices = { new FakeDice() };
            gameCoordinator = new RolePlayGameCoordinator(new StubStoreGateway(), dices);
        }

        [TestMethod()]
        public void chechValidGameNameTest()
        {
            gameCoordinator.loadGame("ValidName");
            Assert.AreEqual(0, gameCoordinator.getPlayers().Length);
            Assert.AreEqual(0, gameCoordinator.getStory().Length);
            gameCoordinator.loadGame("*");
            Assert.AreEqual(0, gameCoordinator.getPlayers().Length);
            Assert.AreEqual(0, gameCoordinator.getStory().Length);
        }

        [TestMethod()]
        public void loadNotExistsGameNameTest()
        {
            gameCoordinator.loadGame("InvalidGame");
            Assert.AreEqual(0, gameCoordinator.getPlayers().Length);
            Assert.AreEqual(0, gameCoordinator.getStory().Length);
        }

        [TestMethod()]
        public void loadValidGameTest()
        {
            gameCoordinator.loadGame("ValidGame");
            Assert.AreEqual(4, gameCoordinator.getPlayers().Length);
            Assert.AreEqual(3, gameCoordinator.getStory().Length);
        }

        [TestMethod()]
        public void getPlayerSkillByValidNameTest()
        {
            gameCoordinator.loadGame("ValidGame");
            string playerName = gameCoordinator.getPlayers()[0,0];
            Assert.AreEqual(1, gameCoordinator.getPlayerSkillsByPlayerName(playerName).Length/2);
        }

        [TestMethod()]
        public void getPlayerSkillByValidGameNameAndNoPlayerTest()
        {
            gameCoordinator.loadGame("ValidGame");
            string invalidPlayerName = "Null Player";
            Assert.AreEqual(0,gameCoordinator.getPlayerSkillsByPlayerName(invalidPlayerName).Length);
        }

        [TestMethod()]
        public void getPlayerSkillByInvalidNameAndNoPlayersTest()
        {
            gameCoordinator.loadGame("InValidGame");
            string invalidPlayerName = "Null Player";
            Assert.AreEqual(0,gameCoordinator.getPlayerSkillsByPlayerName(invalidPlayerName).Length);
        }


        [TestMethod()]
        public void diceNameListTest()
        {
            Assert.AreEqual(1, gameCoordinator.getAvailableDiceName().Length);
            Assert.AreEqual("fakeDice", gameCoordinator.getAvailableDiceName()[0]);
            
        }

        [TestMethod()]
        public void addNarration()
        {
            gameCoordinator.loadGame("ValidGame");
            string narration = "AM";
            Assert.AreEqual(3, gameCoordinator.getStory().Length);
            gameCoordinator.addNarration(narration);
            Assert.AreEqual(4, gameCoordinator.getStory().Length);
            Assert.AreEqual(narration, gameCoordinator.getStory()[gameCoordinator.getStory().Length-1]);
        }
    }
}
