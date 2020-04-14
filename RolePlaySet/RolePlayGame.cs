using RolePlayEntity;

namespace RolePlaySet
{
    public interface RolePlayGame
    {
        void generateNewGame(string gameName);
        
        string[] getAvailableDiceName();
        string[,] getTaskTypeList();

        void loadGame(string gameName);

        string[,] getPlayers();
        string[] getStory();
        string getDefaultImage();

        string[,] getPlayerSkillsByPlayerName(string playerName);
        void addNarration(string narration);
        void addTurnOpponentEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo);
        void addTurnTaskEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, string taskName);
    }
}
