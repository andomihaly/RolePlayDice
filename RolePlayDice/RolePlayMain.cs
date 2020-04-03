using RolePlayFileBasedStorage;
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
            StoreGateway storeGateway = new RolePlayFileStore();
            RolePlayGamers rolePlayGamers = new SimpleGamer(storeGateway);
            Application.Run(new RolePlay(rolePlayGamers));
        }
    }
}
