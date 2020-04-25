using RandomDice;
using RolePlayEntity;
using System.Collections.Generic;

namespace RolePlaySet.Core
{
    public class TurnEventHandler
    {
        private Dice[] dices;
        private NewTurnTextBuilder turnTextBuilder;
        private List<string> rolledDicesInTurn = new List<string>();

        private static string DEFAULT_PLAYER_NAME = "Játékos";

        public TurnEventHandler(Dice[] dices, NewTurnTextBuilder newTurnTextBuilder)
        {
            this.dices = dices;
            this.turnTextBuilder = newTurnTextBuilder;
        }

        public CalculatedTurnResult generateTurnTaskEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, TaskType taskName)
        {
            rolledDicesInTurn.Clear();
            RealPlayerStep playerStep = CreateRealPlayer(playerName, basePoint, extraPoint, numberOfDice, diceType);
            string generatedText = turnTextBuilder.GeneratePlayerVSTaskText(actualEventDescription, playerStep, taskName);
            return new CalculatedTurnResult(generatedText, rolledDicesInTurn.ToArray());
        }

        public CalculatedTurnResult generateTurnOpponentEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo)
        {
            rolledDicesInTurn.Clear();
            RealPlayerStep playerStep = CreateRealPlayer(playerName, basePoint, extraPoint, numberOfDice, diceType);
            PlayerStep opponentStep = CreateOpponentPlayer(numberOfDice, diceType, opponentPoint, isOpponentThrowToo);
            TurnResult tr = calculateTurnResult(opponentStep, playerStep);
            string generatedText = turnTextBuilder.GeneratePlayerVSOpponentText(actualEventDescription, playerStep, opponentStep, tr);
            return new CalculatedTurnResult(generatedText, rolledDicesInTurn.ToArray());
        }
        

        private static TurnResult calculateTurnResult(PlayerStep opponentStep, RealPlayerStep playerStep)
        {
            TurnResult turnResult = TurnResult.win;
            int playerScore = playerStep.basePoint + playerStep.extraPoint + playerStep.dicePoint;
            int opponentScore = opponentStep.basePoint + opponentStep.dicePoint;
            if (playerScore == opponentScore)
                turnResult = TurnResult.draw;
            if (playerScore < opponentScore)
                turnResult = TurnResult.lose;
            if (playerScore > opponentScore)
                turnResult = TurnResult.win;
            return turnResult;
        }

        private PlayerStep CreateOpponentPlayer(int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo)
        {
            PlayerStep opponentStep = new PlayerStep();
            opponentStep.basePoint = opponentPoint;
            if (isOpponentThrowToo)
            {
                opponentStep.throwDice = true;
                opponentStep.dicePoint = genereateSumOfThrowDice(diceType, numberOfDice);
            }

            return opponentStep;
        }

        private RealPlayerStep CreateRealPlayer(string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType)
        {
            RealPlayerStep playerStep = new RealPlayerStep();
            playerStep.playerName = playerName.Equals("") ? DEFAULT_PLAYER_NAME : playerName;
            playerStep.basePoint = basePoint;
            playerStep.extraPoint = extraPoint;

            if (numberOfDice > 0)
            {
                playerStep.throwDice = true;
                playerStep.dicePoint = genereateSumOfThrowDice(diceType, numberOfDice);
            }
            return playerStep;
        }

        private int genereateSumOfThrowDice(string diceType, int numberOfDice)
        {
            Dice actualDice = getActualDice(diceType);
            int sumPoint = 0;
            int throwDice = 0;
            string rolledDicesText = "";
            while (throwDice < numberOfDice)
            {
                DiceValue dv = actualDice.rollADice();
                sumPoint += (int)dv;
                rolledDicesText += ((int)dv).ToString() + RolePlayGameCoordinator.SEPARATOR;
                rolledDicesText += diceType + RolePlayGameCoordinator.SEPARATOR;
                throwDice++;
            }
            rolledDicesInTurn.Add(rolledDicesText);
            return sumPoint;
        }

        private Dice getActualDice(string diceType)
        {
            Dice actualDice = null;
            for (int i = 0; i < dices.Length; i++)
            {
                if (dices[i].getName().Equals(diceType))
                {
                    actualDice = dices[i];
                }
            }
            if (actualDice == null)
            {
                throw new NotSupportedDiceTypeException(diceType);
            }

            return actualDice;
        }
    }
}
