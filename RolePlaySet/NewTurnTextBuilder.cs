using RolePlayEntity;

namespace RolePlaySet
{
    interface NewTurnTextBuilder
    {
        string GeneratePlayerText(string actionDescription, RealPlayerStep player, PlayerStep opponent, TurnResult turnResult);
    }
}
