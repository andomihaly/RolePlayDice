using RandomDice;
using RandomDice.Dices;
using RolePlaySet.Entity;
using System;

namespace RolePlaySet
{
    public class SimpleGamer : RolePlayGamers
    {
        private Story story = new Story();
        private Player[] players;
        private String gameName;
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

        public void AddTurn(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo)
        {
            PlayerStep opponentStep = new PlayerStep();
            opponentStep.basePoint = opponentPoint;
            if (isOpponentThrowToo)
            {
                opponentStep.throwDice = true;
                opponentStep.dicePoint = genereateSumOfThrowDice(diceType, numberOfDice);
            }

            RealPlayerStep playerStep = new RealPlayerStep();
            playerStep.playerName = playerName.Equals("")?"Játékos":playerName;
            playerStep.basePoint = basePoint;
            playerStep.extraPoint = extraPoint;
            if (numberOfDice>0)
            {
                playerStep.throwDice = true;
                playerStep.dicePoint = genereateSumOfThrowDice(diceType, numberOfDice);
            }
            TurnResult tr = TurnResult.win;
            int playerScore = playerStep.basePoint + playerStep.extraPoint + playerStep.dicePoint;
            int opponentScore = opponentStep.basePoint + opponentStep.dicePoint;
            if (playerScore == opponentPoint)
                tr = TurnResult.draw;
            if (playerScore < opponentPoint)
                tr = TurnResult.lose;
            if (playerScore > opponentPoint)
                tr = TurnResult.win;
            story.events.Add(NewTurnTextBuilder.GeneratePlayerText(actualEventDescription, playerStep,opponentStep,tr));

            storeGateway.saveGame(story, gameName);
        }

        private int genereateSumOfThrowDice(string diceType, int numberOfDice)
        {

            Dice dice = new Dice0(intervalRandomGenerator);
            if (diceType.Equals("d1"))
            {
                dice = new Dice1(intervalRandomGenerator);
            }
            if (diceType.Equals("df3"))
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
                sumPoint += (int)dice.throwADice();
                throwDice++;
            }
            return sumPoint;
        }
    }
}
