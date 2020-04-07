using RolePlayEntity;

namespace RolePlaySet
{
    public interface RolePlayGame
    {
        void generateNewGame(string gameName);
        void loadGame(string gameName);
        string[] getAvailableDiceName();
        EventTask[] getEventTasks();

        Player[] getPlayers();
        string[] getStory();
        string getDefaultImage();

        Player getPlayerByName(string playerName);
        void AddTurnOpponent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo);
        void AddTurnTask(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, EventTask evenetPoint);
    }
}
