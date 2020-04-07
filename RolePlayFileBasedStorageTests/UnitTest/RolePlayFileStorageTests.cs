using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using RolePlayEntity;
using RolePlayFileBasedStorage;

namespace RolePlayFileBasedStorageTests.UnitTest
{
    [TestClass()]
    public class RolePlayFileStorageTests
    {
        [TestMethod()]
        public void fullFileTest()
        {

            string gameName = "unitTest";
            string path = Directory.GetCurrentDirectory() + "\\" + gameName;
            DirectoryInfo directory = new DirectoryInfo(path);
            if (directory.Exists)
                directory.Delete(true);

            RolePlayFileStorage fs = new RolePlayFileStorage();

            fs.createNewGame(gameName);

            Player[] players = fs.loadPlayers(gameName);
            Assert.AreEqual("Name1", players[0].name);
            Assert.AreEqual("Skill1Name", players[0].skills[0].name);
            Assert.AreEqual(1, players[0].skills[0].score);
            Assert.AreEqual("", players[0].image);

            Assert.AreEqual("Name2", players[1].name);
            Assert.AreEqual("Skill4Name", players[1].skills[3].name);
            Assert.AreEqual(-1, players[1].skills[3].score);
            Assert.AreEqual(path + "\\actorW275xH400px.jpg", players[1].image);
            
            
            Assert.AreEqual("", players[2].image);

            Assert.AreEqual("Name4", players[3].name);
            Assert.AreEqual(0, players[3].skills.Count);

            Assert.IsTrue(File.Exists(path + "\\default.png"),"Default image is not there!");


        }
    }
}
