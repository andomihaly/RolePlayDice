using Microsoft.VisualStudio.TestTools.UnitTesting;
using RolePlaySetTests;
using System;

namespace RolePlaySet.Tests
{
    [TestClass()]
    public class SimpleGamerTestsAddTurn
    {
        [TestMethod()]
        public void drawGameWithoutThrowTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurn("", "",0, 0, 0, "d3", 0, false);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Játékos döntetlent játszott (0-0)!" + Environment.NewLine.ToString() + "Részletek: Játékos: 0 AP ellenfél: 0 AP", sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void complexGameWithoutThrowTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurn(("Micsoda Csata"+ Environment.NewLine.ToString()+" Volt"), "Dr. Hosszú Név Nevek", 3, 4, 0, "d3", 5, false);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Dr. Hosszú Név Nevek nyert (7-5)!" + "Micsoda Csata" + Environment.NewLine.ToString() + " Volt" + Environment.NewLine.ToString() + "Részletek: Dr. Hosszú Név Nevek: 3 AP + 4 EP ellenfél: 5 AP", sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void simpleGameWithOneThrowTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurn("A", "B", 0, 0, 1, "d1", 0, false);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("B nyert (1-0)!A" + Environment.NewLine.ToString() + "Részletek: B: 0 AP + 1 DP ellenfél: 0 AP", sg.getStory()[0].ToString());
        }

        [TestMethod()]
        public void simpleGameBothThrowDiceTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurn("A", "B", 1, 0, 1, "d1", 0, true);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("B nyert (2-1)!A" + Environment.NewLine.ToString() + "Részletek: B: 1 AP + 1 DP ellenfél: 0 AP + 1 DP", sg.getStory()[0].ToString());
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