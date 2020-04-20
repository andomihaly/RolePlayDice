using System;
using RolePlaySet;
using RolePlayGUI.ViewModel;
using System.Collections.Generic;

namespace RolePlayGUI
{
    public class RolePlayGameGUIPresenter : RolePlayPresenter
    {
        private RolePlayBoard rolePlayBoard;

        public void changeStory(string[] story)
        {
            rolePlayBoard.refillStoryBox(story);
        }

        public void connectToBoard(RolePlayBoard rolePlayBoard)
        {
            this.rolePlayBoard = rolePlayBoard;
        }

        public void displayError(string[] error)
        {
            throw new NotImplementedException();
        }

        public void loadedGameContext(string[] gameContext)
        {
            List<GamePlayer> gamePlayers = new List<GamePlayer>();
            for (int i = 2; i < gameContext.Length; i++)
            {
                gamePlayers.Add(convertTextToGamePlayer(gameContext[i]));
            }
            rolePlayBoard.storeGameContext(gameContext[1], gamePlayers);
        }

        private GamePlayer convertTextToGamePlayer(string player)
        {
            string[] splittedPlayer = player.Remove(player.Length - 1, 1).Split('|');
            GamePlayer gamePlayer = new GamePlayer();
            gamePlayer.name = splittedPlayer[0];
            gamePlayer.imagePath = splittedPlayer[1];
            int index = 2;
            while (index < splittedPlayer.Length)
            {
                gamePlayer.gamePlayerSkills.Add(new GamePlayerSkill(splittedPlayer[0], splittedPlayer[index], Convert.ToInt32(splittedPlayer[index + 1])));
                index += 2;
            }
            return gamePlayer;
        }

        public void rolledDicesInTurn(string[,] rolledDice)
        {
            if (rolePlayBoard != null)
            {
                rolePlayBoard.VisualizeLastDiceRolls(rolledDice);
            }
        }

        public void initRolePlayContext(string[] initContext)
        {
            rolePlayBoard.storeRolePlayInitContext(convertTextToDiceList(initContext[0]), convertTextToTaskList(initContext[1]));
        }

        private List<string> convertTextToDiceList(string dicesText)
        {
            string[] splittedDices = dicesText.Remove(dicesText.Length - 1, 1).Split('|');
            List<String> dicesList = new List<string>();
            foreach (String dice in splittedDices)
            {
                dicesList.Add(dice);
            }
            return dicesList;
        }

        private List<Task> convertTextToTaskList(string tasksText)
        {
            string[] splittedTasks = tasksText.Remove(tasksText.Length - 1, 1).Split('|');
            List<Task> tasksList = new List<Task>();
            int index = 0;
            while (index < splittedTasks.Length)
            {
                tasksList.Add(new Task(splittedTasks[index]));
                index += 2;
            }
            return tasksList;
        }
    }
}
