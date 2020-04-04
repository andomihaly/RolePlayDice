using Microsoft.VisualStudio.TestTools.UnitTesting;
using RolePlaySet;
using RolePlaySetTests;

namespace RolePlaySet.Tests
{
    [TestClass()]
    public class SimpleGamerTestsExceptions
    {
        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void chechEmptyGameNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("");
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void chechNullGameNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame(null);
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void chechOnlySpacesGameNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("   ");
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void generateNewEmptyGameNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.generateNewGame("");
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void generateNewNullGameNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.generateNewGame(null);
        }

        [ExpectedException(typeof(GameNameIsNotValid))]
        [TestMethod()]
        public void generateNewOnlySpacesGameNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.generateNewGame("   ");
        }
    }
}