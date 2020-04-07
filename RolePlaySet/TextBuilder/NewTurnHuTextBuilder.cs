using System;
using RolePlayEntity;
using System.Linq;

namespace RolePlaySet
{
    public class NewTurnHuTextBuilder : NewTurnTextBuilder
    {

        private static string[] vowelsHigh = { "a", "á", "o", "ó", "u", "ú" };
        private static string[] vowelsLow = { "e", "é", "i", "í", "ö", "ő", "ü", "ű" };
        private static string[] vowels = { "a", "á", "o", "ó", "u", "ú", "e", "é", "i", "í", "ö", "ő", "ü", "ű" };

        public string GeneratePlayerVSTaskText(string actionDescription, RealPlayerStep player, TaskEvent eventTask)
        {
            string generatedText = player.playerName +
                GenerateTaskText(player, eventTask) +
                genereteOverallScores(player, eventTask.point) +
                generateDescription(actionDescription) +
                Environment.NewLine.ToString() +
                generateDetail(player, eventTask);

            generatedText = changeFirstCharacterToUpperIfNeeded(player, generatedText);
            return generatedText.Trim();
        }

        private string GenerateTaskText(RealPlayerStep player, TaskEvent eventTask)
        {
            if (calculatePlayerScore(player) >= eventTask.point)
            {
                return " sikeresen elvégezte " + generateThe(eventTask.name) + " " + eventTask.name.ToLower() + " feladatot ";
            }
            else
            {
                return generateNakNek(player.playerName) + " nem sikerült " + generateThe(eventTask.name) + " " + eventTask.name.ToLower() + " feladat ";
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
        private string generateDetail(RealPlayerStep player, TaskEvent eventTask)
        {
            string details = "Részletek: ";
            details += player.playerName.Equals("") ? "" : player.playerName + ": ";
            details += getPoints(player) + ", " + eventTask.name.ToLower() + " feladat: " + eventTask.point.ToString() + " P";
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

        private string generateThe(string nextWord)
        {
            string firstLetter = nextWord[0].ToString().ToLower();
            //if (Array.Exists(vowels, element => element.StartsWith(firstLetter)))
            if (vowels.Contains(firstLetter))
            {
                return "az";
            }
            return "a";
        }

        private string generateNakNek(string baseWord)
        {
            string nextLetter;
            bool notFindVawel = true;
            int i = baseWord.Length;
            while (notFindVawel && i > 0)
            {
                i--;
                nextLetter = baseWord[i].ToString().ToLower();
                if (vowelsLow.Contains(nextLetter))
                {
                    return "nek";
                }
                if (vowelsHigh.Contains(nextLetter))
                {
                    return "nak";
                }
            }
            return "nak";
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
