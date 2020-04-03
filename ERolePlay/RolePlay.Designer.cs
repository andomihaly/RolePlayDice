namespace ERolePlay
{
    partial class RolePlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.playersComboBox = new System.Windows.Forms.ComboBox();
            this.playerBasedPoint = new System.Windows.Forms.TextBox();
            this.playerSkillComboBox = new System.Windows.Forms.ComboBox();
            this.extraPoint = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.diceType = new System.Windows.Forms.ComboBox();
            this.opponentPoint = new System.Windows.Forms.TextBox();
            this.eventDescription = new System.Windows.Forms.TextBox();
            this.history = new System.Windows.Forms.Label();
            this.storyBox = new System.Windows.Forms.TextBox();
            this.actualEvent = new System.Windows.Forms.Label();
            this.rolePlayGameName = new System.Windows.Forms.TextBox();
            this.loadGame = new System.Windows.Forms.Button();
            this.generateGame = new System.Windows.Forms.Button();
            this.newGameName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.sumPlayerPoint = new System.Windows.Forms.Label();
            this.throwDice = new System.Windows.Forms.Button();
            this.numberOfDice = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.opponenetThrowDiceToo = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // playersComboBox
            // 
            this.playersComboBox.DropDownHeight = 100;
            this.playersComboBox.DropDownWidth = 120;
            this.playersComboBox.FormattingEnabled = true;
            this.playersComboBox.IntegralHeight = false;
            this.playersComboBox.Location = new System.Drawing.Point(12, 102);
            this.playersComboBox.Name = "playersComboBox";
            this.playersComboBox.Size = new System.Drawing.Size(121, 21);
            this.playersComboBox.TabIndex = 0;
            this.playersComboBox.SelectedIndexChanged += new System.EventHandler(this.playersComboBox_SelectedIndexChanged);
            // 
            // playerBasedPoint
            // 
            this.playerBasedPoint.Location = new System.Drawing.Point(269, 102);
            this.playerBasedPoint.Name = "playerBasedPoint";
            this.playerBasedPoint.Size = new System.Drawing.Size(100, 20);
            this.playerBasedPoint.TabIndex = 1;
            this.playerBasedPoint.TextChanged += new System.EventHandler(this.playerBasedPoint_TextChanged);
            // 
            // playerSkillComboBox
            // 
            this.playerSkillComboBox.DropDownHeight = 100;
            this.playerSkillComboBox.DropDownWidth = 120;
            this.playerSkillComboBox.FormattingEnabled = true;
            this.playerSkillComboBox.IntegralHeight = false;
            this.playerSkillComboBox.Location = new System.Drawing.Point(142, 102);
            this.playerSkillComboBox.Name = "playerSkillComboBox";
            this.playerSkillComboBox.Size = new System.Drawing.Size(121, 21);
            this.playerSkillComboBox.TabIndex = 2;
            this.playerSkillComboBox.SelectedIndexChanged += new System.EventHandler(this.playerSkillComboBox_SelectedIndexChanged);
            // 
            // extraPoint
            // 
            this.extraPoint.Location = new System.Drawing.Point(375, 102);
            this.extraPoint.Name = "extraPoint";
            this.extraPoint.Size = new System.Drawing.Size(100, 20);
            this.extraPoint.TabIndex = 3;
            this.extraPoint.TextChanged += new System.EventHandler(this.extraPoint_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(536, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(21, 13);
            this.label1.TabIndex = 4;
            this.label1.Tag = "";
            this.label1.Text = "vs.";
            // 
            // diceType
            // 
            this.diceType.FormattingEnabled = true;
            this.diceType.Location = new System.Drawing.Point(486, 46);
            this.diceType.Name = "diceType";
            this.diceType.Size = new System.Drawing.Size(71, 21);
            this.diceType.TabIndex = 5;
            // 
            // opponentPoint
            // 
            this.opponentPoint.Location = new System.Drawing.Point(574, 102);
            this.opponentPoint.Name = "opponentPoint";
            this.opponentPoint.Size = new System.Drawing.Size(106, 20);
            this.opponentPoint.TabIndex = 6;
            this.opponentPoint.TextChanged += new System.EventHandler(this.opponentPoint_TextChanged);
            // 
            // eventDescription
            // 
            this.eventDescription.Location = new System.Drawing.Point(12, 28);
            this.eventDescription.Multiline = true;
            this.eventDescription.Name = "eventDescription";
            this.eventDescription.Size = new System.Drawing.Size(399, 48);
            this.eventDescription.TabIndex = 7;
            // 
            // history
            // 
            this.history.AutoSize = true;
            this.history.Location = new System.Drawing.Point(12, 150);
            this.history.Name = "history";
            this.history.Size = new System.Drawing.Size(50, 13);
            this.history.TabIndex = 8;
            this.history.Text = "Történet:";
            // 
            // storyBox
            // 
            this.storyBox.Location = new System.Drawing.Point(12, 166);
            this.storyBox.Multiline = true;
            this.storyBox.Name = "storyBox";
            this.storyBox.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.storyBox.Size = new System.Drawing.Size(668, 218);
            this.storyBox.TabIndex = 9;
            // 
            // actualEvent
            // 
            this.actualEvent.AutoSize = true;
            this.actualEvent.Location = new System.Drawing.Point(12, 12);
            this.actualEvent.Name = "actualEvent";
            this.actualEvent.Size = new System.Drawing.Size(92, 13);
            this.actualEvent.TabIndex = 10;
            this.actualEvent.Text = "Aktuális esemény:";
            // 
            // rolePlayGameName
            // 
            this.rolePlayGameName.Location = new System.Drawing.Point(12, 390);
            this.rolePlayGameName.Name = "rolePlayGameName";
            this.rolePlayGameName.Size = new System.Drawing.Size(100, 20);
            this.rolePlayGameName.TabIndex = 11;
            // 
            // loadGame
            // 
            this.loadGame.Location = new System.Drawing.Point(119, 390);
            this.loadGame.Name = "loadGame";
            this.loadGame.Size = new System.Drawing.Size(106, 23);
            this.loadGame.TabIndex = 12;
            this.loadGame.Text = "load game";
            this.loadGame.UseVisualStyleBackColor = true;
            this.loadGame.Click += new System.EventHandler(this.loadGame_Click);
            // 
            // generateGame
            // 
            this.generateGame.Location = new System.Drawing.Point(515, 390);
            this.generateGame.Name = "generateGame";
            this.generateGame.Size = new System.Drawing.Size(165, 23);
            this.generateGame.TabIndex = 14;
            this.generateGame.Text = "generate empty game";
            this.generateGame.UseVisualStyleBackColor = true;
            this.generateGame.Click += new System.EventHandler(this.generateGame_Click);
            // 
            // newGameName
            // 
            this.newGameName.Location = new System.Drawing.Point(409, 390);
            this.newGameName.Name = "newGameName";
            this.newGameName.Size = new System.Drawing.Size(100, 20);
            this.newGameName.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(266, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Alap pont:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(372, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Extra pont:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(571, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 17;
            this.label4.Text = "Ellen pont:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(483, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 13);
            this.label5.TabIndex = 18;
            this.label5.Text = "Összpont:";
            // 
            // sumPlayerPoint
            // 
            this.sumPlayerPoint.AutoSize = true;
            this.sumPlayerPoint.Location = new System.Drawing.Point(497, 105);
            this.sumPlayerPoint.Name = "sumPlayerPoint";
            this.sumPlayerPoint.Size = new System.Drawing.Size(13, 13);
            this.sumPlayerPoint.TabIndex = 19;
            this.sumPlayerPoint.Text = "0";
            // 
            // throwDice
            // 
            this.throwDice.Location = new System.Drawing.Point(574, 44);
            this.throwDice.Name = "throwDice";
            this.throwDice.Size = new System.Drawing.Size(106, 23);
            this.throwDice.TabIndex = 20;
            this.throwDice.Text = "dobás";
            this.throwDice.UseVisualStyleBackColor = true;
            this.throwDice.Click += new System.EventHandler(this.throwDice_Click);
            // 
            // numberOfDice
            // 
            this.numberOfDice.Location = new System.Drawing.Point(431, 47);
            this.numberOfDice.Name = "numberOfDice";
            this.numberOfDice.Size = new System.Drawing.Size(49, 20);
            this.numberOfDice.TabIndex = 21;
            this.numberOfDice.TextChanged += new System.EventHandler(this.numberOfDice_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(428, 28);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(127, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Kockák száma és típusa:";
            // 
            // opponenetThrowDiceToo
            // 
            this.opponenetThrowDiceToo.AutoSize = true;
            this.opponenetThrowDiceToo.Location = new System.Drawing.Point(576, 135);
            this.opponenetThrowDiceToo.Name = "opponenetThrowDiceToo";
            this.opponenetThrowDiceToo.Size = new System.Drawing.Size(91, 17);
            this.opponenetThrowDiceToo.TabIndex = 23;
            this.opponenetThrowDiceToo.Text = "Ellenfél is dob";
            this.opponenetThrowDiceToo.UseVisualStyleBackColor = true;
            // 
            // RolePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 433);
            this.Controls.Add(this.opponenetThrowDiceToo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numberOfDice);
            this.Controls.Add(this.throwDice);
            this.Controls.Add(this.sumPlayerPoint);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.generateGame);
            this.Controls.Add(this.newGameName);
            this.Controls.Add(this.loadGame);
            this.Controls.Add(this.rolePlayGameName);
            this.Controls.Add(this.actualEvent);
            this.Controls.Add(this.storyBox);
            this.Controls.Add(this.history);
            this.Controls.Add(this.eventDescription);
            this.Controls.Add(this.opponentPoint);
            this.Controls.Add(this.diceType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.extraPoint);
            this.Controls.Add(this.playerSkillComboBox);
            this.Controls.Add(this.playerBasedPoint);
            this.Controls.Add(this.playersComboBox);
            this.Name = "RolePlay";
            this.Text = "RolePlay";
            this.Load += new System.EventHandler(this.RolePlay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox playersComboBox;
        private System.Windows.Forms.TextBox playerBasedPoint;
        private System.Windows.Forms.ComboBox playerSkillComboBox;
        private System.Windows.Forms.TextBox extraPoint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox diceType;
        private System.Windows.Forms.TextBox opponentPoint;
        private System.Windows.Forms.TextBox eventDescription;
        private System.Windows.Forms.Label history;
        private System.Windows.Forms.TextBox storyBox;
        private System.Windows.Forms.Label actualEvent;
        private System.Windows.Forms.TextBox rolePlayGameName;
        private System.Windows.Forms.Button loadGame;
        private System.Windows.Forms.Button generateGame;
        private System.Windows.Forms.TextBox newGameName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label sumPlayerPoint;
        private System.Windows.Forms.Button throwDice;
        private System.Windows.Forms.TextBox numberOfDice;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox opponenetThrowDiceToo;
    }
}

