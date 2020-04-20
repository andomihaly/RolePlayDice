using RolePlayGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RolePlayGUI
{
    public partial class RolePlayBoard
    {

        public void VisualizeLastDiceRolls(RolledDiceInTurn rolledDices)
        {
            if (rolledDices.opponent.Count != 0)
            {
                opponentDiceLabel.Visible = true;
                opponenetDicesPictureBox.Visible = true;
                opponenetDicesPictureBox.Image = generateDiceImage(rolledDices.opponent);
            }
            else
            {
                opponentDiceLabel.Visible = false;
                opponenetDicesPictureBox.Visible = false;
            }
            playerDiceLabel.Visible = true;
            playerDicesPictureBox.Visible = true;
            playerDicesPictureBox.Image = generateDiceImage(rolledDices.player);
        }

        public void storeRolePlayInitContext(List<string> diceList, List<Task> taskList)
        {
            this.dicesList = diceList;
            this.taskList = taskList;
        }

        public void storeGameContext(string defaultImage, List<GamePlayer> players)
        {
            defaultImagePath = defaultImage;
            gamePlayers = players;
        }

        private Image generateDiceImage(List<Dice> rolledDices)
        {
            Bitmap generatedDiceImage = new Bitmap(55 * rolledDices.Count, 55);
            Graphics g = Graphics.FromImage(generatedDiceImage);
            g.Clear(SystemColors.AppWorkspace);
            for(int i= 0; i<rolledDices.Count; i++)
            {
                Image img = getDiceImage(rolledDices[i].value, rolledDices[i].type);
                g.DrawImage(img, new Point(55 * i, 0));
                img.Dispose();
            }

            g.Dispose();
            return generatedDiceImage;
        }

        private Image getDiceImage(string value, string diceType)
        {
            if (diceType.Equals("dF"))
            {
                if (value.Equals("1"))
                {
                    return Properties.Resources.dvp;
                }
                if (value.Equals("-1"))
                {
                    return Properties.Resources.dvm;
                }
                if (value.Equals("0"))
                {
                    return Properties.Resources.dve;
                }
            }
            else
            {
                if (value.Equals("1"))
                {
                    return Properties.Resources.dv1;
                }
                if (value.Equals("2"))
                {
                    return Properties.Resources.dv2;
                }
                if (value.Equals("3"))
                {
                    return Properties.Resources.dv3;
                }
                if (value.Equals("4"))
                {
                    return Properties.Resources.dv4;
                }
                if (value.Equals("5"))
                {
                    return Properties.Resources.dv5;
                }
                if (value.Equals("6"))
                {
                    return Properties.Resources.dv6;
                }
            }
            return Properties.Resources.dve;
        }

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



        public void refillStoryBox(String[] story)
        {
            storyBox.Clear();
            for (int i = story.Length; i > 0; i--)
            {
                storyBox.Text += i.ToString() + ". lépés:" + (story[i - 1] + NEW_LINE);
                if (i == story.Length)
                {
                    storyBox.Text += (NEW_LINE);
                }
            }
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
