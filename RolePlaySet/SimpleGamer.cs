using RandomDice;
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

        public SimpleGamer(StoreGateway storeGateway)
        {
            this.storeGateway = storeGateway;
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

        public void AddTurn(string actualEventDescription, string playerName, int playerPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo)
        {
            //Dice dice;
            //if (diceType.Equals("df3"))
            //{
            //    dice = new DiceFudge3();
            //}

            string nextEvent = playerName + " " + actualEventDescription + " ";
            story.events.Add(nextEvent);

            storeGateway.saveGame(story, gameName);
        }
    }
}
