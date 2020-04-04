using RolePlaySet;
using RolePlayFileBasedStorage;
using RolePlayGUI;
using System;
using System.Windows.Forms;

namespace ERolePlay
{
    static class RolePlayMain
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StoreGateway storeGateway = new RolePlayFileStorage();
            RolePlayGamers rolePlayGamers = new SimpleGamer(storeGateway);
            Application.Run(new RolePlayBoard(rolePlayGamers));
        }
    }
}
