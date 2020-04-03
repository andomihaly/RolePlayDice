using RolePlaySet;
using System;
using System.Windows.Forms;

namespace RolePlayDice
{
    static class RolePlayMain
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            RolePlayGamers rolePlayGamers = new SimpleGamers();
            Application.Run(new RolePlay(rolePlayGamers));
        }
    }
}
