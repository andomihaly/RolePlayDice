using RolePlaySet.Entity;

namespace RolePlaySet
{
    public interface StoreGateway
    {
        void createNewGame(string gameName);
        void saveGame(Story story, string gameName);
        Player[] loadPlayers(string gameName);
        Story loadStory(string gameName);
    }
}
