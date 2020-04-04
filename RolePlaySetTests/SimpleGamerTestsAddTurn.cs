using Microsoft.VisualStudio.TestTools.UnitTesting;
using RolePlaySetTests;
using System;

namespace RolePlaySet.Tests
{
    [TestClass()]
    public class SimpleGamerTestsAddTurn
    {
        [TestMethod()]
        public void chechValidGameNameTest()
        {
            SimpleGamer sg = new SimpleGamer(new StubStoreGateway());
            sg.loadGame("ValidName");
            Assert.AreEqual(0, sg.getStory().Length);
            sg.AddTurn("", "",0, 0, 0, "d3", 0, false);
            Assert.AreEqual(1, sg.getStory().Length);
            Assert.AreEqual("Játékos döntetlent játszott (0-0)!" + Environment.NewLine.ToString() + "Részletek: Játékos: 0 AP ellenfél: 0 AP", sg.getStory()[0].ToString());
        }

        private void AssertBasedOnCharacter(string expected, string actual)
        {
            for (int i = 0; i < expected.Length; i++)
            {
                Assert.AreEqual(expected[i], actual[i], "index:" + i.ToString() + "-Char act: " + (actual[i] + 1).ToString() + "-Char exp: " + (expected[i] + 1).ToString() + "substring: " + expected.Substring(0, i));
            }


        }
    }
}