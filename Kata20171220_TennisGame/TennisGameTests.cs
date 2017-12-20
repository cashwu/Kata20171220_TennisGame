using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kata20171220_TennisGame
{
    [TestClass]
    public class TennisGameTests
    {
        private TennisGame tennisGame = new TennisGame();

        [TestMethod]
        public void LoveAll()
        {
            AssertScoreShouldBe("LoveAll");
        }

        [TestMethod]
        public void FifteenLove()
        {
            tennisGame.PlayerOneScore();
            AssertScoreShouldBe("FifteenLove");
        }

        [TestMethod]
        public void ThirtyLove()
        {
            tennisGame.PlayerOneScore();
            tennisGame.PlayerOneScore();
            AssertScoreShouldBe("ThirtyLove");
        }

        private void AssertScoreShouldBe(string expected)
        {
            string score = tennisGame.Score();
            Assert.AreEqual(expected, score);
        }
    }

    public class TennisGame
    {
        private int playerOneScore;

        public string Score()
        {
            if (playerOneScore != 0)
            {
                if (playerOneScore == 2)
                {
                    return "ThirtyLove";
                }
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