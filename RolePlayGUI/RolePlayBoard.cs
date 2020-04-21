using RolePlaySet;
using System;
using System.Windows.Forms;
using System.Resources;
using System.Globalization;
using RolePlayGUI.ViewModel;
using System.Collections.Generic;

namespace RolePlayGUI
{
    public partial class RolePlayBoard : Form
    {
        internal static int ZERO = 0;

        private GameCoordinator gameCoordinator;

        private static int DEFAULT_NUMBER_OF_DICE = 4;
        private static string NEW_LINE = Environment.NewLine;

        private CultureInfo huCultureInfo = new CultureInfo("hu-HU");
        private CultureInfo enCultureInfo = new CultureInfo("en-US");
        private CultureInfo actualCultureInfo;
        private ResourceManager rm = new ResourceManager(typeof(Resources.Language.language));

        public RolePlayBoard(GameCoordinator gameCoordinator)
        {
            InitializeComponent();
            this.gameCoordinator = gameCoordinator;
        }

        private void RolePlay_Load(object sender, EventArgs e)
        {
            actualCultureInfo = huCultureInfo;
            loadLanguageTexts();
            loadAndFillEventTasks();

            reloadDefaultImage();

            ladderRadioButton.Checked = true;

            playerDiceLabel.Visible = false;
            opponentDiceLabel.Visible = false;
        }

        private void generateGame_Click(object sender, EventArgs e)
        {
            if (newGameName.Text != "")
            {
                gameCoordinator.generateNewGame(newGameName.Text);
                rolePlayGameName.Text = newGameName.Text;
            }
            else
            {
                createNotificationFormFauilt(rm.GetString("errorAddNameNewGame", actualCultureInfo));
            }
        }

        private void throwDice_Click(object sender, EventArgs e)
        {
            notSavedGameLabel.Visible = false;

            nextTurn();

            opponenetThrowDiceToo.Checked = false;
            playerExtraPoint.Text = ZERO.ToString();
            actualEvent.Text = "";
        }

        private void loadGame_Click(object sender, EventArgs e)
        {
            try
            {
                playersComboBox.Items.Clear();
                playerSkillComboBox.Items.Clear();
                gameCoordinator.loadGame(rolePlayGameName.Text);
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
                GamePlayer player = gameCoordinator.findGamePlayer(playersComboBox.SelectedItem.ToString());
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
            if (playerSkillComboBox.SelectedItem != null)
            {
                playerBasedPoint.Text = gameCoordinator.getPlayersSkillBasedPoint(playersComboBox.SelectedItem.ToString(), playerSkillComboBox.SelectedItem.ToString()).ToString();
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
                    gameCoordinator.addNarration(eventDescription.Text);
                }
            }
            catch (Exception)
            {
                notSavedGameLabel.Visible = true;
            }

            eventDescription.Text = "";
            playerDicesPictureBox.Visible = false;
            opponenetDicesPictureBox.Visible = false;
            playerDiceLabel.Visible = false;
            opponentDiceLabel.Visible = false;
        }
    }
}
