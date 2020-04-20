using System.Collections.Generic;

namespace RolePlayGUI.ViewModel
{
    public class GamePlayer
    {
        public string name;
        public List<GamePlayerSkill> gamePlayerSkills = new List<GamePlayerSkill>();
        public string imagePath = "";
    }
}
