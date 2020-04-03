using RolePlaySet;
using RolePlaySet.Entity;
using System;
using System.Windows.Forms;


namespace RolePlayDice
{
    public partial class RolePlay : Form
    {
        private RolePlayGamers rolePlayGamers;
        private static int ZERO = 0;
        private static int DEFAULT_NUMBER_OF_DICE = 4;
        private static string[] diceTypes = {"d3","dF3"};

        public RolePlay(RolePlayGamers rolePlayGamers)
        {
            this.rolePlayGamers = rolePlayGamers;
        }

        private void RolePlay_Load(object sender, EventArgs e)
        {

        }

        private void loadGame_Click(object sender, EventArgs e)
        {
            rolePlayGamers.loadGame(rolePlayGameName.Text);
            foreach (Player OnePlayerName in rolePlayGamers.getPlayersName())
            {
                playersComboBox.Items.Add(OnePlayerName.name);
            }
            diceType.Items.Clear();
            foreach (string actualDiceType in diceTypes)
            {
                diceType.Items.Add(actualDiceType);
            }
        }

        private void playersComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player selectedPlayer = rolePlayGamers.getPlayerByName(playersComboBox.SelectedText);
            foreach (Skill skill in selectedPlayer.skills)
                playerSkillComboBox.Items.Add(skill);
        }

        private void playerSkillComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Player selectedPlayer = rolePlayGamers.getPlayerByName(playersComboBox.SelectedText);
            playerBasedPoint.Text = ZERO.ToString();
            for (int i=0; i<selectedPlayer.skills.Length; i++)
            {
                if (playerSkillComboBox.SelectedText == selectedPlayer.skills[i].name)
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
                rolePlayGamers.AddTurn(Convert.ToInt32(sumPlayerPoint.Text), Convert.ToInt32(numberOfDice.Text), diceType.SelectedText, Convert.ToInt32(opponentPoint.Text), opponenetThrowDiceToo.CanSelect);
            }
            opponenetThrowDiceToo.Checked = false;
            storyBox.Clear();
            foreach(String OneEvent in rolePlayGamers.loadStory())
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
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
    }
}
