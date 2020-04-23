using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet;
using RolePlaySet.Core;
using RolePlaySetTests.Common;
using System;

namespace RolePlaySetTests.SystemTest
{
    [TestClass()]
    public class TurnEventHandlerOpponentEvent
    {
        private TurnEventHandler turnEventHandler;

        [TestInitialize()]
        public void setup()
        {
            Dice[] dices = { new DiceMinus1(), new Dice1() };
            turnEventHandler = new TurnEventHandler(dices, new NewTurnHuTextBuilder(), new SpyUIPresenter());
        }

        [TestMethod()]
        public void drawGameWithoutThrowTest()
        {
            string eventText = turnEventHandler.generateTurnOpponentEvent("", "", 0, 0, 0, "d3", 0, false);
            Assert.AreEqual("Játékos döntetlent játszott (0 vs. 0)!" + Environment.NewLine.ToString() + 
                "Részletek: Játékos: 0 AP ellenfél: 0 AP",
                eventText);
        }

        [TestMethod()]
        public void complexGameWithoutThrowTest()
        {
            string eventText = turnEventHandler.generateTurnOpponentEvent(("Micsoda Csata" + Environment.NewLine.ToString() + " Volt"), "Dr. Hosszú Név Nevek", 3, 4, 0, "d1", 5, false);
            Assert.AreEqual("Dr. Hosszú Név Nevek nyert (7 vs. 5)!" + Environment.NewLine.ToString() + 
                "Micsoda Csata" + Environment.NewLine.ToString() + " Volt" + Environment.NewLine.ToString() + 
                "Részletek: Dr. Hosszú Név Nevek: 3 AP + 4 EP ellenfél: 5 AP",
                eventText);
        }

        [TestMethod()]
        public void simpleGameWithOneThrowTest()
        {
            string eventText = turnEventHandler.generateTurnOpponentEvent("A", "B", 0, 0, 1, "d1", 0, false);
            Assert.AreEqual("B nyert (1 vs. 0)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() + 
                "Részletek: B: 0 AP + 1 DP ellenfél: 0 AP",
                eventText);
        }

        [TestMethod()]
        public void simpleGameBothThrowDiceTest()
        {
            string eventText = turnEventHandler.generateTurnOpponentEvent("A", "B", 1, 0, 1, "d1", 0, true);
            Assert.AreEqual("B nyert (2 vs. 1)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() + 
                "Részletek: B: 1 AP + 1 DP ellenfél: 0 AP + 1 DP",
                eventText);
        }

        [TestMethod()]
        public void negativPointThrowDiceTest()
        {
            string eventText = turnEventHandler.generateTurnOpponentEvent("Macsak mentés", "Béla", -1, 0, 1, "dM1", -2, true);
            Assert.AreEqual("Béla nyert (-2 vs. -3)!" + Environment.NewLine.ToString() + "Macsak mentés" + Environment.NewLine.ToString() +
                "Részletek: Béla: -1 AP + -1 DP ellenfél: -2 AP + -1 DP",
                eventText);
        }

        [TestMethod()]
        public void negativWithAllPointAllThrowDiceTest()
        {
            string eventText = turnEventHandler.generateTurnOpponentEvent("Macsak mentés", "Béla", -1, -2, 4, "dM1", -2, true);
            Assert.AreEqual("Béla vesztett (-7 vs. -6)!" + Environment.NewLine.ToString() + "Macsak mentés" + Environment.NewLine.ToString() +
                "Részletek: Béla: -1 AP + -2 EP + -4 DP ellenfél: -2 AP + -4 DP",
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