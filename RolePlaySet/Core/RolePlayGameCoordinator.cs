using RandomDice;
using RolePlayEntity;
using System;
using System.Collections.Generic;

namespace RolePlaySet.Core
{
    public class RolePlayGameCoordinator : RolePlayGame
    {
        private StoreGateway storeGateway;
        private TurnEventHandler turnHandle;
        private Dice[] dices;

        private Story story = new Story();
        private Player[] players;
        private string gameName;
        private string defaultImage = "";
        private DiceRollNotification diceRollNotification;

        public RolePlayGameCoordinator(StoreGateway storeGateway, Dice[] dices)
        {
            this.storeGateway = storeGateway;
            this.dices = dices;
            turnHandle = new TurnEventHandler(dices, new NewTurnHuTextBuilder());
        }

        public RolePlayGameCoordinator(StoreGateway storeGateway, Dice[] dices, DiceRollNotification diceRollNotification)
        {
            this.storeGateway = storeGateway;
            this.dices = dices;
            turnHandle = new TurnEventHandler(dices, new NewTurnHuTextBuilder(), diceRollNotification);
            this.diceRollNotification = diceRollNotification;
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

        public string [,] getTaskTypeList()
        {
            string [,] taskTypeBoundery = new string[EventTaskGenerator.generateEventTasksList().Count,2];
            int i = 0;
            foreach(TaskType tt in EventTaskGenerator.generateEventTasksList())
            {
                taskTypeBoundery[i,0] = tt.name;
                taskTypeBoundery[i,1] = tt.point.ToString();
                i++;
            }
            return taskTypeBoundery;
        }


        public void loadGame(string gameName)
        {
            checkGameName(gameName);
            this.gameName = reformatGameName(gameName);
            defaultImage = storeGateway.loadDefaultImage(gameName);
            loadPlayers(gameName);
            loadStory(gameName);
        }

        public string [,] getPlayers()
        {
            if (players != null)
            {
                string[,] playersBoundery = new string[players.Length, 2];
                int i = 0;
                foreach (Player player in players)
                {
                    playersBoundery[i, 0] = player.name;
                    playersBoundery[i, 1] = player.image;
                    i++;
                }
                return playersBoundery;
            }
            return new string[0,0];
        }

        public string[] getStory()
        {
            return story.events.ToArray();
        }

        public string getDefaultImage()
        {
            return defaultImage;
        }


        public string [,] getPlayerSkillsByPlayerName(string playerName)
        {
            if (players != null)
            {
                foreach (Player onePlayer in players)
                {
                    if (onePlayer.name.Equals(playerName))
                    {
                        string[,] skillBoundery = new string[onePlayer.skills.Count, 2];
                        int i = 0;
                        foreach(Skill skill in onePlayer.skills)
                        {
                            skillBoundery[i, 0] = skill.name;
                            skillBoundery[i, 1] = skill.score.ToString();
                            i++;
                        }
                        return skillBoundery;
                    }
                }
            }
            return new string[0,0];
        }

        public void addNarration(string narration)
        {
            story.events.Add(narration);
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
            storeGateway.saveGame(story, gameName);
        }

        private TaskType findTaskTypeByName(string taskName)
        {
            foreach(TaskType tt in EventTaskGenerator.generateEventTasksList())
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
                players = null;
            }
        }

        private void loadStory(string gameName)
        {
            Story teamStory = storeGateway.loadStory(gameName);
            if (teamStory != null)
            {
                story = teamStory;
            }
        }
    }
}
