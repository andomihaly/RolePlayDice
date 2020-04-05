using RolePlaySet.Entity;

namespace RolePlaySet
{
    interface NewTurnTextBuilder
    {
        string GeneratePlayerText(string actionDescription, RealPlayerStep player, PlayerStep opponent, TurnResult turnResult);
    }
}
