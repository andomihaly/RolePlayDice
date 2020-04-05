using RandomDice;
using RandomDice.Dices;
using RolePlayEntity;
using RolePlaySet.core;
using System;

namespace RolePlaySet
{
    public class SimpleGamer : RolePlayGamers
    {
        private Story story = new Story();
        private Player[] players;
        private string gameName;
        private string defaultImage ="";
        private StoreGateway storeGateway;
        private IntervalRandomGenerator intervalRandomGenerator;

        public SimpleGamer(StoreGateway storeGateway, IntervalRandomGenerator intervalRandomGenerator)
        {
            this.storeGateway = storeGateway;
            this.intervalRandomGenerator = intervalRandomGenerator;
        }
        public Player[] getPlayers()
        {
            return players;
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

        public void AddTurnTask(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, EventTask evenetPoint)
        {
            RealPlayerStep playerStep = CreateRealPlayer(playerName, basePoint, extraPoint, numberOfDice, diceType);
            story.events.Add(new NewTurnHuTextBuilder().GeneratePlayerVSTaskText(actualEventDescription, playerStep, evenetPoint));
            storeGateway.saveGame(story, gameName);
        }

        public void AddTurnOpponent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo)
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
            Dice dice = new Dice0();
            if (diceType.Equals("d1"))
            {
                dice = new Dice1();
            }
            if (diceType.Equals("d-1"))
            {
                dice = new DiceMinus1();
            }
            if (diceType.Equals("dF3"))
            {
                dice = new DiceFudge3(intervalRandomGenerator);
            }
            if (diceType.Equals("d3"))
            {
                dice = new Dice3(intervalRandomGenerator);
            }
            if (diceType.Equals("d6"))
            {
                dice = new Dice6(intervalRandomGenerator);
            }
            int sumPoint = 0;
            int throwDice= 0;
            while (throwDice<numberOfDice)
            {
                DiceValue dv = dice.throwADice();
                sumPoint += (int)dv;
                throwDice++;
            }
            return sumPoint;
        }

        public string getDefaultImage()
        {
            return defaultImage;
        }

        public EventTask[] getEventTasks()
        {
            return EventTaskGenerator.generateEventTasksList().ToArray();
        }
    }
}
