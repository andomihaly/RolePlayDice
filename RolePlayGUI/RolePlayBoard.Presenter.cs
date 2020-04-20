using RolePlayGUI.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace RolePlayGUI
{
    public partial class RolePlayBoard
    {
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



        private Image generateDiceImage(List<Dice> rolledDices)
        {
            Bitmap generatedDiceImage = new Bitmap(55 * rolledDices.Count, 55);
            Graphics g = Graphics.FromImage(generatedDiceImage);
            g.Clear(SystemColors.AppWorkspace);
            for (int i = 0; i < rolledDices.Count; i++)
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
    }
}
