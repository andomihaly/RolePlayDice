using RolePlaySet;
using RolePlaySet.Entity;
using System;
using System.IO;

namespace RolePlayFileBasedStorage
{
    public class RolePlayFileStore : StoreGateway
    {
        private string gameName;
        private string path;

        public void createNewGame(string gameName)
        {
            if (gameName == "")
                throw new GameNameIsNotValid("\"" + gameName + "\" is not valid");

            this.gameName = gameName;
            generateGameStructure();
        }

        public void generateGameStructure()
        {
            try
            {
                path = Directory.GetCurrentDirectory();
                path += "\\" + gameName;
                createGameFolder();
                createPlayerExample();
                createStoryFile();
            }
            catch (Exception)
            {
                throw new CouldNotCreateNewGameFileStructure("\"" + gameName + "\" structure creation is faild.");
            }
        }

        public void createGameFolder()
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
        public void createPlayerExample()
        {
            String playerFile = path + "\\players.txt";
            if (!File.Exists(playerFile))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(playerFile))
                {
                    sw.WriteLine("+Name1");
                    sw.WriteLine("-Skill1Name|+1");
                    sw.WriteLine("-Skill2Name|+3");
                    sw.WriteLine("+Name2");
                    sw.WriteLine("-Skill1Name|+0");
                    sw.WriteLine("-Skill2Name|+2");
                    sw.WriteLine("-Skill3Name|+1");
                }
            }
        }

        public void createStoryFile()
        {
            String storyFile = path + "\\story.txt";
            if (!File.Exists(storyFile))
            {
                File.CreateText(storyFile);
                
            }
        }

        public Player[] loadPlayers(string gameName)
        {
            throw new NotImplementedException();
        }

        public Story loadStory(string gameName)
        {
            throw new NotImplementedException();
        }

        public void saveGame(Story story, string gameName)
        {
            throw new NotImplementedException();
        }
    }
}
