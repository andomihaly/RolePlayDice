using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using RolePlayEntity;
using RolePlaySet;

namespace RolePlaySetTests.UnitTest
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
        public void minimumTextOpponentTest()
        {
            Assert.AreEqual("Döntetlent játszott (0 vs. 0)!" + Environment.NewLine.ToString() + "Részletek: 0 AP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerVSOpponentText("", new RealPlayerStep(), new PlayerStep(), TurnResult.draw));
        }

        [TestMethod()]
        public void withActualActionOpponentTest()
        {
            Assert.AreEqual("Döntetlent játszott (0 vs. 0)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() +
                "Részletek: 0 AP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerVSOpponentText(actionText, new RealPlayerStep(), new PlayerStep(), TurnResult.draw));
        }


        [TestMethod()]
        public void playerWhoWinOpponentTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            Assert.AreEqual(playerName + " nyert (3 vs. 0)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() +
                "Részletek: " + playerName + ": 3 AP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerVSOpponentText(actionText, bob, new PlayerStep(), TurnResult.win));
        }

        [TestMethod()]
        public void playerLoseOpponentTest()
        {
            bob.playerName = playerName;
            opponent.basePoint = 3;
            Assert.AreEqual(playerName + " vesztett (0 vs. 3)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() +
                "Részletek: " + playerName + ": 0 AP ellenfél: 3 AP",
                newTurnTextBuilder.GeneratePlayerVSOpponentText(actionText, bob, opponent, TurnResult.lose));
        }

        [TestMethod()]
        public void drawTurnOpponentTest()
        {
            bob.playerName = playerName;
            Assert.AreEqual(playerName + " döntetlent játszott (0 vs. 0)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() +
                "Részletek: " + playerName + ": 0 AP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerVSOpponentText(actionText, bob, opponent, TurnResult.draw));
        }

        [TestMethod()]
        public void playerWithExtraPointOpponentTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            bob.extraPoint = 2;
            Assert.AreEqual(playerName + " nyert (5 vs. 0)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() +
                "Részletek: " + playerName + ": 3 AP + 2 EP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerVSOpponentText(actionText, bob, opponent, TurnResult.win));
        }

        [TestMethod()]
        public void playerWithExtraPointOpponentThrowDiceOpponentTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            bob.extraPoint = 2;
            opponent.basePoint = 2;
            opponent.throwDice = true;
            opponent.dicePoint = -1;
            Assert.AreEqual(playerName + " nyert (5 vs. 1)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() +
                "Részletek: " + playerName + ": 3 AP + 2 EP ellenfél: 2 AP + -1 DP",
                newTurnTextBuilder.GeneratePlayerVSOpponentText(actionText, bob, opponent, TurnResult.win));
        }

        [TestMethod()]
        public void playerWithExtraPointAndThrowDiceOpponentTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            bob.extraPoint = 2;
            bob.throwDice = true;
            bob.dicePoint = -1;
            Assert.AreEqual(playerName + " nyert (4 vs. 0)!" + Environment.NewLine.ToString() + actionText + Environment.NewLine.ToString() +
                "Részletek: " + playerName + ": 3 AP + 2 EP + -1 DP ellenfél: 0 AP",
                newTurnTextBuilder.GeneratePlayerVSOpponentText(actionText, bob, opponent, TurnResult.win));
        }


        [TestMethod()]
        public void minimumTextTaskTest()
        {
            Assert.AreEqual("sikeresen elvégezte a fake feladatot (0 vs. 0)!" + Environment.NewLine.ToString() + "Részletek: 0 AP, fake feladat: 0 P",
                newTurnTextBuilder.GeneratePlayerVSTaskText("", new RealPlayerStep(), new TaskType("fake", 0)));
        }

        [TestMethod()]
        public void withActualActioTaskTest()
        {
            Assert.AreEqual("sikeresen elvégezte a fake feladatot (0 vs. 0)!" + Environment.NewLine.ToString() + 
                actionText + Environment.NewLine.ToString() + 
                "Részletek: 0 AP, fake feladat: 0 P",
                newTurnTextBuilder.GeneratePlayerVSTaskText(actionText, new RealPlayerStep(), new TaskType("fake", 0)));
        }

        [TestMethod()]
        public void playerLoseTaskTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            bob.dicePoint = -1;
            bob.throwDice = true;
            Assert.AreEqual(playerName + "nak nem sikerült a fake feladat (2 vs. 4)!" + Environment.NewLine.ToString() + 
                actionText + Environment.NewLine.ToString() +
                "Részletek: " + playerName + ": 3 AP + -1 DP, fake feladat: 4 P",
                newTurnTextBuilder.GeneratePlayerVSTaskText(actionText, bob, new TaskType("Fake", 4)));
        }

        [TestMethod()]
        public void playerWithExtraPointAndThrowDiceTaskTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            bob.extraPoint = 2;
            bob.throwDice = true;
            bob.dicePoint = -1;

            Assert.AreEqual(playerName + " sikeresen elvégezte a fake feladatot (4 vs. 0)!" + Environment.NewLine.ToString() + 
                actionText + Environment.NewLine.ToString() +
                "Részletek: "+ playerName + ": 3 AP + 2 EP + -1 DP, fake feladat: 0 P",
                newTurnTextBuilder.GeneratePlayerVSTaskText(actionText, bob, new TaskType("fake", 0)));
        }

        [TestMethod()]
        public void playerLoseWithVowelsTaskTest()
        {
            bob.playerName = playerName;
            bob.basePoint = 3;
            bob.dicePoint = -1;
            bob.throwDice = true;
            Assert.AreEqual(playerName + "nak nem sikerült az erős feladat (2 vs. 8)!" + Environment.NewLine.ToString() +
                actionText + Environment.NewLine.ToString() +
                "Részletek: " + playerName + ": 3 AP + -1 DP, erős feladat: 8 P",
                newTurnTextBuilder.GeneratePlayerVSTaskText(actionText, bob, new TaskType("Erős", 8)));
        }

        [TestMethod()]
        public void playerNameNakNekTaskTest()
        {
            bob.playerName = "Misi";
            bob.basePoint = -2;
            bob.throwDice = true;
            bob.dicePoint = 1;

            Assert.AreEqual("Misinek nem sikerült az erős feladat (-1 vs. 3)!" + Environment.NewLine.ToString() +
                actionText + Environment.NewLine.ToString() +
                "Részletek: Misi: -2 AP + 1 DP, erős feladat: 3 P",
                newTurnTextBuilder.GeneratePlayerVSTaskText(actionText, bob, new TaskType("Erős", +3)));
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