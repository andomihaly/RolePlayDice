using RolePlaySet;
using RolePlaySet.Core;
using RolePlayFileBasedStorage;
using RolePlayGUI;
using RandomDice.Dices;
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
            Dice[] dices = { new DiceFudge(intervalRandomGenerator), new Dice3(intervalRandomGenerator), new Dice6(intervalRandomGenerator) };


            RolePlayGameGUIPresenter visualizeLastDiceRolls = new RolePlayGameGUIPresenter();

            RolePlayGame rolePlayGame = new RolePlayGameCoordinator(storeGateway, dices, visualizeLastDiceRolls);
            RolePlayBoard rolePlayBoard = new RolePlayBoard(rolePlayGame);
            visualizeLastDiceRolls.connectToBoard(rolePlayBoard);


            Application.Run(rolePlayBoard);
        }
    }
}
