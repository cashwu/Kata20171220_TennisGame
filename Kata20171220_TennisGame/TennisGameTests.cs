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

        [TestMethod]
        public void FifteenLove()
        {
            TennisGame tennisGame = new TennisGame();
            tennisGame.PlayerOneScore();
            string score = tennisGame.Score();
            Assert.AreEqual("FifteenLove", score);
        }
    }

    public class TennisGame
    {
        private int playerOneScore;

        public string Score()
        {
            if (playerOneScore != 0)
            {
                return "FifteenLove";
            }
            return "LoveAll";
        }

        public void PlayerOneScore()
        {
            this.playerOneScore++;
        }
    }
}