using RolePlaySet.Entity;

namespace RolePlaySet
{
    public interface RolePlayGamers
    {
        Player[] getPlayersName();
        void loadGame(string rolePlayGame);
        Player getPlayerByName(string playerName);
        void generateNewGame(string gameName);
        void AddTurn(string actualEventDescription, int playerPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo);
        string[] loadStory();
    }
}
