using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice;
using RolePlaySet.Core;
using RolePlaySet.TextBuilder;
using RolePlaySetTests.Common;
using System;

namespace RolePlaySetTests.IntegrationTest
{
    [TestClass()]
    public class TurnEventHandlerOpponentEventTest
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
            CalculatedTurnResult calculatedTurnResult = turnEventHandler.generateTurnOpponentEvent("", "", 0, 0, 0, "d3", 0, false);
            Assert.AreEqual("Játékos döntetlent játszott (0 vs. 0)!" + Environment.NewLine.ToString() + 
                "Részletek: Játékos: 0 AP ellenfél: 0 AP",
                calculatedTurnResult.generatedText);
            Assert.AreEqual(0, calculatedTurnResult.rolledDices.Length);
        }

        [TestMethod()]
        public void complexGameWithoutThrowTest()
        {
            CalculatedTurnResult calculatedTurnResult = turnEventHandler.generateTurnOpponentEvent(("Micsoda Csata" + Environment.NewLine.ToString() + " Volt"), "Dr. Hosszú Név Nevek", 3, 4, 0, "d1", 5, false);
            Assert.AreEqual("Dr. Hosszú Név Nevek nyert (7 vs. 5)!" + Environment.NewLine.ToString() + 
                "Micsoda Csata" + Environment.NewLine.ToString() + " Volt" + Environment.NewLine.ToString() + 
                "Részletek: Dr. Hosszú Név Nevek: 3 AP + 4 EP ellenfél: 5 AP",
                calculatedTurnResult.generatedText);
            Assert.AreEqual(0, calculatedTurnResult.rolledDices.Length);
        }

        [TestMethod()]
        public void simpleGameWithOneThrowTest()
        {
            CalculatedTurnResult calculatedTurnResult = turnEventHandler.generateTurnOpponentEvent("A", "B", 0, 0, 1, "d1", 0, false);
            Assert.AreEqual("B nyert (1 vs. 0)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() + 
                "Részletek: B: 0 AP + 1 DP ellenfél: 0 AP",
                calculatedTurnResult.generatedText);
            Assert.AreEqual(1, calculatedTurnResult.rolledDices.Length);
        }

        [TestMethod()]
        public void simpleGameBothThrowDiceTest()
        {
            CalculatedTurnResult calculatedTurnResult = turnEventHandler.generateTurnOpponentEvent("A", "B", 1, 0, 1, "d1", 0, true);
            Assert.AreEqual("B nyert (2 vs. 1)!" + Environment.NewLine.ToString() + "A" + Environment.NewLine.ToString() + 
                "Részletek: B: 1 AP + 1 DP ellenfél: 0 AP + 1 DP",
                calculatedTurnResult.generatedText);
            Assert.AreEqual(2, calculatedTurnResult.rolledDices.Length);
        }

        [TestMethod()]
        public void negativPointThrowDiceTest()
        {
            CalculatedTurnResult calculatedTurnResult = turnEventHandler.generateTurnOpponentEvent("Macsak mentés", "Béla", -1, 0, 1, "dM1", -2, true);
            Assert.AreEqual("Béla nyert (-2 vs. -3)!" + Environment.NewLine.ToString() + "Macsak mentés" + Environment.NewLine.ToString() +
                "Részletek: Béla: -1 AP + -1 DP ellenfél: -2 AP + -1 DP",
                calculatedTurnResult.generatedText);
            Assert.AreEqual(2, calculatedTurnResult.rolledDices.Length);
        }

        [TestMethod()]
        public void negativWithAllPointAllThrowDiceTest()
        {
            CalculatedTurnResult calculatedTurnResult = turnEventHandler.generateTurnOpponentEvent("Macsak mentés", "Béla", -1, -2, 4, "dM1", -2, true);
            Assert.AreEqual("Béla vesztett (-7 vs. -6)!" + Environment.NewLine.ToString() + "Macsak mentés" + Environment.NewLine.ToString() +
                "Részletek: Béla: -1 AP + -2 EP + -4 DP ellenfél: -2 AP + -4 DP",
                calculatedTurnResult.generatedText);
            Assert.AreEqual(2, calculatedTurnResult.rolledDices.Length);
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