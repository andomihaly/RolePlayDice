using RandomDice;
using RolePlayEntity;
using System;
using System.Collections.Generic;

namespace RolePlaySet.Core
{
    public class RolePlayGameCoordinator : RolePlayGame
    {
        private static string SEPARATOR = "|";
        private StoreGateway storeGateway;
        private TurnEventHandler turnHandle;
        private Dice[] dices;

        private Story story = new Story();
        private Player[] players = new Player[] { };
        private string gameName;
        private string defaultImage = "";

        private RolePlayPresenter rolePlayPresenter;

        public RolePlayGameCoordinator(StoreGateway storeGateway, Dice[] dices, RolePlayPresenter rolePlayPresenter)
        {
            this.storeGateway = storeGateway;
            this.dices = dices;
            turnHandle = new TurnEventHandler(dices, new NewTurnHuTextBuilder(), rolePlayPresenter);
            this.rolePlayPresenter = rolePlayPresenter;
        }

        public void generateNewGame(string gameName)
        {
            checkGameName(gameName);
            this.gameName = reformatGameName(gameName);

            storeGateway.createNewGame(gameName);
        }

        public string[] getAvailableDiceName()
        {
            List<string> diceName = new List<string>();
            foreach (Dice dice in dices)
            {
                diceName.Add(dice.getName());
            }
            return diceName.ToArray();
        }

        public string[,] getTaskTypeList()
        {
            string[,] taskTypeBoundery = new string[EventTaskGenerator.generateEventTasksList().Count, 2];
            int i = 0;
            foreach (TaskType tt in EventTaskGenerator.generateEventTasksList())
            {
                taskTypeBoundery[i, 0] = tt.name;
                taskTypeBoundery[i, 1] = tt.point.ToString();
                i++;
            }
            return taskTypeBoundery;
        }


        public void loadGame(string gameName)
        {
            players = new Player[] { };
            checkGameName(gameName);
            this.gameName = reformatGameName(gameName);
            defaultImage = storeGateway.loadDefaultImage(gameName);
            loadPlayers(gameName);
            sendGameContextToPresenter();
            loadStory(gameName);
        }
        
        public void addNarration(string narration)
        {
            story.events.Add(narration);
            sendStoryToPresenter();
            storeGateway.saveGame(story, gameName);
        }

        public void addTurnTaskEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, string taskName)
        {
            TaskType taskType = findTaskTypeByName(taskName);
            if (taskType == null)
            {
                throw new InvalidTaskTypeException(taskName);
            }
            story.events.Add(turnHandle.generateTurnTaskEvent(actualEventDescription, playerName, basePoint, extraPoint, numberOfDice, diceType, taskType));
            sendStoryToPresenter();
            storeGateway.saveGame(story, gameName);
        }

        private TaskType findTaskTypeByName(string taskName)
        {
            foreach (TaskType tt in EventTaskGenerator.generateEventTasksList())
            {
                if (tt.name.Equals(taskName))
                {
                    return tt;
                }
            }
            return null;
        }

        public void addTurnOpponentEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentThrowToo)
        {
            story.events.Add(turnHandle.generateTurnOpponentEvent(actualEventDescription, playerName, basePoint, extraPoint, numberOfDice, diceType, opponentPoint, isOpponentThrowToo));
            sendStoryToPresenter();
            storeGateway.saveGame(story, gameName);
        }

        private void checkGameName(string gameName)
        {
            if (gameName == null)
            {
                throw new GameNameIsNotValid(gameName);
            }
            gameName = gameName.Trim();
            if (gameName.Equals(""))
            {
                throw new GameNameIsNotValid(gameName);
            }
        }

        private string reformatGameName(String gameName)
        {
            foreach (char c in System.IO.Path.GetInvalidFileNameChars())
            {
                gameName = gameName.Replace(c, '_');
            }
            return gameName;
        }

        private void loadPlayers(string gameName)
        {
            try
            {
                players = storeGateway.loadPlayers(gameName);
            }
            catch (Exception)
            {
                players = new Player[] { };
            }
        }

        private void loadStory(string gameName)
        {
            Story teamStory = storeGateway.loadStory(gameName);
            if (teamStory != null)
            {
                story = teamStory;
            }
            sendStoryToPresenter();
        }

        private void sendStoryToPresenter()
        {
            if (rolePlayPresenter != null)
            {
                rolePlayPresenter.changeStory(story.events.ToArray());
            }
        }

        private void sendGameContextToPresenter()
        {
            if (rolePlayPresenter != null)
            {
                List<string> gameContext = new List<string>();
                gameContext.Add(gameName);
                gameContext.Add(defaultImage);
                foreach (Player player in players)
                {
                    gameContext.Add(generateTextFromPlayer(player));
                }
                rolePlayPresenter.loadedGameContext(gameContext.ToArray());
            }
        }

        private string generateTextFromPlayer(Player player)
        {
            string textPlayer = "";
            textPlayer += player.name + SEPARATOR;
            textPlayer += player.image + SEPARATOR;
            foreach (Skill skill in player.skills)
            {
                textPlayer += skill.name + SEPARATOR + skill.score + SEPARATOR;
            }
            return textPlayer;

        }
    }
}
