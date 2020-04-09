using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlayEntity;
using RolePlayFileBasedStorage;
using RolePlaySet.Core;
using RolePlaySetTests.Common;
using System;
using System.IO;

namespace RolePlaySetTests.SystemTest
{
    [TestClass()]
    public class GameCoordinatorTaskEvent
    {
        private RolePlayGameCoordinator rolePlayGameCoordinator;
        private static string GAME_NAME="system_test";

        [TestInitialize()]
        public void setup()
        {
            Dice[] dices = { new DiceMinus1(), new Dice1() };
            string path = Directory.GetCurrentDirectory() + "\\" + GAME_NAME;
            DirectoryInfo directory = new DirectoryInfo(path);
            if (directory.Exists)
                directory.Delete(true);

            rolePlayGameCoordinator = new RolePlayGameCoordinator(new RolePlayFileStorage(), dices);
            rolePlayGameCoordinator.generateNewGame(GAME_NAME);
            
        }

        [TestMethod()]
        public void drawGameWithoutThrowTest()
        {
            Assert.AreEqual(0, rolePlayGameCoordinator.getStory().Length);
            rolePlayGameCoordinator.addTurnTaskEvent("", "", 0, 0, 0, "d3", new TaskType("Szuper",+1));

            Assert.AreEqual(1, rolePlayGameCoordinator.getStory().Length);
            Assert.AreEqual("Játékosnak nem sikerült a szuper feladat (0 vs. 1)!" + Environment.NewLine.ToString() +
                "Részletek: Játékos: 0 AP, szuper feladat: 1 P",
                rolePlayGameCoordinator.getStory()[0]);
        }
        
        [TestMethod()]
        public void complexGameWithoutThrowTest()
        {
            Assert.AreEqual(0, rolePlayGameCoordinator.getStory().Length);
            rolePlayGameCoordinator.addTurnTaskEvent(("Micsoda Csata" + Environment.NewLine.ToString() + " Volt"), "Doki", 3, 4, 0, "d1", new TaskType("Szuper", +5));
            Assert.AreEqual(1, rolePlayGameCoordinator.getStory().Length);
            Assert.AreEqual("Doki sikeresen elvégezte a szuper feladatot (7 vs. 5)!" + Environment.NewLine.ToString() + 
                "Micsoda Csata" + Environment.NewLine.ToString() + " Volt" + Environment.NewLine.ToString() +
                "Részletek: Doki: 3 AP + 4 EP, szuper feladat: 5 P",
                rolePlayGameCoordinator.getStory()[0]);
        }
        
        [TestMethod()]
        public void simpleGameWithOneThrowTest()
        {
            Assert.AreEqual(0, rolePlayGameCoordinator.getStory().Length);
            rolePlayGameCoordinator.addTurnTaskEvent("Ásás", "Béla", 0, 0, 1, "d1", new TaskType("Átlagos", +1));
            Assert.AreEqual(1, rolePlayGameCoordinator.getStory().Length);
            Assert.AreEqual("Béla sikeresen elvégezte az átlagos feladatot (1 vs. 1)!" + Environment.NewLine.ToString() + 
                "Ásás" + Environment.NewLine.ToString() +
                "Részletek: Béla: 0 AP + 1 DP, átlagos feladat: 1 P",
                rolePlayGameCoordinator.getStory()[0]);
        }

        [TestMethod()]
        public void simpleGameWithMinusDiceThrowTest()
        {
            Assert.AreEqual(0, rolePlayGameCoordinator.getStory().Length);
            rolePlayGameCoordinator.addTurnTaskEvent("Ásás", "Béla", 0, 0, 4, "dM1", new TaskType("Átlagos", +1));
            Assert.AreEqual(1, rolePlayGameCoordinator.getStory().Length);
            Assert.AreEqual("Bélanak nem sikerült az átlagos feladat (-4 vs. 1)!" + Environment.NewLine.ToString() +
                "Ásás" + Environment.NewLine.ToString() +
                "Részletek: Béla: 0 AP + -4 DP, átlagos feladat: 1 P",
                rolePlayGameCoordinator.getStory()[0]);
        }

        private void AssertBasedOnCharacter(string expected, string actual)
        {
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], "index:" + i.ToString() + "-Char act: " + (actual[i] + 1).ToString() + "-Char exp: " + (expected[i] + 1).ToString() + "substring: " + expected.Substring(0, i));
            }
        }
    }
}