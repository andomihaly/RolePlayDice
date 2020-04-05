using System;
using RolePlayEntity;

namespace RolePlaySet
{
    public class NewTurnHuTextBuilder : NewTurnTextBuilder
    {

        public string GeneratePlayerVSTaskText(string actionDescription, RealPlayerStep player, EventTask eventTask)
        {
            string generatedText = player.playerName +
                GenerateTaskText(player, eventTask)+
                genereteOverallScores(player, eventTask.point) +
                generateDescription(actionDescription) +
                Environment.NewLine.ToString() +
                generateDetail(player, eventTask);

            generatedText = changeFirstCharacterToUpperIfNeeded(player, generatedText);
            return generatedText.Trim();
        }

        private string GenerateTaskText(RealPlayerStep player, EventTask eventTask)
        {
            if (calculatePlayerScore(player)>=eventTask.point)
            {
                return " sikeresen elvégezte a " + eventTask.name.ToLower() + " feladatot "; 
            }
            else
            {
                return "nak nem sikerült a " + eventTask.name.ToLower() + " feladat ";
            }
        }

        private string genereteOverallScores(RealPlayerStep player, int taskPoint)
        {
            return "(" + calculatePlayerScore(player) + " vs. " + (taskPoint) + ")!";
        }

        private int calculatePlayerScore(RealPlayerStep player)
        {
            return player.basePoint + player.extraPoint + player.dicePoint;
        }
        private string generateDetail(RealPlayerStep player, EventTask eventTask)
        {
            string details = "Részletek: ";
            details += player.playerName.Equals("") ? "" : player.playerName + ": ";
            details += getPoints(player) + ", "+ eventTask.name.ToLower() + " feladat: " + eventTask.point.ToString();
            return details;
        }

        public string GeneratePlayerVSOpponentText(string actionDescription, RealPlayerStep player, PlayerStep opponent, TurnResult turnResult)
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

        private string addSpace(string text)
        {
            return text.Equals("") ? "" : text + " ";
        }

        private string generateTurnResultText(TurnResult turnResult)
        {
            if (turnResult == TurnResult.draw)
                return "döntetlent játszott ";
            if (turnResult == TurnResult.win)
                return "nyert ";
            if (turnResult == TurnResult.lose)
                return "vesztett ";
            return "";
        }

        private string genereteOverallScores(RealPlayerStep player, PlayerStep opponent)
        {
            return "(" + (player.basePoint + player.extraPoint + player.dicePoint) + " vs. " + (opponent.basePoint + opponent.dicePoint) + ")!";
        }

        private string generateDescription(string actionDescription)
        {
            return actionDescription.Equals("") ? "" : Environment.NewLine.ToString() + actionDescription;
        }

        private string generateDetail(RealPlayerStep player, PlayerStep opponent)
        {
            string details = "Részletek: ";
            details += player.playerName.Equals("") ? "" : player.playerName + ": ";
            details += getPoints(player) + " ellenfél: " + getBasePointText(opponent.basePoint);
            if (opponent.throwDice)
            {
                details += getDicePointText(opponent.dicePoint);
            }
            return details;
        }
        
        private string getPoints(RealPlayerStep player)
        {
            string score = getBasePointText(player.basePoint) + getExtraPointText(player.extraPoint);
            if (player.throwDice)
            {
                score += getDicePointText(player.dicePoint);
            }
            return score;
        }

        private string getBasePointText(int basePoint)
        {
            return basePoint.ToString() + " AP";
        }

        private string getExtraPointText(int extraPoint)
        {
            if (extraPoint != 0)
            {
                return " + " + extraPoint.ToString() + " EP";
            }
            return "";
        }

        private string getDicePointText(int dicePoint)
        {
            return " + " + dicePoint.ToString() + " DP";
        }

        private string changeFirstCharacterToUpperIfNeeded(RealPlayerStep player, string generatedText)
        {
            if (player.playerName.Equals(""))
            {
                generatedText = char.ToUpper(generatedText[0]) + generatedText.Substring(1);
            }

            return generatedText;
        }
    }
}
