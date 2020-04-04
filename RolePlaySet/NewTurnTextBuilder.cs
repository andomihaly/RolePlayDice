using System;
using RolePlaySet.Entity;

namespace RolePlaySet
{
    public static class NewTurnTextBuilder
    {
        public static string GenerateText(string actionDescription, RealPlayerStep player, PlayerStep opponent)
        {
            string generatedText = addSpace(player.playerName) + addSpace(actionDescription);
            return generatedText.Trim();
        }
        public static string GeneratePlayerText(string actionDescription, RealPlayerStep player, PlayerStep opponent, TurnResult turnResult)
        {
            string generatedText = addSpace(player.playerName) +
                generateTurnResultText(turnResult) +
                genereteOverallScores(player, opponent) +
                actionDescription +
                Environment.NewLine.ToString() +
                generateDetail(player, opponent);
            return generatedText.Trim();
        }

        private static string addSpace(string text)
        {
            return text.Equals("") ? "" : text + " ";
        }

        private static string generateTurnResultText(TurnResult turnResult)
        {
            if (turnResult == TurnResult.draw)
                return "döntetlent játszott ";
            if (turnResult == TurnResult.win)
                return "nyert ";
            if (turnResult == TurnResult.lose)
                return "vesztett ";
            return "";
        }

        private static string genereteOverallScores(RealPlayerStep player, PlayerStep opponent)
        {
            return "(" + (player.basePoint + player.extraPoint + player.dicePoint) + "-" + (opponent.basePoint+opponent.dicePoint) + ")!";
        }

        private static string generateDetail(RealPlayerStep player, PlayerStep opponent)
        {
            string details = "Részletek: " + player.playerName + ": " + getPoints(player) + "ellenfél: " + getBasePointText(opponent.basePoint);
            if (opponent.throwDice)
            {
                details += getDicePointText(opponent.dicePoint);
            }
            return details;
        }

        private static string getPoints(RealPlayerStep player)
        {
            string score = getBasePointText(player.basePoint) + getExtraPointText(player.extraPoint);
            if (player.throwDice)
            {
                score += getDicePointText(player.dicePoint);
            }
            return score;
        }


        private static string getBasePointText(int basePoint)
        {
            return basePoint.ToString() + " AP ";
        }

        private static string getExtraPointText(int extraPoint)
        {
            if (extraPoint != 0)
            {
                return "+ " + extraPoint.ToString() + " EP ";
            }
            return "";
        }

        private static string getDicePointText(int dicePoint)
        {
            return "+ " + dicePoint.ToString() + " DP ";
        }

    }
}
