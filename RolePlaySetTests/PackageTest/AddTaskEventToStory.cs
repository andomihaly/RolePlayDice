using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlayEntity;
using RolePlaySet.Core;
using RolePlaySetTests.Common;
using System;

namespace RolePlaySetTests
{
    [TestClass()]
    public class AddTurnEventToStory
    {
        private SimpleGamer sg;

        [TestInitialize()]
        public void setup()
        {
            Dice[] dices = { new Dice1() };
            sg = new SimpleGamer(new StubStoreGateway(), dices);
        }

        [TestMethod()]
        public void drawGameWithoutThrowTest()
        {

            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnTaskEvent("", "", 0, 0, 0, "d3", new TaskType("Szuper",+1));
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Játékosnak nem sikerült a szuper feladat (0 vs. 1)!" + Environment.NewLine.ToString() +
                "Részletek: Játékos: 0 AP, szuper feladat: 1 P",
                sg.getStory()[0].ToString());
        }
        
        [TestMethod()]
        public void complexGameWithoutThrowTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnTaskEvent(("Micsoda Csata" + Environment.NewLine.ToString() + " Volt"), "Dr. Hosszú Név Nevek", 3, 4, 0, "d1", new TaskType("Szuper", +5));
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Dr. Hosszú Név Nevek sikeresen elvégezte a szuper feladatot (7 vs. 5)!" + Environment.NewLine.ToString() + "Micsoda Csata" + Environment.NewLine.ToString() + " Volt" + Environment.NewLine.ToString() +
                "Részletek: Dr. Hosszú Név Nevek: 3 AP + 4 EP, szuper feladat: 5 P",
                sg.getStory()[0].ToString());
        }
        
        [TestMethod()]
        public void simpleGameWithOneThrowTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnTaskEvent("A", "B", 0, 0, 1, "d1", new TaskType("Átlagos", +1));
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("B sikeresen elvégezte az átlagos feladatot (1 vs. 1)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() +
                "Részletek: B: 0 AP + 1 DP, átlagos feladat: 1 P",
                sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void simpleGameBothThrowDiceTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnTaskEvent("A", "B", 1, 0, 1, "d1", new TaskType("Gagyi", -2));
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("B sikeresen elvégezte a gagyi feladatot (2 vs. -2)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() +
                "Részletek: B: 1 AP + 1 DP, gagyi feladat: -2 P",
                sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void simpleGameWithNakNekBothThrowDiceTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnTaskEvent("A", "Misi", 1, 0, 1, "d1", new TaskType("Erős", +3));
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Misinek nem sikerült az erős feladat (2 vs. 3)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() +
                "Részletek: Misi: 1 AP + 1 DP, erős feladat: 3 P",
                sg.getStory()[0].ToString());
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