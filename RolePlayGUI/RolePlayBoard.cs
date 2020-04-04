using RolePlaySet;
using RolePlaySet.Entity;
using System;
using System.Windows.Forms;


namespace RolePlayGUI
{
    public partial class RolePlayBoard : Form
    {
        private RolePlayGamers rolePlayGamers;
        private static int ZERO = 0;
        private static int DEFAULT_NUMBER_OF_DICE = 4;
        private static string[] diceTypes = {"d3","dF3"};

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
                MessageBox.Show("Nem tudtuk betölteni a \"" + rolePlayGameName.Text + "\" játékot!");
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
                MessageBox.Show("Nem tudtuk betölteni a játékosokat a \"" + rolePlayGameName.Text + "\" játékból!");
            }
            foreach (string actualDiceType in diceTypes)
            {
                diceType.Items.Add(actualDiceType);
            }
            refillStoryBox();
        }

        private void playersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player selectedPlayer = rolePlayGamers.getPlayerByName(playersComboBox.SelectedItem.ToString());
            if (selectedPlayer == null)
            {
                MessageBox.Show("Nem találtuk meg a \""+ playersComboBox.SelectedItem + "\"játékost!");
            }
            else
            {
                playerSkillComboBox.SelectedItem = null;
                playerSkillComboBox.Items.Clear();
                foreach (Skill skill in selectedPlayer.skills)
                {
                    playerSkillComboBox.Items.Add(skill.name);
                }
                setThePlayerBasedPoint();
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
                MessageBox.Show("El kell nevezni az új játékot!");
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

        private void RolePlay_Load(object sender, EventArgs e)
        {

        }
    }
}
