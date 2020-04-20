using RolePlayGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RolePlayGUI
{
    public partial class RolePlayBoard
    {
        private void loadAndFillEventTasks()
        {
            ladderComboBox.Items.Clear();
            foreach (Task task in taskList)
            {
                ladderComboBox.Items.Add(task.name);
            }
            ladderComboBox.Text = rm.GetString("ladderTask", actualCultureInfo);
        }

        private string findEventTaskBasedOnEventTaskName(string eventTaskName)
        {
            foreach (Task task in taskList)
            { 
                if (task.name.Equals(eventTaskName))
                    return task.name;
            }
            return null;
        }


        private bool isPointsAndNumbersConvertable()
        {
            return (isConverttableToInt(playerBasedPoint.Text) && isConverttableToInt(playerExtraPoint.Text) &&
                    isConverttableToInt(numberOfDice.Text));
        }



        private void fillGUIWithGame()
        {
            notSavedGameLabel.Visible = false;
            foreach (GamePlayer player in gamePlayers)
            {
                playersComboBox.Items.Add(player.name);
            }
            playersComboBox.Items.Add("-");
            /*
            else
            {
            TODO: átvinni a helyére   
            createNotificationFormFauilt(rm.GetString("errorNotLoad", actualCultureInfo) +
                                                rolePlayGameName.Text +
                                                rm.GetString("errorFromGame", actualCultureInfo));
            }*/
            reloadDefaultImage();
        }

        private void reloadSkillList(List<GamePlayerSkill> skills)
        {
            playerSkillComboBox.SelectedItem = null;
            playerSkillComboBox.Items.Clear();
            foreach (GamePlayerSkill skill in skills)
            {
                playerSkillComboBox.Items.Add(skill.gamePlayerSkillName);
            }
            playerSkillComboBox.Text = rm.GetString("skill", actualCultureInfo);
        }

        private void reloadImage(string playerName)
        {
            GamePlayer player = findGamePlayer(playerName);
            reloadDefaultImage();
            if (player != null && !player.imagePath.Equals(""))
            {
                playerPicture.Image = Image.FromFile(player.imagePath);
            }
        }
        private void reloadDefaultImage()
        {
            if (!defaultImagePath.Equals(""))
            {
                playerPicture.Image = Image.FromFile(defaultImagePath);
            }
        }




        private void calculateSumPlayerPoint()
        {
            if (!isConverttableToInt(playerBasedPoint.Text))
            {
                playerBasedPoint.Text = ZERO.ToString();
            }
            if (!isConverttableToInt(playerExtraPoint.Text))
            {
                playerExtraPoint.Text = ZERO.ToString();
            }
            sumPlayerPoint.Text = (Convert.ToInt32(playerBasedPoint.Text) + Convert.ToInt32(playerExtraPoint.Text)).ToString();
        }




        private void loadLanguageTexts()
        {
            this.Text = rm.GetString("rolePlayBoard", actualCultureInfo);
            narrationButton.Text = rm.GetString("narration", actualCultureInfo);
            actualEvent.Text = rm.GetString("actualEvent", actualCultureInfo);
            diceLabel.Text = rm.GetString("diceInstruction", actualCultureInfo);
            throwDice.Text = rm.GetString("throwDice", actualCultureInfo);
            basePontLabel.Text = rm.GetString("basePoint", actualCultureInfo);
            extraPointLabel.Text = rm.GetString("extraPoint", actualCultureInfo);
            sumPointLabel.Text = rm.GetString("sumPoint", actualCultureInfo);
            opponentPointLabel.Text = rm.GetString("opponentPoint", actualCultureInfo);
            vsLabel.Text = rm.GetString("vs", actualCultureInfo);
            opponenetThrowDiceToo.Text = rm.GetString("opponentThrowToo", actualCultureInfo);
            languageGroupBox.Text = rm.GetString("languageTag", actualCultureInfo);
            languageRadioButtonHu.Text = rm.GetString("hu", actualCultureInfo);
            languageRadioButtonEn.Text = rm.GetString("en", actualCultureInfo);
            loadGame.Text = rm.GetString("loadGame", actualCultureInfo); ;
            generateGame.Text = rm.GetString("generateGame", actualCultureInfo);
            historyLabel.Text = rm.GetString("story", actualCultureInfo);
            playersComboBox.Text = rm.GetString("playerName", actualCultureInfo);
            playerSkillComboBox.Text = rm.GetString("skill", actualCultureInfo);
            notSavedGameLabel.Text = rm.GetString("gameIsNotSaved", actualCultureInfo);

            playerDiceLabel.Text = rm.GetString("playerDiceRoll", actualCultureInfo);
            opponentDiceLabel.Text = rm.GetString("opponentDiceRoll", actualCultureInfo);

            ladderRadioButton.Text = rm.GetString("task", actualCultureInfo);
            opponentRadioButton.Text = rm.GetString("opponent", actualCultureInfo);
            ladderComboBox.Text = rm.GetString("ladderTask", actualCultureInfo);
            opponentGroupBox.Text = rm.GetString("eventType", actualCultureInfo);

            diceType.Items.Clear();
            foreach (string actualDiceType in dicesList)
            {
                diceType.Items.Add(actualDiceType);
            }
            diceType.SelectedIndex = 0;
            playerBasedPoint.Text = ZERO.ToString();
            playerExtraPoint.Text = ZERO.ToString();
            opponentPoint.Text = ZERO.ToString();
            numberOfDice.Text = ZERO.ToString();
            reloadDefaultImage();
        }




        private bool isConverttableToInt(string number)
        {
            try
            {
                Convert.ToInt32(number);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
