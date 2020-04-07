using RolePlayEntity;

namespace RolePlaySet
{
    public interface RolePlayGame
    {
        void generateNewGame(string gameName);
        void loadGame(string gameName);
        string[] getAvailableDiceName();
        TaskType[] getEventTasks();

        Player[] getPlayers();
        string[] getStory();
        string getDefaultImage();

        Player getPlayerByName(string playerName);
        void AddTurnOpponentEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo);
        void AddTurnTaskEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, TaskType evenetPoint);
    }
}
