using RandomDice;
using RolePlaySet.Entity;
using System;

namespace RolePlaySet
{
    public class SimpleGamer : RolePlayGamers
    {
        private Story story;
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
            this.gameName = gameName;
            try
            {
                players = storeGateway.loadPlayers(gameName);
            }
            catch (Exception)
            {
                players = null;
            }

            story = storeGateway.loadStory(gameName);

        }

        public Player getPlayerByName(string playerName)
        {
            foreach (Player onePlayer in players)
            {
                if (onePlayer.name.Equals(playerName))
                {
                    return onePlayer;
                }
            }
            return null;
        }

        public void generateNewGame(string gameName)
        {
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
