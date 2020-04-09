using RolePlayEntity;
using RolePlaySet;

namespace RolePlaySetTests.UnitTest
{
    internal class FakeTextBuilder : NewTurnTextBuilder
    {
        public string GeneratePlayerVSOpponentText(string actionDescription, RealPlayerStep player, PlayerStep opponent, TurnResult turnResult)
        {
            return actionDescription + "|" + player.playerName + "|" + player.basePoint + "|" + player.extraPoint + "|" + player.dicePoint + "|" + opponent.basePoint + "|" + opponent.dicePoint + "|" + turnResult.ToString();
        }

        public string GeneratePlayerVSTaskText(string actionDescription, RealPlayerStep player, TaskType eventTask)
        {
            return actionDescription + "|" + player.playerName + "|" + player.basePoint + "|" + player.extraPoint + "|" + player.dicePoint + "|" + eventTask.name + "|" + eventTask.point;
        }
    }
}
