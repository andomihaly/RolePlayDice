using Microsoft.VisualStudio.TestTools.UnitTesting;
using RolePlaySet;
using RolePlaySet.Entity;
using System;

namespace RolePlaySet.Tests
{
    [TestClass()]
    public class NewTurnTextBuilderTests
    {
        private string actionText = "Fire";
        private string playerName = "Mr. Bob";
        private RealPlayerStep bob = new RealPlayerStep();
        private PlayerStep opponent = new PlayerStep();
        NewTurnHuTextBuilder newTurnTextBuilder = new NewTurnHuTextBuilder();

        [TestMethod()]
        public void minimumTextTest()
        {
            Assert.AreEqual("Döntetlent játszott (0-0)!" + Environment.NewLine.ToString() + "Részletek: 0 AP ellenfél: 0 AP", 
                newTurnTextBuilder.GeneratePlayerText("", new RealPlayerStep(), new PlayerStep(), TurnResult.draw));
        }

        [TestMethod()]
        public void withActualActionTest()
        {
            Assert.AreEqual("Döntetlent játszott (0-0)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() + 
                "Részletek: 0 AP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerText(actionText, new RealPlayerStep(), new PlayerStep(), TurnResult.draw));
        }


        [TestMethod()]
        public void playerWhoWinTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            Assert.AreEqual(playerName + " nyert (3-0)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() + 
                "Részletek: " + playerName + ": 3 AP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerText(actionText, bob, new PlayerStep(), TurnResult.win));
        }

        [TestMethod()]
        public void playerLoseTest()
        {
            bob.playerName = playerName;
            opponent.basePoint = 3;
            Assert.AreEqual(playerName + " vesztett (0-3)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() + 
                "Részletek: " + playerName + ": 0 AP ellenfél: 3 AP",
                newTurnTextBuilder.GeneratePlayerText(actionText, bob, opponent, TurnResult.lose));
        }

        [TestMethod()]
        public void drawTurnTest()
        {
            bob.playerName = playerName;
            Assert.AreEqual(playerName + " döntetlent játszott (0-0)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() + 
                "Részletek: " + playerName + ": 0 AP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerText(actionText, bob, opponent, TurnResult.draw));
        }

        [TestMethod()]
        public void playerWithExtraPointTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            bob.extraPoint = 2;
            Assert.AreEqual(playerName + " nyert (5-0)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() + 
                "Részletek: " + playerName + ": 3 AP + 2 EP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerText(actionText, bob, opponent, TurnResult.win));
        }

        [TestMethod()]
        public void playerWithExtraPointOpponentThrowDiceTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            bob.extraPoint = 2;
            opponent.basePoint = 2;
            opponent.throwDice = true;
            opponent.dicePoint = -1;
            Assert.AreEqual(playerName + " nyert (5-1)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() + 
                "Részletek: " + playerName + ": 3 AP + 2 EP ellenfél: 2 AP + -1 DP",
                newTurnTextBuilder.GeneratePlayerText(actionText, bob, opponent, TurnResult.win));
        }

        [TestMethod()]
        public void playerWithExtraPointAndThrowDiceTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            bob.extraPoint = 2;
            bob.throwDice = true;
            bob.dicePoint = -1;
            Assert.AreEqual(playerName + " nyert (4-0)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() + 
                "Részletek: " + playerName + ": 3 AP + 2 EP + -1 DP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerText(actionText, bob, opponent, TurnResult.win));
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