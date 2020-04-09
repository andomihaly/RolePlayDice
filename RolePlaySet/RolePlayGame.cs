using RolePlayEntity;

namespace RolePlaySet
{
    public interface RolePlayGame
    {
        void generateNewGame(string gameName);
        
        string[] getAvailableDiceName();
        TaskType[] getTaskTypeList();

        void loadGame(string gameName);

        Player[] getPlayers();
        string[] getStory();
        string getDefaultImage();

        Player getPlayerByName(string playerName);
        void addTurnOpponentEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo);
        void addTurnTaskEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, TaskType evenetPoint);
    }
}
