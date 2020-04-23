using RolePlayEntity;
namespace RolePlaySet.Core
{
    public interface NewTurnTextBuilder
    {
        string GeneratePlayerVSOpponentText(string actionDescription, RealPlayerStep player, PlayerStep opponent, TurnResult turnResult);
        string GeneratePlayerVSTaskText(string actionDescription, RealPlayerStep player, TaskType eventTask);
    }
}
