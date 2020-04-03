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
            story = storeGateway.loadStory(gameName);
            players = storeGateway.loadPlayers(gameName);
        }

        public Player getPlayerByName(string playerName)
        {
            foreach(Player onePlayer in players)
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

        public string[] loadStory()
        {
            return story.events;
        }

        public void AddTurn(string actualEventDescription, int playerPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo)
        {
            storeGateway.saveGame(story, gameName);
        }
    }
}
