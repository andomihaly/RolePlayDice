using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet.Core;
using RolePlaySetTests.Common;

namespace RolePlaySetTests.UnitTest
{
    [TestClass()]
    public class SimpleGamerTests
    {
        private SimpleGamer sg;

        [TestInitialize()]
        public void setup()
        {
            Dice[] dices = { new FakeDice() };
            sg = new SimpleGamer(new StubStoreGateway(), dices);
        }

        [TestMethod()]
        public void chechValidGameNameTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(null, sg.getPlayers());
            Assert.AreEqual(0, sg.getStory().Length);
            sg.loadGame("*");
            Assert.AreEqual(null, sg.getPlayers());
            Assert.AreEqual(0, sg.getStory().Length);
        }

        [TestMethod()]
        public void loadNotExistsGameNameTest()
        {
            sg.loadGame("InvalidGame");
            Assert.AreEqual(null, sg.getPlayers());
            Assert.AreEqual(0, sg.getStory().Length);
        }

        [TestMethod()]
        public void loadValidGameTest()
        {
            sg.loadGame("ValidGame");
            Assert.AreEqual(2, sg.getPlayers().Length);
            Assert.AreEqual(3, sg.getStory().Length);
        }

        [TestMethod()]
        public void getPlayerByValidNameTest()
        {
            sg.loadGame("ValidGame");
            string playerName = "A Player";
            Assert.AreEqual(playerName, sg.getPlayerByName(playerName).name);
        }

        [TestMethod()]
        public void getPlayerByInValidNameTest()
        {
            sg.loadGame("ValidGame");
            string invalidPlayerName = "Null Player";
            Assert.IsNull(sg.getPlayerByName(invalidPlayerName));
        }

        [TestMethod()]
        public void getPlayerByInValidNameWithourPlayersTest()
        {
            sg.loadGame("InValidGame");
            string invalidPlayerName = "Null Player";
            Assert.IsNull(sg.getPlayerByName(invalidPlayerName));
        }

        [TestMethod()]
        public void generateNewValidGameNameTest()
        {
            sg.generateNewGame("ValidName");
            sg.generateNewGame("*");
        }
    }
}