using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using RolePlaySet.Entity;

namespace RolePlayFileBasedStorage.Tests
{
    [TestClass()]
    public class RolePlayFileStorageTests
    {
        [TestMethod()]
        public void fullFileTest()
        {

            string gameName = "unitTest";
            string path = Directory.GetCurrentDirectory() + "\\"+ gameName;
            DirectoryInfo directory = new DirectoryInfo(path);
            if (directory.Exists)
                directory.Delete(true);

            RolePlayFileStorage fs = new RolePlayFileStorage();

            fs.createNewGame(gameName);

            Player[] players =fs.loadPlayers(gameName);
            Assert.AreEqual("Name1", players[0].name);
            Assert.AreEqual("Skill1Name", players[0].skills[0].name);
            Assert.AreEqual(1, players[0].skills[0].score);
           
            Assert.AreEqual("Name2", players[1].name);
            Assert.AreEqual("Skill4Name", players[1].skills[3].name);
            Assert.AreEqual(-1, players[1].skills[3].score);
            Assert.AreEqual("Name4", players[3].name);

            Assert.AreEqual(0, players[3].skills.Count);
        }
    }
}
