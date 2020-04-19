namespace RolePlaySet
{
    public interface RolePlayPresenter
    {
        void rolledDicesInTurn(string[,] rolledDice);
        void changeStory(string[] story);
        void loadedGameContext(string[] gameContext);
        void displayError(string[] error);
    }
}
