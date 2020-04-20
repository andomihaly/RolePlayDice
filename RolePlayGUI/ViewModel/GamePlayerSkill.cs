
namespace RolePlayGUI.ViewModel
{
    public class GamePlayerSkill
    {
        public string gamePlayerName;
        public string gamePlayerSkillName;
        public int gamePlayerSkillPoint;

        public GamePlayerSkill(string gamePlayerName, string gamePlayerSkillName, int gamePlayerSkillPoint)
        {
            this.gamePlayerName = gamePlayerName;
            this.gamePlayerSkillName = gamePlayerSkillName;
            this.gamePlayerSkillPoint = gamePlayerSkillPoint;
        }
    }
}
