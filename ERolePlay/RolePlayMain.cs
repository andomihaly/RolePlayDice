using RolePlaySet;
using RolePlayFileBasedStorage;
using RolePlayGUI;
using System;
using System.Windows.Forms;
using RandomDice.RandomGenerator;
using RandomDice;

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
            IntervalRandomGenerator intervalRandomGenerator = new VisualStudioRandomGenerator();
            RolePlayGamers rolePlayGamers = new SimpleGamer(storeGateway, intervalRandomGenerator);
            Application.Run(new RolePlayBoard(rolePlayGamers));
        }
    }
}
