using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

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
            PlayerOneScoreTime(1);
            AssertScoreShouldBe("FifteenLove");
        }

        [TestMethod]
        public void ThirtyLove()
        {
            PlayerOneScoreTime(2);
            AssertScoreShouldBe("ThirtyLove");
        }

        [TestMethod]
        public void FortyLove()
        {
            PlayerOneScoreTime(3);
            AssertScoreShouldBe("FortyLove");
        }

        [TestMethod]
        public void LoveFifteen()
        {
            tennisGame.PlayerTwoScore();
            AssertScoreShouldBe("LoveFifteen");
        }

        private void PlayerOneScoreTime(int time)
        {
            for (int i = 0; i < time; i++)
            {
                tennisGame.PlayerOneScore();
            }
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

        private Dictionary<int, string> mapping = new Dictionary<int, string>
        {
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        private int playerTwoScore;

        public string Score()
        {
            if (playerOneScore != 0)
            {
                return mapping[playerOneScore] + "Love";
            }
            if (playerTwoScore != 0)
            {
                return "Love" + mapping[playerTwoScore];
            }
            return "LoveAll";
        }

        public void PlayerOneScore()
        {
            this.playerOneScore++;
        }

        public void PlayerTwoScore()
        {
            this.playerTwoScore++;
        }
    }
}