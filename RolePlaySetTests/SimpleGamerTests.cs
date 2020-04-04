using Microsoft.VisualStudio.TestTools.UnitTesting;
using RolePlaySet;
using RolePlaySetTests;

namespace RolePlaySet.Tests
{
    [TestClass()]
    public class SimpleGamerTests
    {
        [TestMethod()]
        public void chechValidGameNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
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
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("InvalidGame");
            Assert.AreEqual(null, sg.getPlayers());
            Assert.AreEqual(0, sg.getStory().Length);
        }

        [TestMethod()]
        public void loadValidGameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("ValidGame");
            Assert.AreEqual(2, sg.getPlayers().Length);
            Assert.AreEqual(3, sg.getStory().Length);
        }

        [TestMethod()]
        public void getPlayerByValidNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("ValidGame");
            string playerName = "A Player";
            Assert.AreEqual(playerName, sg.getPlayerByName(playerName).name);
        }

        [TestMethod()]
        public void getPlayerByInValidNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("ValidGame");
            string invalidPlayerName = "Null Player";
            Assert.IsNull(sg.getPlayerByName(invalidPlayerName));
        }

        [TestMethod()]
        public void getPlayerByInValidNameWithourPlayersTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("InValidGame");
            string invalidPlayerName = "Null Player";
            Assert.IsNull(sg.getPlayerByName(invalidPlayerName));
        }

        [TestMethod()]
        public void generateNewValidGameNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.generateNewGame("ValidName");
            sg.generateNewGame("*");
        }
    }
}