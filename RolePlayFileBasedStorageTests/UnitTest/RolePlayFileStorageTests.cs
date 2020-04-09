using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using RolePlayEntity;
using RolePlayFileBasedStorage;

namespace RolePlayFileBasedStorageTests.UnitTest
{
    [TestClass()]
    public class RolePlayFileStorageTests
    {
        RolePlayFileStorage rolePlayFileStorage;

        [TestMethod()]
        public void createNewGameTest()
        {
            string gamePath = setUpGameExample("unitTest");

            Assert.IsTrue(Directory.Exists(gamePath), "Directory file is not there!");

            Assert.IsTrue(File.Exists(gamePath + "\\players.txt"), "Player file is not there!");
            Assert.IsTrue(File.Exists(gamePath + "\\actorW275xH400px.jpg"), "Actor image is not there!");
            Assert.IsTrue(File.Exists(gamePath + "\\story.txt"), "Story file is not there!");
            Assert.IsTrue(File.Exists(gamePath + "\\default.png"),"Default image is not there!");
            string playerFileExample = @"+Name1
-Skill1Name|+1
-Skill2Name|+3
+Name2
-Skill1Name|+2
-Skill2Name|+3
-Skill3Name|0
-Skill4Name|-1
*actorW275xH400px.jpg
+Name3
*image.png
+Name4
";

            string playerFileLines = System.IO.File.ReadAllText(gamePath + "\\players.txt");
            Assert.AreEqual(playerFileExample, playerFileLines);            
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void loadPlayersWithEmptyGameNameTest()
        {
            RolePlayFileStorage fs = new RolePlayFileStorage();
            fs.loadPlayers("");
        }
        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void loadPlayersWithNullGameNameTest()
        {
            RolePlayFileStorage fs = new RolePlayFileStorage();
            fs.loadPlayers(null);
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void loadPlayersWithFakeGameNameTest()
        {
            RolePlayFileStorage fs = new RolePlayFileStorage();
            fs.loadPlayers("fake");
        }


        [TestMethod()]
        public void loadPlayersWithValidGameNameTest()
        {
            string gamePath = setUpGameExample("unitTest");

            Player[] players = rolePlayFileStorage.loadPlayers("unitTest");

            Assert.AreEqual("Name1", players[0].name);
            Assert.AreEqual("Skill1Name", players[0].skills[0].name);
            Assert.AreEqual(1, players[0].skills[0].score);
            Assert.AreEqual("", players[0].image);

            Assert.AreEqual("Name2", players[1].name);
            Assert.AreEqual("Skill4Name", players[1].skills[3].name);
            Assert.AreEqual(-1, players[1].skills[3].score);
            Assert.AreEqual(gamePath + "\\actorW275xH400px.jpg", players[1].image);


            Assert.AreEqual("", players[2].image);

            Assert.AreEqual("Name4", players[3].name);
            Assert.AreEqual(0, players[3].skills.Count);
        }

        [TestMethod()]
        public void loadDefaultImageTest()
        {
            string gamePath = setUpGameExample("unitTest");
            Assert.AreEqual(gamePath+"\\default.png", rolePlayFileStorage.loadDefaultImage("unitTest"));
        }

        [TestMethod()]
        public void saveGameTest()
        {
            string gamePath = setUpGameExample("unitTest");
            Story myStory = new Story();
            string eventExample = @"first Event
with more than
one line";

            myStory.events.Add(eventExample);
            rolePlayFileStorage.saveGame(myStory, "unitTest");

            string storyFileLines = System.IO.File.ReadAllText(gamePath + "\\story.txt");
            Assert.AreEqual("###" + eventExample, storyFileLines.Trim());
        }

        public void saveGameWithTwoEventTest()
        {
            string gamePath = setUpGameExample("unitTest");
            Story myStory = new Story();
            string eventExample = @"first Event
with more than
one line";

            myStory.events.Add(eventExample);
            myStory.events.Add(eventExample);
            rolePlayFileStorage.saveGame(myStory, "unitTest");

            string storyFileLines = System.IO.File.ReadAllText(gamePath + "\\story.txt");
            string expectedFileContent = "###" + eventExample + System.Environment.NewLine + "###" + eventExample;
            Assert.AreEqual(expectedFileContent, storyFileLines.Trim());
        }

        [TestMethod()]
        public void loadEmptyStoryTest()
        {
            string gamePath = setUpGameExample("unitTest");
            Assert.AreEqual(0, rolePlayFileStorage.loadStory("unitTest").events.Count);
        }

        [TestMethod()]
        public void loadOneStoryTest()
        {
            string gamePath = setUpGameExample("unitTest");
            Story myStory = new Story();
            myStory.events.Add("test");
            rolePlayFileStorage.saveGame(myStory, "unitTest");
            Assert.AreEqual(1, rolePlayFileStorage.loadStory("unitTest").events.Count);
        }

        [TestMethod()]
        public void loadMultipleLinesStoryTest()
        {
            string gamePath = setUpGameExample("unitTest");
            Story myStory = new Story();
            myStory.events.Add(@"first Event
with more than
one line");
            myStory.events.Add(@"next Event
with more than two
line");
            rolePlayFileStorage.saveGame(myStory, "unitTest");
            Assert.AreEqual(2, rolePlayFileStorage.loadStory("unitTest").events.Count);
        }

        public string setUpGameExample(string gameName)
        {
            string path = Directory.GetCurrentDirectory() + "\\" + gameName;
            DirectoryInfo directory = new DirectoryInfo(path);
            if (directory.Exists)
                directory.Delete(true);
            rolePlayFileStorage = new RolePlayFileStorage();

            rolePlayFileStorage.createNewGame(gameName);

            return path;
        }
    }
}
