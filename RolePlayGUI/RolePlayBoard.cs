using RolePlaySet;
using RolePlayEntity;
using System;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using System.Drawing;
using RolePlayGUI.ViewModel;
using System.Collections.Generic;

namespace RolePlayGUI
{
    public partial class RolePlayBoard : Form
    {
        private RolePlayGame rolePlayGamers;
        private static int ZERO = 0;
        private static int DEFAULT_NUMBER_OF_DICE = 4;
        private static string NEW_LINE = Environment.NewLine;

        private CultureInfo huCultureInfo = new CultureInfo("hu-HU");
        private CultureInfo enCultureInfo = new CultureInfo("en-US");
        private CultureInfo actualCultureInfo;
        private ResourceManager rm = new ResourceManager(typeof(Resources.Language.language));


        //actualGame contect
        private string defaultImagePath = "";
        private List<GamePlayer> gamePlayers = new List<GamePlayer>();
        

        public RolePlayBoard(RolePlayGame rolePlayGamers)
        {
            InitializeComponent();
            this.rolePlayGamers = rolePlayGamers;
        }

        private void RolePlay_Load(object sender, EventArgs e)
        {
            actualCultureInfo = huCultureInfo;
            loadLanguageTexts();
            loadAndFillEventTasks();

            if (!rolePlayGamers.getDefaultImage().Equals(""))
            {
                playerPicture.Image = Image.FromFile(rolePlayGamers.getDefaultImage());
            }
            ladderRadioButton.Checked = true;


            playerDiceLabel.Visible = false;
            opponentDiceLabel.Visible = false;
        }

        private void generateGame_Click(object sender, EventArgs e)
        {
            if (newGameName.Text != "")
            {
                rolePlayGamers.generateNewGame(newGameName.Text);
                rolePlayGameName.Text = newGameName.Text;
            }
            else
            {

                createNotificationFormFauilt(rm.GetString("errorAddNameNewGame", actualCultureInfo));
            }
        }

        private void throwDice_Click(object sender, EventArgs e)
        {
            lastRoll = DateTime.Now;
            notSavedGameLabel.Visible = false;
            if (isPointsAndNumbersConvertable())
            {
                try
                {
                    string actualName = "";
                    if (playersComboBox.SelectedItem!= null)
                    {
                        actualName = playersComboBox.SelectedItem.ToString();
                    }
                    else if (playersComboBox.Text != null && !playersComboBox.Text.ToString().Equals(rm.GetString("playerName", actualCultureInfo)))
                    {
                        actualName = playersComboBox.Text.ToString();
                    }
                    if (opponentRadioButton.Checked)
                    {
                        if (isConverttableToInt(opponentPoint.Text))
                        {
                            rolePlayGamers.addTurnOpponentEvent(eventDescription.Text, actualName,
                                Convert.ToInt32(playerBasedPoint.Text), Convert.ToInt32(playerExtraPoint.Text),
                                Convert.ToInt32(numberOfDice.Text), diceType.SelectedItem.ToString(),
                                Convert.ToInt32(opponentPoint.Text), opponenetThrowDiceToo.Checked);
                        }
                    }
                    else
                    {
                        String taskName = findEventTaskBasedOnEventTaskName(ladderComboBox.SelectedItem.ToString());
                        if (taskName != null)
                        {
                            rolePlayGamers.addTurnTaskEvent(eventDescription.Text, actualName,
                                    Convert.ToInt32(playerBasedPoint.Text), Convert.ToInt32(playerExtraPoint.Text),
                                    Convert.ToInt32(numberOfDice.Text), diceType.SelectedItem.ToString(), taskName);
                        }

                    }
                    eventDescription.Text = "";
                }
                catch (Exception)
                {
                    notSavedGameLabel.Visible = true;
                }

            }
            opponenetThrowDiceToo.Checked = false;
            playerExtraPoint.Text = ZERO.ToString();
            actualEvent.Text = "";

            //refillStoryBox();
        }

        private void loadGame_Click(object sender, EventArgs e)
        {
            try
            {
                playersComboBox.Items.Clear();
                playerSkillComboBox.Items.Clear();
                rolePlayGamers.loadGame(rolePlayGameName.Text);
                fillGUIWithGame();
            }
            catch (Exception)
            {
                createNotificationFormFauilt("Nem tudtuk betölteni a \"" + rolePlayGameName.Text + "\" játékot!");
            }
        }

        
        private void playersComboBox_KeyDown(object sender, KeyEventArgs e)
        {
            playerSkillComboBox.Text = rm.GetString("skill", actualCultureInfo);
            playerSkillComboBox.Items.Clear();
            playerBasedPoint.Text = ZERO.ToString();
            reloadDefaultImage();
        }

        private void playersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (playersComboBox.SelectedItem.ToString().Equals("-"))
            {
                playersComboBox.SelectedText = "";
                playersComboBox.Text = "";
                reloadDefaultImage();
            }
            else if (!playersComboBox.SelectedItem.ToString().Equals(""))
            {
                GamePlayer player = findGamePlayer(playersComboBox.SelectedItem.ToString());
                if (player != null)
                { 
                    reloadSkillList(player.gamePlayerSkills);
                    playerBasedPoint.Text = ZERO.ToString();
                }
                reloadImage(playersComboBox.SelectedItem.ToString());
            }
        }

        private void playerSkillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            setThePlayerBasedPoint();
        }

        private void setThePlayerBasedPoint()
        {
            playerBasedPoint.Text = ZERO.ToString();
            GamePlayer player = findGamePlayer(playersComboBox.SelectedItem.ToString());
            if (player != null && playerSkillComboBox.SelectedItem != null)
            {
                playerBasedPoint.Text = getSkillPoint(player, playerSkillComboBox.SelectedItem.ToString()).ToString();
            }
        }

        private GamePlayer findGamePlayer(String gamePlayerName)
        {
            foreach(GamePlayer gamePlayer in gamePlayers)
            {
                if (gamePlayer.name.Equals(gamePlayerName))
                {
                    return gamePlayer;
                }
            }
            return null;
        }

        private int getSkillPoint(GamePlayer player, string skillName)
        {
            foreach (GamePlayerSkill skill in player.gamePlayerSkills)
            {
                if (skill.gamePlayerSkillName.Equals(skillName))
                {
                    return skill.gamePlayerSkillPoint;
                }
            }
            return ZERO;
        }

        private void playerBasedPoint_TextChanged(object sender, EventArgs e)
        {
            calculateSumPlayerPoint();
        }

        private void extraPoint_TextChanged(object sender, EventArgs e)
        {
            calculateSumPlayerPoint();
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

        private void createNotificationFormFauilt(string message)
        {
            MessageBox.Show(message, rm.GetString("errorTag", actualCultureInfo), MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void ladderRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            opponenetThrowDiceToo.Visible = false;
            opponentPoint.Visible = false;
            ladderComboBox.Visible = true;
        }

        private void opponentRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            ladderComboBox.Visible = false;
            ladderComboBox.Text = rm.GetString("ladderTask", actualCultureInfo);
            opponenetThrowDiceToo.Visible = true;
            opponentPoint.Visible = true;
        }

        private void narrationButton_Click(object sender, EventArgs e)
        {
            notSavedGameLabel.Visible = false;
            try
            {
                if (!eventDescription.Text.Equals(""))
                {
                    rolePlayGamers.addNarration(eventDescription.Text);
                }
            }
            catch (Exception)
            {
                notSavedGameLabel.Visible = true;
            }

            eventDescription.Text = "";
            pictureBox1.Visible = false;
            pictureBox2.Visible = false;
            playerDiceLabel.Visible = false;
            opponentDiceLabel.Visible = false;
            //refillStoryBox();
        }
    }
}
