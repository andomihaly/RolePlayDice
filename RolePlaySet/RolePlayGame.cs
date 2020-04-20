using RolePlayEntity;

namespace RolePlaySet
{
    public interface RolePlayGame
    {
        void generateNewGame(string gameName);
        void loadGame(string gameName);

        void addNarration(string narration);
        void addTurnOpponentEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo);
        void addTurnTaskEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, string taskName);

        //string[] getAvailableDiceName();
        string[,] getTaskTypeList();
    }
}
