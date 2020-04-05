using RolePlayEntity;
using System;
using System.Drawing;

namespace RolePlayGUI
{
    public partial class RolePlayBoard
    {
        private void fillGUIWithGame()
        {
            notSavedGameLabel.Visible = false;
            if (rolePlayGamers.getPlayers() != null)
            {
                foreach (Player OnePlayerName in rolePlayGamers.getPlayers())
                {
                    playersComboBox.Items.Add(OnePlayerName.name);
                }
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



        private void reloadSkillList(Player selectedPlayer)
        {
            playerSkillComboBox.SelectedItem = null;
            playerSkillComboBox.Items.Clear();
            foreach (Skill skill in selectedPlayer.skills)
            {
                playerSkillComboBox.Items.Add(skill.name);
            }
            playerSkillComboBox.Text = rm.GetString("skill", actualCultureInfo);
        }

        private void reloadImage(Player selectedPlayer)
        {
            if (!selectedPlayer.image.Equals(""))
            {
                playerPicture.Image = Image.FromFile(selectedPlayer.image);
            }
            else
            {
                if (!rolePlayGamers.getDefaultImage().Equals(""))
                {
                    playerPicture.Image = Image.FromFile(rolePlayGamers.getDefaultImage());
                }
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

            diceType.Items.Clear();
            foreach (string actualDiceType in diceTypes)
            {
                diceType.Items.Add(actualDiceType);
            }
            diceType.SelectedIndex = 0;
            playerBasedPoint.Text = ZERO.ToString();
            playerExtraPoint.Text = ZERO.ToString();
            opponentPoint.Text = ZERO.ToString();
            numberOfDice.Text = ZERO.ToString();
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
