using System;
using System.Drawing;

namespace RolePlayGUI
{
    public partial class RolePlayBoard
    {
        private DateTime lastPlayerRoll = DateTime.Now;
        private DateTime lastRoll;

        public void VisualizeLastDiceRolls(string [,] dicesRolls)
        {
            if (lastRoll.CompareTo(lastPlayerRoll) == 0)
            {
                opponentDiceLabel.Visible = true;
                rolledDiceOpponent.Visible = true;
                rolledDiceOpponent.Text = "";
                for (int i = 0; i < dicesRolls.Length / 2; i++)
                {
                    rolledDiceOpponent.Text += " [" + dicesRolls[i, 0] + "]";
                }
            }
            else
            {
                rolledDicePlayer.Text = "";
                rolledDiceOpponent.Text = "";
                playerDiceLabel.Visible = true;
                opponentDiceLabel.Visible = false;

                rolledDicePlayer.Visible = true;
                rolledDiceOpponent.Visible = false;
                for (int i = 0; i < dicesRolls.Length / 2; i++)
                {
                    rolledDicePlayer.Text += " [" + dicesRolls[i, 0] + "]";
                }
                lastPlayerRoll = lastRoll;
            }
        }

        
        private void loadAndFillEventTasks()
        {
            ladderComboBox.Items.Clear();
            String[,] eventTasks = rolePlayGamers.getTaskTypeList();
            for(int i=0; i<eventTasks.Length/2; i++)
            {
                ladderComboBox.Items.Add(eventTasks[i,0]);
            }
            ladderComboBox.Text = rm.GetString("ladderTask", actualCultureInfo);
        }

        private string findEventTaskBasedOnEventTaskName(string eventTaskName)
        {
            String[,] eventTasks = rolePlayGamers.getTaskTypeList();
            for (int i = 0; i < eventTasks.Length/2; i++)
            {
                if (eventTasks[i, 0].Equals(eventTaskName))
                    return eventTasks[i, 0];
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
            if (rolePlayGamers.getPlayers() != null)
            {
                string[,] players = rolePlayGamers.getPlayers();
                for(int i=0; i<players.Length/2; i++)
                {
                    playersComboBox.Items.Add(players[i,0]);
                }
                playersComboBox.Items.Add("-");
            }
            else
            {
                createNotificationFormFauilt(rm.GetString("errorNotLoad", actualCultureInfo) +
                                                rolePlayGameName.Text +
                                                rm.GetString("errorFromGame", actualCultureInfo));
            }
            if (!rolePlayGamers.getDefaultImage().Equals(""))
            {
                playerPicture.Image = Image.FromFile(rolePlayGamers.getDefaultImage());
            }
            refillStoryBox();
        }

        private void refillStoryBox()
        {
            storyBox.Clear();
            string[] tempStory = rolePlayGamers.getStory();
            for (int i = tempStory.Length; i > 0; i--)
            {
                storyBox.Text += i.ToString() + ". lépés:" + (tempStory[i - 1] + NEW_LINE);
                if (i == tempStory.Length)
                {
                    storyBox.Text += (NEW_LINE);
                }
            }
        }



        private void reloadSkillList(string[,] skills)
        {
            playerSkillComboBox.SelectedItem = null;
            playerSkillComboBox.Items.Clear();
            for (int i=0; i< skills.Length/2; i++)
            {
                playerSkillComboBox.Items.Add(skills[i,0]);
            }
            playerSkillComboBox.Text = rm.GetString("skill", actualCultureInfo);
        }

        private void reloadImage(string playerName)
        {
            string[,] players = rolePlayGamers.getPlayers();
            for (int i = 0; i < players.Length / 2; i++)
            {
                if (players[i, 0].Equals(playerName))
                {
                    if (!players[i, 1].Equals(""))
                    {
                        playerPicture.Image = Image.FromFile(players[i, 1]);
                    }
                    else
                    {
                        reloadDefaultImage();
                    }
                }
            }
        }
        private void reloadDefaultImage()
        {
            if (!rolePlayGamers.getDefaultImage().Equals(""))
            {
                playerPicture.Image = Image.FromFile(rolePlayGamers.getDefaultImage());
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
            foreach (string actualDiceType in rolePlayGamers.getAvailableDiceName())
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
