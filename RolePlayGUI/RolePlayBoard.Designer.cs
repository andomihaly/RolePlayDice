namespace RolePlayGUI
{
    public partial class RolePlayBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RolePlayBoard));
            this.playersComboBox = new System.Windows.Forms.ComboBox();
            this.playerBasedPoint = new System.Windows.Forms.TextBox();
            this.playerSkillComboBox = new System.Windows.Forms.ComboBox();
            this.playerExtraPoint = new System.Windows.Forms.TextBox();
            this.vsLabel = new System.Windows.Forms.Label();
            this.diceType = new System.Windows.Forms.ComboBox();
            this.opponentPoint = new System.Windows.Forms.TextBox();
            this.eventDescription = new System.Windows.Forms.TextBox();
            this.historyLabel = new System.Windows.Forms.Label();
            this.storyBox = new System.Windows.Forms.TextBox();
            this.actualEvent = new System.Windows.Forms.Label();
            this.rolePlayGameName = new System.Windows.Forms.TextBox();
            this.newGameName = new System.Windows.Forms.TextBox();
            this.basePontLabel = new System.Windows.Forms.Label();
            this.extraPointLabel = new System.Windows.Forms.Label();
            this.opponentPointLabel = new System.Windows.Forms.Label();
            this.sumPointLabel = new System.Windows.Forms.Label();
            this.sumPlayerPoint = new System.Windows.Forms.Label();
            this.numberOfDice = new System.Windows.Forms.TextBox();
            this.diceLabel = new System.Windows.Forms.Label();
            this.opponenetThrowDiceToo = new System.Windows.Forms.CheckBox();
            this.languageRadioButtonHu = new System.Windows.Forms.RadioButton();
            this.languageRadioButtonEn = new System.Windows.Forms.RadioButton();
            this.languageGroupBox = new System.Windows.Forms.GroupBox();
            this.notSavedGameLabel = new System.Windows.Forms.Label();
            this.throwDice = new System.Windows.Forms.Button();
            this.generateGame = new System.Windows.Forms.Button();
            this.loadGame = new System.Windows.Forms.Button();
            this.playerPicture = new System.Windows.Forms.PictureBox();
            this.opponentGroupBox = new System.Windows.Forms.GroupBox();
            this.opponentRadioButton = new System.Windows.Forms.RadioButton();
            this.ladderRadioButton = new System.Windows.Forms.RadioButton();
            this.ladderComboBox = new System.Windows.Forms.ComboBox();
            this.narrationButton = new System.Windows.Forms.Button();
            this.languageGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).BeginInit();
            this.opponentGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // playersComboBox
            // 
            this.playersComboBox.DropDownHeight = 100;
            this.playersComboBox.DropDownWidth = 120;
            this.playersComboBox.FormattingEnabled = true;
            this.playersComboBox.IntegralHeight = false;
            this.playersComboBox.Location = new System.Drawing.Point(10, 130);
            this.playersComboBox.Name = "playersComboBox";
            this.playersComboBox.Size = new System.Drawing.Size(121, 21);
            this.playersComboBox.TabIndex = 15;
            this.playersComboBox.SelectedIndexChanged += new System.EventHandler(this.playersComboBox_SelectedIndexChanged);
            this.playersComboBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.playersComboBox_KeyDown);
            // 
            // playerBasedPoint
            // 
            this.playerBasedPoint.Location = new System.Drawing.Point(205, 130);
            this.playerBasedPoint.Name = "playerBasedPoint";
            this.playerBasedPoint.Size = new System.Drawing.Size(100, 20);
            this.playerBasedPoint.TabIndex = 25;
            this.playerBasedPoint.TextChanged += new System.EventHandler(this.playerBasedPoint_TextChanged);
            // 
            // playerSkillComboBox
            // 
            this.playerSkillComboBox.DropDownHeight = 100;
            this.playerSkillComboBox.DropDownWidth = 120;
            this.playerSkillComboBox.FormattingEnabled = true;
            this.playerSkillComboBox.IntegralHeight = false;
            this.playerSkillComboBox.Location = new System.Drawing.Point(10, 170);
            this.playerSkillComboBox.Name = "playerSkillComboBox";
            this.playerSkillComboBox.Size = new System.Drawing.Size(121, 21);
            this.playerSkillComboBox.TabIndex = 20;
            this.playerSkillComboBox.SelectedIndexChanged += new System.EventHandler(this.playerSkillComboBox_SelectedIndexChanged);
            // 
            // playerExtraPoint
            // 
            this.playerExtraPoint.Location = new System.Drawing.Point(205, 170);
            this.playerExtraPoint.Name = "playerExtraPoint";
            this.playerExtraPoint.Size = new System.Drawing.Size(100, 20);
            this.playerExtraPoint.TabIndex = 30;
            this.playerExtraPoint.TextChanged += new System.EventHandler(this.extraPoint_TextChanged);
            // 
            // vsLabel
            // 
            this.vsLabel.AutoSize = true;
            this.vsLabel.Location = new System.Drawing.Point(387, 163);
            this.vsLabel.Name = "vsLabel";
            this.vsLabel.Size = new System.Drawing.Size(13, 13);
            this.vsLabel.TabIndex = 4;
            this.vsLabel.Tag = "";
            this.vsLabel.Text = "v";
            // 
            // diceType
            // 
            this.diceType.FormattingEnabled = true;
            this.diceType.Location = new System.Drawing.Point(480, 100);
            this.diceType.Name = "diceType";
            this.diceType.Size = new System.Drawing.Size(71, 21);
            this.diceType.TabIndex = 40;
            // 
            // opponentPoint
            // 
            this.opponentPoint.Location = new System.Drawing.Point(430, 162);
            this.opponentPoint.Name = "opponentPoint";
            this.opponentPoint.Size = new System.Drawing.Size(110, 20);
            this.opponentPoint.TabIndex = 45;
            this.opponentPoint.TextChanged += new System.EventHandler(this.opponentPoint_TextChanged);
            // 
            // eventDescription
            // 
            this.eventDescription.Location = new System.Drawing.Point(10, 30);
            this.eventDescription.Multiline = true;
            this.eventDescription.Name = "eventDescription";
            this.eventDescription.Size = new System.Drawing.Size(399, 48);
            this.eventDescription.TabIndex = 10;
            // 
            // historyLabel
            // 
            this.historyLabel.AutoSize = true;
            this.historyLabel.Location = new System.Drawing.Point(10, 205);
            this.historyLabel.Name = "historyLabel";
            this.historyLabel.Size = new System.Drawing.Size(10, 13);
            this.historyLabel.TabIndex = 8;
            this.historyLabel.Text = "t";
            // 
            // storyBox
            // 
            this.storyBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.storyBox.Location = new System.Drawing.Point(10, 225);
            this.storyBox.Multiline = true;
            this.storyBox.Name = "storyBox";
            this.storyBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.storyBox.Size = new System.Drawing.Size(670, 222);
            this.storyBox.TabIndex = 600;
            this.storyBox.TabStop = false;
            // 
            // actualEvent
            // 
            this.actualEvent.AutoSize = true;
            this.actualEvent.Location = new System.Drawing.Point(10, 10);
            this.actualEvent.Name = "actualEvent";
            this.actualEvent.Size = new System.Drawing.Size(19, 13);
            this.actualEvent.TabIndex = 10;
            this.actualEvent.Text = "ae";
            // 
            // rolePlayGameName
            // 
            this.rolePlayGameName.Location = new System.Drawing.Point(10, 469);
            this.rolePlayGameName.Name = "rolePlayGameName";
            this.rolePlayGameName.Size = new System.Drawing.Size(100, 20);
            this.rolePlayGameName.TabIndex = 600;
            this.rolePlayGameName.TabStop = false;
            // 
            // newGameName
            // 
            this.newGameName.Location = new System.Drawing.Point(410, 469);
            this.newGameName.Name = "newGameName";
            this.newGameName.Size = new System.Drawing.Size(100, 20);
            this.newGameName.TabIndex = 600;
            this.newGameName.TabStop = false;
            // 
            // basePontLabel
            // 
            this.basePontLabel.AutoSize = true;
            this.basePontLabel.Location = new System.Drawing.Point(140, 133);
            this.basePontLabel.Name = "basePontLabel";
            this.basePontLabel.Size = new System.Drawing.Size(19, 13);
            this.basePontLabel.TabIndex = 15;
            this.basePontLabel.Text = "ap";
            // 
            // extraPointLabel
            // 
            this.extraPointLabel.AutoSize = true;
            this.extraPointLabel.Location = new System.Drawing.Point(140, 173);
            this.extraPointLabel.Name = "extraPointLabel";
            this.extraPointLabel.Size = new System.Drawing.Size(19, 13);
            this.extraPointLabel.TabIndex = 16;
            this.extraPointLabel.Text = "ep";
            // 
            // opponentPointLabel
            // 
            this.opponentPointLabel.AutoSize = true;
            this.opponentPointLabel.Location = new System.Drawing.Point(430, 141);
            this.opponentPointLabel.Name = "opponentPointLabel";
            this.opponentPointLabel.Size = new System.Drawing.Size(19, 13);
            this.opponentPointLabel.TabIndex = 17;
            this.opponentPointLabel.Text = "ep";
            // 
            // sumPointLabel
            // 
            this.sumPointLabel.AutoSize = true;
            this.sumPointLabel.Location = new System.Drawing.Point(330, 141);
            this.sumPointLabel.Name = "sumPointLabel";
            this.sumPointLabel.Size = new System.Drawing.Size(18, 13);
            this.sumPointLabel.TabIndex = 18;
            this.sumPointLabel.Text = "sp";
            // 
            // sumPlayerPoint
            // 
            this.sumPlayerPoint.AutoSize = true;
            this.sumPlayerPoint.Location = new System.Drawing.Point(340, 163);
            this.sumPlayerPoint.Name = "sumPlayerPoint";
            this.sumPlayerPoint.Size = new System.Drawing.Size(13, 13);
            this.sumPlayerPoint.TabIndex = 19;
            this.sumPlayerPoint.Text = "0";
            // 
            // numberOfDice
            // 
            this.numberOfDice.Location = new System.Drawing.Point(420, 100);
            this.numberOfDice.Name = "numberOfDice";
            this.numberOfDice.Size = new System.Drawing.Size(49, 20);
            this.numberOfDice.TabIndex = 35;
            this.numberOfDice.TextChanged += new System.EventHandler(this.numberOfDice_TextChanged);
            // 
            // diceLabel
            // 
            this.diceLabel.AutoSize = true;
            this.diceLabel.Location = new System.Drawing.Point(284, 100);
            this.diceLabel.Name = "diceLabel";
            this.diceLabel.Size = new System.Drawing.Size(29, 13);
            this.diceLabel.TabIndex = 22;
            this.diceLabel.Text = "kszt:";
            // 
            // opponenetThrowDiceToo
            // 
            this.opponenetThrowDiceToo.AutoSize = true;
            this.opponenetThrowDiceToo.Location = new System.Drawing.Point(430, 193);
            this.opponenetThrowDiceToo.Name = "opponenetThrowDiceToo";
            this.opponenetThrowDiceToo.Size = new System.Drawing.Size(38, 17);
            this.opponenetThrowDiceToo.TabIndex = 50;
            this.opponenetThrowDiceToo.Text = "ed";
            this.opponenetThrowDiceToo.UseVisualStyleBackColor = true;
            // 
            // languageRadioButtonHu
            // 
            this.languageRadioButtonHu.AutoSize = true;
            this.languageRadioButtonHu.Checked = true;
            this.languageRadioButtonHu.Location = new System.Drawing.Point(6, 19);
            this.languageRadioButtonHu.Name = "languageRadioButtonHu";
            this.languageRadioButtonHu.Size = new System.Drawing.Size(37, 17);
            this.languageRadioButtonHu.TabIndex = 600;
            this.languageRadioButtonHu.TabStop = true;
            this.languageRadioButtonHu.Text = "hu";
            this.languageRadioButtonHu.UseVisualStyleBackColor = true;
            this.languageRadioButtonHu.CheckedChanged += new System.EventHandler(this.languageRadioButtonHu_CheckedChanged);
            // 
            // languageRadioButtonEn
            // 
            this.languageRadioButtonEn.AutoSize = true;
            this.languageRadioButtonEn.Location = new System.Drawing.Point(49, 19);
            this.languageRadioButtonEn.Name = "languageRadioButtonEn";
            this.languageRadioButtonEn.Size = new System.Drawing.Size(37, 17);
            this.languageRadioButtonEn.TabIndex = 600;
            this.languageRadioButtonEn.Text = "en";
            this.languageRadioButtonEn.UseVisualStyleBackColor = true;
            this.languageRadioButtonEn.CheckedChanged += new System.EventHandler(this.languageRadioButtonEn_CheckedChanged);
            // 
            // languageGroupBox
            // 
            this.languageGroupBox.Controls.Add(this.languageRadioButtonHu);
            this.languageGroupBox.Controls.Add(this.languageRadioButtonEn);
            this.languageGroupBox.Location = new System.Drawing.Point(270, 453);
            this.languageGroupBox.Name = "languageGroupBox";
            this.languageGroupBox.Size = new System.Drawing.Size(94, 49);
            this.languageGroupBox.TabIndex = 600;
            this.languageGroupBox.TabStop = false;
            this.languageGroupBox.Text = "ln";
            // 
            // notSavedGameLabel
            // 
            this.notSavedGameLabel.Image = global::RolePlayGUI.Properties.Resources.warning;
            this.notSavedGameLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.notSavedGameLabel.Location = new System.Drawing.Point(170, 10);
            this.notSavedGameLabel.Name = "notSavedGameLabel";
            this.notSavedGameLabel.Size = new System.Drawing.Size(240, 13);
            this.notSavedGameLabel.TabIndex = 601;
            this.notSavedGameLabel.Text = "ns";
            this.notSavedGameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.notSavedGameLabel.Visible = false;
            // 
            // throwDice
            // 
            this.throwDice.Image = ((System.Drawing.Image)(resources.GetObject("throwDice.Image")));
            this.throwDice.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.throwDice.Location = new System.Drawing.Point(565, 99);
            this.throwDice.Name = "throwDice";
            this.throwDice.Size = new System.Drawing.Size(115, 23);
            this.throwDice.TabIndex = 60;
            this.throwDice.Text = "d";
            this.throwDice.UseVisualStyleBackColor = true;
            this.throwDice.Click += new System.EventHandler(this.throwDice_Click);
            // 
            // generateGame
            // 
            this.generateGame.Image = global::RolePlayGUI.Properties.Resources.create;
            this.generateGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.generateGame.Location = new System.Drawing.Point(515, 468);
            this.generateGame.Name = "generateGame";
            this.generateGame.Size = new System.Drawing.Size(165, 23);
            this.generateGame.TabIndex = 600;
            this.generateGame.TabStop = false;
            this.generateGame.Text = "ujl";
            this.generateGame.UseVisualStyleBackColor = true;
            this.generateGame.Click += new System.EventHandler(this.generateGame_Click);
            // 
            // loadGame
            // 
            this.loadGame.Image = global::RolePlayGUI.Properties.Resources.open;
            this.loadGame.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.loadGame.Location = new System.Drawing.Point(120, 468);
            this.loadGame.Name = "loadGame";
            this.loadGame.Size = new System.Drawing.Size(130, 23);
            this.loadGame.TabIndex = 600;
            this.loadGame.TabStop = false;
            this.loadGame.Text = "jb";
            this.loadGame.UseVisualStyleBackColor = true;
            this.loadGame.Click += new System.EventHandler(this.loadGame_Click);
            // 
            // playerPicture
            // 
            this.playerPicture.Location = new System.Drawing.Point(697, 96);
            this.playerPicture.Name = "playerPicture";
            this.playerPicture.Size = new System.Drawing.Size(275, 403);
            this.playerPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.playerPicture.TabIndex = 602;
            this.playerPicture.TabStop = false;
            // 
            // opponentGroupBox
            // 
            this.opponentGroupBox.Controls.Add(this.opponentRadioButton);
            this.opponentGroupBox.Controls.Add(this.ladderRadioButton);
            this.opponentGroupBox.Location = new System.Drawing.Point(550, 140);
            this.opponentGroupBox.Name = "opponentGroupBox";
            this.opponentGroupBox.Size = new System.Drawing.Size(130, 74);
            this.opponentGroupBox.TabIndex = 603;
            this.opponentGroupBox.TabStop = false;
            this.opponentGroupBox.Text = "o";
            // 
            // opponentRadioButton
            // 
            this.opponentRadioButton.AutoSize = true;
            this.opponentRadioButton.Location = new System.Drawing.Point(7, 43);
            this.opponentRadioButton.Name = "opponentRadioButton";
            this.opponentRadioButton.Size = new System.Drawing.Size(31, 17);
            this.opponentRadioButton.TabIndex = 1;
            this.opponentRadioButton.TabStop = true;
            this.opponentRadioButton.Text = "o";
            this.opponentRadioButton.UseVisualStyleBackColor = true;
            this.opponentRadioButton.CheckedChanged += new System.EventHandler(this.opponentRadioButton_CheckedChanged);
            // 
            // ladderRadioButton
            // 
            this.ladderRadioButton.AutoSize = true;
            this.ladderRadioButton.Location = new System.Drawing.Point(7, 20);
            this.ladderRadioButton.Name = "ladderRadioButton";
            this.ladderRadioButton.Size = new System.Drawing.Size(27, 17);
            this.ladderRadioButton.TabIndex = 0;
            this.ladderRadioButton.TabStop = true;
            this.ladderRadioButton.Text = "l";
            this.ladderRadioButton.UseVisualStyleBackColor = true;
            this.ladderRadioButton.CheckedChanged += new System.EventHandler(this.ladderRadioButton_CheckedChanged);
            // 
            // ladderComboBox
            // 
            this.ladderComboBox.FormattingEnabled = true;
            this.ladderComboBox.Location = new System.Drawing.Point(430, 160);
            this.ladderComboBox.Name = "ladderComboBox";
            this.ladderComboBox.Size = new System.Drawing.Size(110, 21);
            this.ladderComboBox.TabIndex = 604;
            // 
            // narrationButton
            // 
            this.narrationButton.Location = new System.Drawing.Point(549, 30);
            this.narrationButton.Name = "narrationButton";
            this.narrationButton.Size = new System.Drawing.Size(131, 23);
            this.narrationButton.TabIndex = 605;
            this.narrationButton.Text = "n";
            this.narrationButton.UseVisualStyleBackColor = true;
            this.narrationButton.Click += new System.EventHandler(this.narrationButton_Click);
            // 
            // RolePlayBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 511);
            this.Controls.Add(this.narrationButton);
            this.Controls.Add(this.ladderComboBox);
            this.Controls.Add(this.opponentGroupBox);
            this.Controls.Add(this.playerPicture);
            this.Controls.Add(this.notSavedGameLabel);
            this.Controls.Add(this.languageGroupBox);
            this.Controls.Add(this.opponenetThrowDiceToo);
            this.Controls.Add(this.diceLabel);
            this.Controls.Add(this.numberOfDice);
            this.Controls.Add(this.throwDice);
            this.Controls.Add(this.sumPlayerPoint);
            this.Controls.Add(this.sumPointLabel);
            this.Controls.Add(this.opponentPointLabel);
            this.Controls.Add(this.extraPointLabel);
            this.Controls.Add(this.basePontLabel);
            this.Controls.Add(this.generateGame);
            this.Controls.Add(this.newGameName);
            this.Controls.Add(this.loadGame);
            this.Controls.Add(this.rolePlayGameName);
            this.Controls.Add(this.actualEvent);
            this.Controls.Add(this.storyBox);
            this.Controls.Add(this.historyLabel);
            this.Controls.Add(this.eventDescription);
            this.Controls.Add(this.opponentPoint);
            this.Controls.Add(this.diceType);
            this.Controls.Add(this.vsLabel);
            this.Controls.Add(this.playerExtraPoint);
            this.Controls.Add(this.playerSkillComboBox);
            this.Controls.Add(this.playerBasedPoint);
            this.Controls.Add(this.playersComboBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RolePlayBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Szerepjáték Story Tábla";
            this.Load += new System.EventHandler(this.RolePlay_Load);
            this.languageGroupBox.ResumeLayout(false);
            this.languageGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.playerPicture)).EndInit();
            this.opponentGroupBox.ResumeLayout(false);
            this.opponentGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox playersComboBox;
        private System.Windows.Forms.TextBox playerBasedPoint;
        private System.Windows.Forms.ComboBox playerSkillComboBox;
        private System.Windows.Forms.TextBox playerExtraPoint;
        private System.Windows.Forms.Label vsLabel;
        private System.Windows.Forms.ComboBox diceType;
        private System.Windows.Forms.TextBox opponentPoint;
        private System.Windows.Forms.TextBox eventDescription;
        private System.Windows.Forms.Label historyLabel;
        private System.Windows.Forms.TextBox storyBox;
        private System.Windows.Forms.Label actualEvent;
        private System.Windows.Forms.TextBox rolePlayGameName;
        private System.Windows.Forms.Button loadGame;
        private System.Windows.Forms.Button generateGame;
        private System.Windows.Forms.TextBox newGameName;
        private System.Windows.Forms.Label basePontLabel;
        private System.Windows.Forms.Label extraPointLabel;
        private System.Windows.Forms.Label opponentPointLabel;
        private System.Windows.Forms.Label sumPointLabel;
        private System.Windows.Forms.Label sumPlayerPoint;
        private System.Windows.Forms.Button throwDice;
        private System.Windows.Forms.TextBox numberOfDice;
        private System.Windows.Forms.Label diceLabel;
        private System.Windows.Forms.CheckBox opponenetThrowDiceToo;
        private System.Windows.Forms.RadioButton languageRadioButtonHu;
        private System.Windows.Forms.RadioButton languageRadioButtonEn;
        private System.Windows.Forms.GroupBox languageGroupBox;
        private System.Windows.Forms.Label notSavedGameLabel;
        private System.Windows.Forms.PictureBox playerPicture;
        private System.Windows.Forms.GroupBox opponentGroupBox;
        private System.Windows.Forms.RadioButton opponentRadioButton;
        private System.Windows.Forms.RadioButton ladderRadioButton;
        private System.Windows.Forms.ComboBox ladderComboBox;
        private System.Windows.Forms.Button narrationButton;
    }
}

