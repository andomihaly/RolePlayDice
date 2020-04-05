using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RolePlayEntity;
using RolePlaySetTests;
using System;

namespace RolePlaySet.Tests
{
    [TestClass()]
    public class SimpleGamerTestsAddTurnEventTask
    {
        private SimpleGamer sg = new SimpleGamer(new StubStoreGateway(), new VisualStudioRandomGenerator());
        [TestMethod()]
        public void drawGameWithoutThrowTest()
        {

            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnTask("", "", 0, 0, 0, "d3", new EventTask("Szuper",+1));
            Assert.AreEqual(1, sg.getStory().Length);
            AssertBasedOnCharacter("Játékosnak nem sikerült a szuper feladat (0 vs. 1)!" + Environment.NewLine.ToString() +
                "Részletek: Játékos: 0 AP, szuper feladat: 1",
                sg.getStory()[0].ToString());
        }
        
        [TestMethod()]
        public void complexGameWithoutThrowTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnTask(("Micsoda Csata" + Environment.NewLine.ToString() + " Volt"), "Dr. Hosszú Név Nevek", 3, 4, 0, "d3", new EventTask("Szuper", +5));
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Dr. Hosszú Név Nevek sikeresen elvégezte a szuper feladatot (7 vs. 5)!" + Environment.NewLine.ToString() + "Micsoda Csata" + Environment.NewLine.ToString() + " Volt" + Environment.NewLine.ToString() +
                "Részletek: Dr. Hosszú Név Nevek: 3 AP + 4 EP, szuper feladat: 5",
                sg.getStory()[0].ToString());
        }
        
        [TestMethod()]
        public void simpleGameWithOneThrowTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnTask("A", "B", 0, 0, 1, "d1", new EventTask("Átlagos", +1));
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("B sikeresen elvégezte a átlagos feladatot (1 vs. 1)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() +
                "Részletek: B: 0 AP + 1 DP, átlagos feladat: 1",
                sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void simpleGameBothThrowDiceTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnTask("A", "B", 1, 0, 1, "d1", new EventTask("Gagyi", -2));
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("B sikeresen elvégezte a gagyi feladatot (2 vs. -2)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() +
                "Részletek: B: 1 AP + 1 DP, gagyi feladat: -2",
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