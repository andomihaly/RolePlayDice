using RolePlayEntity;
using RolePlaySet.Gateway.Persistence;

namespace RolePlaySetTests
{
    class StubStoreGateway : PersistenceGateway
    {
        public void createNewGame(string gameName)
        {
            if (gameName.Equals("createingNewGameIssue"))
            {
                throw new CouldNotCreateNewGameException(gameName);
            }
        }

        public string loadDefaultImage(string gameName)
        {
            if (gameName.Equals("fake_game"))
            {
                throw new GameIsNotFoundException(gameName);
            }
            return "";
        }

        public Player[] loadPlayers(string gameName)
        {
            if (gameName.Equals("ValidGame"))
            {
                Player aPlayer = new Player();
                aPlayer.name = "A Player";
                Skill skill = new Skill();
                skill.name = "b";
                skill.score = 0;
                aPlayer.skills.Add(skill);
                Player[] players = { aPlayer, aPlayer };
                return players;
            }
            return new Player[] { };
        }

        public Story loadStory(string gameName)
        {
            if (gameName.Equals("ValidGame"))
            {
                Story story = new Story();
                story.events.Add("1");
                story.events.Add("2");
                story.events.Add("3");
                return story;
            }
            return null;
        }

        public void saveGame(Story story, string gameName)
        {
            
        }
    }
}
