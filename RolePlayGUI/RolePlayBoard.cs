using RolePlaySet;
using RolePlaySet.Entity;
using System;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;

namespace RolePlayGUI
{
    public partial class RolePlayBoard : Form
    {
        private RolePlayGamers rolePlayGamers;
        private static int ZERO = 0;
        private static int DEFAULT_NUMBER_OF_DICE = 4;
        private static string ERROR_TEXT = "Hiba";
        private static string[] diceTypes = {"d3","dF3"};
        private CultureInfo huCultureInfo = new CultureInfo("hu-HU");
        private CultureInfo enCultureInfo = new CultureInfo("en-US");
        private CultureInfo actualCultureInfo;
        ResourceManager rm = new ResourceManager(typeof(Resources.Language.language));

        public RolePlayBoard(RolePlayGamers rolePlayGamers)
        {
            InitializeComponent();
            this.rolePlayGamers = rolePlayGamers;
        }


        private void loadGame_Click(object sender, EventArgs e)
        {
            try
            {
                diceType.Items.Clear();
                playersComboBox.Items.Clear();
                playerSkillComboBox.Items.Clear();
                rolePlayGamers.loadGame(rolePlayGameName.Text);
                fillGUIWithGame();
            }
            catch(Exception)
            {
                createNotificationFormFauilt("Nem tudtuk betölteni a \"" + rolePlayGameName.Text + "\" játékot!");
            }

            
        }
        private void fillGUIWithGame()
        {
            if (rolePlayGamers.getPlayers() != null)
            {
                foreach (Player OnePlayerName in rolePlayGamers.getPlayers())
                {
                    playersComboBox.Items.Add(OnePlayerName.name);
                }
            }
            else
            {
                createNotificationFormFauilt(rm.GetString("errorNotLoad", actualCultureInfo) + rolePlayGameName.Text + rm.GetString("errorFromGame", actualCultureInfo));
            }
            refillStoryBox();
        }

        private void playersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!playersComboBox.SelectedItem.ToString().Equals(""))
            {
                Player selectedPlayer = rolePlayGamers.getPlayerByName(playersComboBox.SelectedItem.ToString());
                if (selectedPlayer == null)
                {
                    createNotificationFormFauilt(rm.GetString("errorNotFound", actualCultureInfo) + playersComboBox.SelectedItem + rm.GetString("errorNotFoundPlayer", actualCultureInfo));
                }
                else
                {
                    playerSkillComboBox.SelectedItem = null;
                    playerSkillComboBox.Items.Clear();
                    foreach (Skill skill in selectedPlayer.skills)
                    {
                        playerSkillComboBox.Items.Add(skill.name);
                    }
                    playerSkillComboBox.Text = rm.GetString("skill", actualCultureInfo);
                    setThePlayerBasedPoint();
                }
            }
        }

        private void playerSkillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setThePlayerBasedPoint();
        }
        private void setThePlayerBasedPoint()
        {
            Player selectedPlayer = rolePlayGamers.getPlayerByName(playersComboBox.SelectedItem.ToString());
            playerBasedPoint.Text = ZERO.ToString();
            for (int i = 0; i < selectedPlayer.skills.Count; i++)
            {
                if (playerSkillComboBox.SelectedItem != null && playerSkillComboBox.SelectedItem.ToString().Equals(selectedPlayer.skills[i].name))
                {
                    playerBasedPoint.Text = selectedPlayer.skills[i].score.ToString();
                }
            }
        }

        private void playerBasedPoint_TextChanged(object sender, EventArgs e)
        {
            calculateSumPlayerPoint();
        }

        private void extraPoint_TextChanged(object sender, EventArgs e)
        {
            calculateSumPlayerPoint();
        }

        private void calculateSumPlayerPoint()
        {
            if (!isConverttableToInt(playerBasedPoint.Text))
            {
                playerBasedPoint.Text = ZERO.ToString();
            }
            if (!isConverttableToInt(extraPoint.Text))
            {
                extraPoint.Text = ZERO.ToString();
            }
            sumPlayerPoint.Text = (Convert.ToInt32(playerBasedPoint.Text) + Convert.ToInt32(extraPoint.Text)).ToString();
        }

        private void opponentPoint_TextChanged(object sender, EventArgs e)
        {
            if (!isConverttableToInt(opponentPoint.Text))
            { 
                opponentPoint.Text = ZERO.ToString();
            }
        }

        private void numberOfDice_TextChanged(object sender, EventArgs e)
        {
            if (!isConverttableToInt(numberOfDice.Text))
            {
                numberOfDice.Text = DEFAULT_NUMBER_OF_DICE.ToString();
            }          
        }

        private void generateGame_Click(object sender, EventArgs e)
        {
            if (newGameName.Text != "")
            {
                rolePlayGamers.generateNewGame(newGameName.Text);
            }
            else
            {
                
                createNotificationFormFauilt(rm.GetString("errorAddNameNewGame", actualCultureInfo));
            }
        }

        private void throwDice_Click(object sender, EventArgs e)
        {
            if (isConverttableToInt(sumPlayerPoint.Text) && isConverttableToInt(numberOfDice.Text) && isConverttableToInt(opponentPoint.Text))
            {
                //rolePlayGamers.AddTurn(eventDescription.Text, Convert.ToInt32(sumPlayerPoint.Text), Convert.ToInt32(numberOfDice.Text), diceType.SelectedItem.ToString(), Convert.ToInt32(opponentPoint.Text), opponenetThrowDiceToo.CanSelect);
            }
            opponenetThrowDiceToo.Checked = false;
            extraPoint.Text = ZERO.ToString();
            actualEvent.Text = "";
            refillStoryBox();
        }

        private void refillStoryBox()
        {
            storyBox.Clear();
            foreach (String OneEvent in rolePlayGamers.getStory())
            {
                storyBox.AppendText("\r\n" + OneEvent);
            }
        }
        private bool isConverttableToInt(String number)
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

        private void createNotificationFormFauilt(string message)
        {
            MessageBox.Show(message, ERROR_TEXT, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void RolePlay_Load(object sender, EventArgs e)
        {
            actualCultureInfo = huCultureInfo;
            loadLanguageTexts();
        }

        private void languageRadioButtonHu_CheckedChanged(object sender, EventArgs e)
        {
            if (languageRadioButtonHu.Checked)
            {
                actualCultureInfo = huCultureInfo;
                loadLanguageTexts();
            }
        }

        private void languageRadioButtonEn_CheckedChanged(object sender, EventArgs e)
        {
            if (languageRadioButtonEn.Checked)
            {
                actualCultureInfo = enCultureInfo;
                loadLanguageTexts();
            }
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

            diceType.Items.Clear();
            foreach (string actualDiceType in diceTypes)
            {
                diceType.Items.Add(actualDiceType);
            }

        }
    }
}
