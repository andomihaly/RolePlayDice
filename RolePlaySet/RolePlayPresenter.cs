namespace RolePlaySet
{
    public interface RolePlayPresenter
    {
        void initRolePlayContext(string[] initContext);
        void loadedGameContext(string[] gameContext);
        void rolledDicesInTurn(string[,] rolledDice);
        void changeStory(string[] story);
        void displayError(string[] error);
    }
}
