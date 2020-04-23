using RandomDice;
using RolePlayEntity;
using RolePlaySet.Gateway.Persistence;
using System;
using System.Collections.Generic;

namespace RolePlaySet.Core
{
    public class RolePlayGameCoordinator : RolePlayGame
    {
        internal static string SEPARATOR = "|";
        private PersistenceGateway persistenceGateway;
        private TurnEventHandler turnHandle;
        private Dice[] dices;

        private Story story = new Story();
        private Player[] players = new Player[] { };
        private string gameName;
        private string defaultImage = "";

        private RolePlayPresenter rolePlayPresenter;

        public RolePlayGameCoordinator(PersistenceGateway storeGateway, Dice[] dices, RolePlayPresenter rolePlayPresenter)
        {
            this.persistenceGateway = storeGateway;
            this.dices = dices;
            turnHandle = new TurnEventHandler(dices, new NewTurnHuTextBuilder(), rolePlayPresenter);
            this.rolePlayPresenter = rolePlayPresenter;
        }

        public void initRolePlayBoard()
        {
            sendInitContextToPresenter();
        }

        public void generateNewGame(string gameName)
        {
            try
            {
                checkGameName(gameName);
                this.gameName = reformatGameName(gameName);

                persistenceGateway.createNewGame(gameName);
            }
            catch (GameNameIsNotValidException)
            {
                sendErrorCodeToPresenter(ErrorCode.GameNameIsNotValid);
            }
            catch (CouldNotCreateNewGameException cncnge)
            {
                sendErrorCodeToPresenter(ErrorCode.CouldNotCreateNewGame, cncnge.Message.ToString());
            }
            catch (Exception)
            {
                sendErrorCodeToPresenter(ErrorCode.NotCategorisedError);
            }
        }

        public void loadGame(string gameName)
        {
            try
            {
                players = new Player[] { };
                checkGameName(gameName);
                this.gameName = reformatGameName(gameName);
                defaultImage = persistenceGateway.loadDefaultImage(gameName);
                loadPlayers();
                sendGameContextToPresenter();
                loadStory();
            }
            catch (GameNameIsNotValidException)
            {
                sendErrorCodeToPresenter(ErrorCode.GameNameIsNotValid);
            }
            catch (GameIsNotFoundException ginfe)
            {
                sendErrorCodeToPresenter(ErrorCode.GameIsNotFound, ginfe.Message.ToString());
            }
            catch (Exception)
            {
                sendErrorCodeToPresenter(ErrorCode.NotCategorisedError);
            }
        }

        public void addNarration(string narration)
        {
            story.events.Add(narration);
            sendStoryToPresenter();
            persistenceGateway.saveGame(story, gameName);
        }

        public void addTurnTaskEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, string taskName)
        {
            TaskType taskType = findTaskTypeByName(taskName);
            if (taskType == null)
            {
                sendErrorCodeToPresenter(ErrorCode.InvalidTaskType);
            }
            else
            {
                try
                {
                    story.events.Add(turnHandle.generateTurnTaskEvent(actualEventDescription, playerName, basePoint, extraPoint, numberOfDice, diceType, taskType));
                    sendStoryToPresenter();
                    persistenceGateway.saveGame(story, gameName);
                }
                catch (NotSupportedDiceTypeException nsdte)
                {
                    sendErrorCodeToPresenter(ErrorCode.NotSupportedDiceType, nsdte.Message.ToString());
                }
            }
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

        public void addTurnOpponentEvent(string actualEventDescription, string playerName, int basePoint, int extraPoint, int numberOfDice, string diceType, int opponentPoint, bool isOpponentRollToo)
        {
            try
            {
                story.events.Add(turnHandle.generateTurnOpponentEvent(actualEventDescription, playerName, basePoint, extraPoint, numberOfDice, diceType, opponentPoint, isOpponentRollToo));
                sendStoryToPresenter();
                persistenceGateway.saveGame(story, gameName);
            }
            catch (NotSupportedDiceTypeException nsdte)
            {
                sendErrorCodeToPresenter(ErrorCode.NotSupportedDiceType, nsdte.Message.ToString());
            }
        }

    private void checkGameName(string gameName)
        {
            if (gameName == null)
            {
                throw new GameNameIsNotValidException();
            }
            gameName = gameName.Trim();
            if (gameName.Equals(""))
            {
                throw new GameNameIsNotValidException();
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

        private void loadPlayers()
        {
            try
            {
                players = persistenceGateway.loadPlayers(gameName);
            }
            catch (Exception)
            {
                players = new Player[] { };
            }
        }

        private void loadStory()
        {
            Story teamStory = persistenceGateway.loadStory(gameName);
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

        private void sendInitContextToPresenter()
        {
            if (rolePlayPresenter != null)
            {
                List<string> initContext = new List<string>();
                initContext.Add(generateTextFromDices());
                initContext.Add(generateTextFromTasks());
                rolePlayPresenter.initRolePlayContext(initContext.ToArray());
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

        private string generateTextFromTasks()
        {
            string textTask = "";
            foreach (TaskType tt in EventTaskGenerator.generateEventTasksList())
            {
                textTask += tt.name + SEPARATOR + tt.point + SEPARATOR;
            }
            return textTask;
        }

        private string generateTextFromDices()
        {
            string textDices = "";
            foreach (Dice dice in dices)
            {
                textDices += dice.getName() + SEPARATOR;
            }
            return textDices;
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


        private void sendErrorCodeToPresenter(ErrorCode errorCode, string message)
        {
            if (rolePlayPresenter != null)
            {
                string errorMessage = errorCode.ToString();
                errorMessage += message.Equals("") ? "" : SEPARATOR + message;
                rolePlayPresenter.displayError(errorMessage);
            }
        }

        private void sendErrorCodeToPresenter(ErrorCode errorCode)
        {
            sendErrorCodeToPresenter(errorCode, "");
        }
    }
}
