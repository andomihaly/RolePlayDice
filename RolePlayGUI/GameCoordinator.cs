using RolePlayGUI.ViewModel;
using RolePlaySet;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace RolePlayGUI
{
    public class GameCoordinator
    {
        private RolePlayGame rolePlayGamers;
        RolePlayBoard rolePlayBoard;

        internal string defaultImagePath = "";
        internal List<GamePlayer> gamePlayers = new List<GamePlayer>();
        internal List<string> dicesList = new List<string>();
        internal List<Task> taskList = new List<Task>();


        public GameCoordinator(RolePlayGame rolePlayGamers)
        {
            this.rolePlayGamers = rolePlayGamers;
        }

        public void stratNewPlayRoleBoardGame()
        {
            rolePlayGamers.initRolePlayBoard();

            this.rolePlayBoard = new RolePlayBoard(this);
            Application.Run(rolePlayBoard);
        }



        internal void generateNewGame(string gameName) {
            rolePlayGamers.generateNewGame(gameName);
        }
        internal void loadGame(string gameName) {
            rolePlayGamers.loadGame(gameName);
        }
        internal void addNarration(string narration) {
            rolePlayGamers.addNarration(narration);
        }
        internal void addTurnOpponentEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo) {
            rolePlayGamers.addTurnOpponentEvent(actualEventDescription, playerName, basePoint, extraPoint, numberOfDice, diceType, opponentPoint, isOpponentThrowToo);
        }
        internal void addTurnTaskEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, string taskName) {
            rolePlayGamers.addTurnTaskEvent( actualEventDescription,  playerName,  basePoint,  extraPoint,  numberOfDice, diceType, taskName);
        }



        internal GamePlayer findGamePlayer(String gamePlayerName)
        {
            foreach (GamePlayer gamePlayer in gamePlayers)
            {
                if (gamePlayer.name.Equals(gamePlayerName))
                {
                    return gamePlayer;
                }
            }
            return null;
        }

        internal int getPlayersSkillBasedPoint(string playerName, string skillName)
        {
            int basePoint = RolePlayBoard.ZERO;
            GamePlayer player = findGamePlayer(playerName);
            basePoint = getSkillPoint(player, skillName);
            return basePoint;
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
            return RolePlayBoard.ZERO;
        }

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
            rolePlayBoard.VisualizeLastDiceRolls(rolledDices);
        }

        public void refillStoryBox(String[] story)
        {
            rolePlayBoard.refillStoryBox(story);
        }
    }
}
