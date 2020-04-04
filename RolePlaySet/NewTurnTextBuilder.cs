using System;
using RolePlaySet.Entity;

namespace RolePlaySet
{
    public static class NewTurnTextBuilder
    {
        public static string GeneratePlayerText(string actionDescription, RealPlayerStep player, PlayerStep opponent, TurnResult turnResult)
        {
            string generatedText = addSpace(player.playerName) +
                generateTurnResultText(turnResult) +
                genereteOverallScores(player, opponent) +
                generateDescription(actionDescription) +
                Environment.NewLine.ToString() +
                generateDetail(player, opponent);

            generatedText = changeFirstCharacterToUpperIfNeeded(player, generatedText);
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
            return "(" + (player.basePoint + player.extraPoint + player.dicePoint) + "-" + (opponent.basePoint + opponent.dicePoint) + ")!";
        }

        private static string generateDescription(string actionDescription)
        {
            return actionDescription.Equals("") ? "" : Environment.NewLine.ToString() + actionDescription;
        }

        private static string generateDetail(RealPlayerStep player, PlayerStep opponent)
        {
            string details = "Részletek: ";
            details += player.playerName.Equals("") ? "" : player.playerName + ": ";
            details += getPoints(player) + "ellenfél: " + getBasePointText(opponent.basePoint);
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

        private static string changeFirstCharacterToUpperIfNeeded(RealPlayerStep player, string generatedText)
        {
            if (player.playerName.Equals(""))
            {
                generatedText = char.ToUpper(generatedText[0]) + generatedText.Substring(1);
            }

            return generatedText;
        }
    }
}
