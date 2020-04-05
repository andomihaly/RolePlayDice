using RolePlayEntity;

namespace RolePlaySet
{
    interface NewTurnTextBuilder
    {
        string GeneratePlayerVSOpponentText(string actionDescription, RealPlayerStep player, PlayerStep opponent, TurnResult turnResult);
        string GeneratePlayerVSTaskText(string actionDescription, RealPlayerStep player, EventTask eventTask);
    }
}
