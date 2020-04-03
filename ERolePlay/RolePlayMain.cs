using RolePlaySet;
using RolePlayFileBasedStorage;
using System;
using System.Windows.Forms;

namespace ERolePlay
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
            StoreGateway storeGateway = new RolePlayFileStorage();
            RolePlayGamers rolePlayGamers = new SimpleGamer(storeGateway);
            Application.Run(new RolePlay(rolePlayGamers));
        }
    }
}
