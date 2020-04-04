using Microsoft.VisualStudio.TestTools.UnitTesting;
using RandomDice.RandomGenerator;
using RolePlaySet;
using RolePlaySetTests;

namespace RolePlaySet.Tests
{
    [TestClass()]
    public class SimpleGamerTestsExceptions
    {
        private SimpleGamer sg = new SimpleGamer(new StubStoreGateway(), new VisualStudioRandomGenerator());

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void chechEmptyGameNameTest()
        {
            sg.loadGame("");
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void chechNullGameNameTest()
        {
            sg.loadGame(null);
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void chechOnlySpacesGameNameTest()
        {
            sg.loadGame("   ");
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void generateNewEmptyGameNameTest()
        {
            sg.generateNewGame("");
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void generateNewNullGameNameTest()
        {
            sg.generateNewGame(null);
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void generateNewOnlySpacesGameNameTest()
        {
            sg.generateNewGame("   ");
        }
    }
}