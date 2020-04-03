using RolePlaySet;
using RolePlaySet.Entity;
using System;
using System.Collections.Generic;
using System.IO;

namespace RolePlayFileBasedStorage
{
    public class RolePlayFileStorage : StoreGateway
    {
        private static string PLAYER_FILE_NAME = "players.txt";
        private static string STORY_FILE_NAME = "story.txt";
        private static string PLAYER_NAME_FLAG = "+";
        private static string SKILL_FLAG = "-";
        private static string SKILL_SEPARATOR = "|";

        private string gameName;
        private string path;
        private int rowIndex;
        private List<Player> players;
        string[] playerFileLines;



        public void createNewGame(string gameName)
        {
            checkGameName(gameName);
            this.gameName = gameName;
            generateGameStructure();
        }

        public Player[] loadPlayers(string gameName)
        {
            checkGameName(gameName);
            this.gameName = gameName;
            return loadPlayersFromFile();
        }

        public Story loadStory(string gameName)
        {
            checkGameName(gameName);
            this.gameName = gameName;
            path = generatePath();
            String storyFile = path + "\\" + STORY_FILE_NAME;
            Story story = new Story();
            story.events = System.IO.File.ReadAllLines(storyFile);
            return story;
            
        }

        public void saveGame(Story story, string gameName)
        {
            checkGameName(gameName);
            this.gameName = gameName;
            path = generatePath();
            String storyFile = path + "\\" + STORY_FILE_NAME;
            System.IO.File.WriteAllLines(storyFile, story.events);
        }

        private void checkGameName(string gameName)
        {
            if (gameName == null || gameName == "" || gameName == " ")
                throw new GameNameIsNotValid("\"" + gameName + "\" is not valid");
        }

        private void generateGameStructure()
        {
            try
            {
                path = generatePath();
                createGameFolder();
                createPlayerExample();
                createStoryFile();
            }
            catch (Exception)
            {
                throw new CouldNotCreateNewGameFileStructure("\"" + gameName + "\" structure creation is faild.");
            }
        }

        private string generatePath()
        {
            return Directory.GetCurrentDirectory() + "\\" + gameName;
        }

        private void createGameFolder()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        private void createPlayerExample()
        {
            String playerFile = path + "\\" + PLAYER_FILE_NAME;
            if (!File.Exists(playerFile))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(playerFile))
                {
                    sw.WriteLine(PLAYER_NAME_FLAG + "Name1");
                    sw.WriteLine(SKILL_FLAG + "Skill1Name" + SKILL_SEPARATOR + "+1");
                    sw.WriteLine(SKILL_FLAG + "Skill2Name" + SKILL_SEPARATOR + "+3");
                    sw.WriteLine(PLAYER_NAME_FLAG + "Name2");
                    sw.WriteLine(SKILL_FLAG + "Skill1Name" + SKILL_SEPARATOR + "+2");
                    sw.WriteLine(SKILL_FLAG + "Skill2Name" + SKILL_SEPARATOR + "+3");
                    sw.WriteLine(SKILL_FLAG + "Skill3Name" + SKILL_SEPARATOR + "0");
                    sw.WriteLine(SKILL_FLAG + "Skill4Name" + SKILL_SEPARATOR + "-1");

                }
            }
        }

        private void createStoryFile()
        {
            String storyFile = path + "\\" + STORY_FILE_NAME;
            if (!File.Exists(storyFile))
            {
                File.CreateText(storyFile);

            }
        }

        private Player[] loadPlayersFromFile()
        {
            path = generatePath();
            String playerFile = path + "\\" + PLAYER_FILE_NAME;

            playerFileLines = System.IO.File.ReadAllLines(playerFile);
            players = new List<Player>();
            rowIndex = 0;
            
            while (rowIndex < playerFileLines.Length)
            {
                parseAndAddNextPlayerToList();
                rowIndex++;
            }
            return players.ToArray();
        }

        private void parseAndAddNextPlayerToList()
        {
            string tempLine = playerFileLines[rowIndex];
            if (tempLine[0].Equals(PLAYER_NAME_FLAG[0]))
            {
                Player player = new Player();
                player.name = tempLine.Substring(1);
                while (playerFileLines[rowIndex + 1].Equals(SKILL_FLAG[0]))
                {
                    rowIndex++;
                    parseAndAddNextSkillToPlayer(player);
                }
                players.Add(player);
            }   
        }

        private void parseAndAddNextSkillToPlayer(Player player)
        {
            string tempLine = playerFileLines[rowIndex].Substring(1);
            string[] skillArray = tempLine.Split(SKILL_SEPARATOR[0]);
            if (skillArray.Length == 2)
            {
                Skill skill = new Skill();
                skill.name = skillArray[0];
                if (isConverttableToInt(skillArray[1]))
                {
                    skill.score = Convert.ToInt32(skillArray[1]);
                }
                else
                {
                    skill.score = 0;
                }
                player.skills.Add(skill);
            }
        }

        private bool isConverttableToInt(String number)
        {
            try
            {
                Convert.ToInt32(number);
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }


    }
}
