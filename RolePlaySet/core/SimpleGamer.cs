using RandomDice;
using RolePlayEntity;
using System;
using RolePlaySet.Core;
using System.Collections.Generic;

namespace RolePlaySet.Core
{
    public class SimpleGamer : RolePlayGame
    {
        private StoreGateway storeGateway;
        private Dice[] dices;

        private Story story = new Story();
        private Player[] players;
        private string gameName;
        private string defaultImage ="";
        


        public SimpleGamer(StoreGateway storeGateway, Dice[] dices)
        {
            this.storeGateway = storeGateway;
            this.dices = dices;
        }

        public Player[] getPlayers()
        {
            return players;
        }

        public string[] getAvailableDiceName()
        {
            List<string> diceName = new List<string>();
            foreach(Dice dice in dices)
            {
                diceName.Add(dice.getName());
            }
            return diceName.ToArray();
        }


        public void loadGame(string gameName)
        {
            checkGameName(gameName);
            this.gameName = reformatGameName(gameName);
            defaultImage = storeGateway.loadDefaultImage(gameName);
            loadPlayers(gameName);
            loadStory(gameName);
        }

        private void checkGameName(string gameName)
        {
            if (gameName == null)
            {
                throw new GameNameIsNotValid(gameName);
            }
            gameName = gameName.Trim();
            if (gameName.Equals(""))
            {
                throw new GameNameIsNotValid(gameName);
            }
        }

        private string reformatGameName(String gameName)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                gameName = gameName.Replace(c, '_');
            }
            return gameName;
        }

        private void loadPlayers(string gameName)
        {
            try
            {
                players = storeGateway.loadPlayers(gameName);
            }
            catch (Exception)
            {
                players = null;
            }
        }

        private void loadStory(string gameName)
        {
            Story teamStory = storeGateway.loadStory(gameName);
            if (teamStory != null)
            {
                story = teamStory;
            }
        }   

        public Player getPlayerByName(string playerName)
        {
            if (!(players == null))
            {
                foreach (Player onePlayer in players)
                {
                    if (onePlayer.name.Equals(playerName))
                    {
                        return onePlayer;
                    }
                }
            }
            return null;
        }

        public void generateNewGame(string gameName)
        {
            checkGameName(gameName);
            this.gameName = reformatGameName(gameName);

            storeGateway.createNewGame(gameName);
        }

        public string[] getStory()
        {
            return story.events.ToArray();
        }

        public void AddTurnTaskEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, TaskType evenetPoint)
        {
            RealPlayerStep playerStep = CreateRealPlayer(playerName, basePoint, extraPoint, numberOfDice, diceType);
            story.events.Add(new NewTurnHuTextBuilder().GeneratePlayerVSTaskText(actualEventDescription, playerStep, evenetPoint));
            storeGateway.saveGame(story, gameName);
        }

        public void AddTurnOpponentEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo)
        {
            RealPlayerStep playerStep = CreateRealPlayer(playerName, basePoint, extraPoint, numberOfDice, diceType);
            PlayerStep opponentStep = CreateOpponentPlayer(numberOfDice, diceType, opponentPoint, isOpponentThrowToo);
            TurnResult tr = calculateTurnResult(opponentStep, playerStep);

            story.events.Add(new NewTurnHuTextBuilder().GeneratePlayerVSOpponentText(actualEventDescription, playerStep, opponentStep, tr));
            storeGateway.saveGame(story, gameName);
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
            playerStep.playerName = playerName.Equals("") ? "Játékos" : playerName;
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
            while (throwDice < numberOfDice)
            {
                DiceValue dv = actualDice.throwADice();
                sumPoint += (int)dv;
                throwDice++;
            }
            return sumPoint;
        }

        private Dice getActualDice(string diceType)
        {
            Dice actualDice = null;
            for (int i=0; i < dices.Length; i++)
            {
                if (dices[i].getName().Equals(diceType))
                {
                    actualDice = dices[i];
                }
            }
            if (actualDice == null)
            {
                throw new NotSupportedDiceType(diceType);
            }

            return actualDice;
        }

        public string getDefaultImage()
        {
            return defaultImage;
        }

        public TaskType[] getEventTasks()
        {
            return EventTaskGenerator.generateEventTasksList().ToArray();
        }
    }
}
