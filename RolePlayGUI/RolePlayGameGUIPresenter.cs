using System;
using RolePlaySet;
using RolePlayGUI.ViewModel;
using System.Collections.Generic;

namespace RolePlayGUI
{
    public class RolePlayGameGUIPresenter : RolePlayPresenter
    {
        private GameCoordinator gameCoordinator;

        public void connectToBoard(GameCoordinator gameCoordinator)
        {
            this.gameCoordinator = gameCoordinator;
        }

        public void initRolePlayContext(string[] initContext)
        {
            gameCoordinator.storeRolePlayInitContext(convertTextToDiceList(initContext[0]), convertTextToTaskList(initContext[1]));
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

        public void loadedGameContext(string[] gameContext)
        {
            List<GamePlayer> gamePlayers = new List<GamePlayer>();
            for (int i = 2; i < gameContext.Length; i++)
            {
                gamePlayers.Add(convertTextToGamePlayer(gameContext[i]));
            }
            gameCoordinator.storeGameContext(gameContext[1], gamePlayers);
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

        public void rolledDicesInTurn(string[] rolledDice)
        {
            RolledDiceInTurn diceInTurn = new RolledDiceInTurn();
            diceInTurn.player = convertTextToRolledDiceList(rolledDice[0]);
            if (rolledDice.Length > 1)
            {
                diceInTurn.opponent = convertTextToRolledDiceList(rolledDice[1]);
            }
            gameCoordinator.VisualizeLastDiceRolls(diceInTurn);
        }

        private List<Dice> convertTextToRolledDiceList(string rolledDicesText)
        {
            string[] splittedDices = rolledDicesText.Remove(rolledDicesText.Length - 1, 1).Split('|');
            List<Dice> dicesList = new List<Dice>();
            int index = 0;
            while (index < splittedDices.Length)
            {
                dicesList.Add(new Dice(splittedDices[index], splittedDices[index + 1]));
                index += 2;
            }
            return dicesList;
        }

        public void changeStory(string[] story)
        {
            gameCoordinator.refillStoryBox(story);
        }

        public void displayError(string errorMessage)
        {
            string[] splittedError = errorMessage.Split('|');
            string errorCode = splittedError[0];
            if (errorCode.Equals("InvalidTaskType"))
            {
                gameCoordinator.generateErrorMessage("Invalid Task Type sent!");
            }
            else if (errorCode.Equals("GameNameIsNotValid"))
            {
                gameCoordinator.generateErrorMessageWithLanguageText("errorGameNameNotValid");
            }
            else if (errorCode.Equals("GameIsNotFound"))
            {
                gameCoordinator.generateErrorMessageWithLanguageText("errorGameIsNotFound", splittedError[1]);
            }
            else if (errorCode.Equals("CouldNotCreateNewGame"))
            {
                gameCoordinator.generateErrorMessage("Could not create " + splittedError[1] + " game");
            }
            else if (errorCode.Equals("NotSupportedDiceType"))
            {
                gameCoordinator.generateErrorMessage("The following dice is not supported:" + splittedError[1] + "!");
            }
            else if (errorCode.Equals("NotCategorisedError"))
            {
                gameCoordinator.generateErrorMessage("Unexpeted error happend!");
            }
            else
            {
                gameCoordinator.generateErrorMessage("Following exception happend:" + errorCode);
            }
        }
    }
}
