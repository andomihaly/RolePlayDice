using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RolePlaySetTests;
using System;

namespace RolePlaySet.Tests
{
    [TestClass()]
    public class SimpleGamerTestsAddTurnOpponent
    {
        private SimpleGamer sg = new SimpleGamer(new StubStoreGateway(), new VisualStudioRandomGenerator());
        [TestMethod()]
        public void drawGameWithoutThrowTest()
        {

            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnOpponent("", "", 0, 0, 0, "d3", 0, false);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Játékos döntetlent játszott (0 vs. 0)!" + Environment.NewLine.ToString() + 
                "Részletek: Játékos: 0 AP ellenfél: 0 AP", 
                sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void complexGameWithoutThrowTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnOpponent(("Micsoda Csata" + Environment.NewLine.ToString() + " Volt"), "Dr. Hosszú Név Nevek", 3, 4, 0, "d3", 5, false);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Dr. Hosszú Név Nevek nyert (7 vs. 5)!" + Environment.NewLine.ToString() + "Micsoda Csata" + Environment.NewLine.ToString() + " Volt" + Environment.NewLine.ToString() + 
                "Részletek: Dr. Hosszú Név Nevek: 3 AP + 4 EP ellenfél: 5 AP", 
                sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void simpleGameWithOneThrowTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnOpponent("A", "B", 0, 0, 1, "d1", 0, false);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("B nyert (1 vs. 0)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() + 
                "Részletek: B: 0 AP + 1 DP ellenfél: 0 AP", 
                sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void simpleGameBothThrowDiceTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnOpponent("A", "B", 1, 0, 1, "d1", 0, true);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("B nyert (2 vs. 1)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() + 
                "Részletek: B: 1 AP + 1 DP ellenfél: 0 AP + 1 DP", 
                sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void negativPointThrowDiceTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnOpponent("Macsak mentés", "Béla", -1, 0, 1, "d-1", -2, true);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Béla nyert (-2 vs. -3)!" + Environment.NewLine.ToString() + "Macsak mentés" + Environment.NewLine.ToString() +
                "Részletek: Béla: -1 AP + -1 DP ellenfél: -2 AP + -1 DP",
                sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void negativWithAllPointAllThrowDiceTest()
        {
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurnOpponent("Macsak mentés", "Béla", -1, -2, 4, "d-1", -2, true);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Béla vesztett (-7 vs. -6)!" + Environment.NewLine.ToString() + "Macsak mentés" + Environment.NewLine.ToString() +
                "Részletek: Béla: -1 AP + -2 EP + -4 DP ellenfél: -2 AP + -4 DP",
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