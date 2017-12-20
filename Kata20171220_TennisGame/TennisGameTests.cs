using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20171220_TennisGame
{
    [TestClass]
    public class TennisGameTests
    {
        [TestMethod]
        public void LoveAll()
        {
            TennisGame tennisGame = new TennisGame();
            string score = tennisGame.Score();
            Assert.AreEqual("LoveAll", score);
        }
    }

    public class TennisGame
    {
        public string Score()
        {
            return "LoveAll";
        }
    }
}