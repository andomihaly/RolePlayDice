using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlayEntity;
using RolePlaySet;
using RolePlaySet.Core;
using System;

namespace RolePlaySetTests
{
    [TestClass()]
    public class TurnEventHandlerTaskEvent
    {
        private TurnEventHandler turnEventHandler;

        [TestInitialize()]
        public void setup()
        {
            Dice[] dices = { new DiceMinus1(), new Dice1() };
            turnEventHandler = new TurnEventHandler(dices, new NewTurnHuTextBuilder());
        }

        [TestMethod()]
        public void drawGameWithoutThrowTest()
        {            
            string eventText = turnEventHandler.generateTurnTaskEvent("", "", 0, 0, 0, "d3", new TaskType("Szuper",+1));
            Assert.AreEqual("Játékosnak nem sikerült a szuper feladat (0 vs. 1)!" + Environment.NewLine.ToString() +
                "Részletek: Játékos: 0 AP, szuper feladat: 1 P",
                eventText);
        }
        
        [TestMethod()]
        public void complexGameWithoutThrowTest()
        {
            string eventText = turnEventHandler.generateTurnTaskEvent(("Micsoda Csata" + Environment.NewLine.ToString() + " Volt"), "Doki", 3, 4, 0, "d1", new TaskType("Szuper", +5));
            Assert.AreEqual("Doki sikeresen elvégezte a szuper feladatot (7 vs. 5)!" + Environment.NewLine.ToString() + 
                "Micsoda Csata" + Environment.NewLine.ToString() + " Volt" + Environment.NewLine.ToString() +
                "Részletek: Doki: 3 AP + 4 EP, szuper feladat: 5 P",
                eventText);
        }
        
        [TestMethod()]
        public void simpleGameWithOneThrowTest()
        {
            string eventText = turnEventHandler.generateTurnTaskEvent("Ásás", "Béla", 0, 0, 1, "d1", new TaskType("Átlagos", +1));
            Assert.AreEqual("Béla sikeresen elvégezte az átlagos feladatot (1 vs. 1)!" + Environment.NewLine.ToString() + 
                "Ásás" + Environment.NewLine.ToString() +
                "Részletek: Béla: 0 AP + 1 DP, átlagos feladat: 1 P",
                eventText);
        }

        [TestMethod()]
        public void simpleGameWithMinusDiceThrowTest()
        {
            string eventText = turnEventHandler.generateTurnTaskEvent("Ásás", "Béla", 0, 0, 4, "dM1", new TaskType("Átlagos", +1));
            Assert.AreEqual("Bélanak nem sikerült az átlagos feladat (-4 vs. 1)!" + Environment.NewLine.ToString() +
                "Ásás" + Environment.NewLine.ToString() +
                "Részletek: Béla: 0 AP + -4 DP, átlagos feladat: 1 P",
                eventText);
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