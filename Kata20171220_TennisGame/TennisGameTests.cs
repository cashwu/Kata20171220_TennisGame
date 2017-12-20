using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
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

        [TestMethod]
        public void LoveThirty()
        {
            PlayerTwoScoreTime(2);
            AssertScoreShouldBe("LoveThirty");
        }

        [TestMethod]
        public void FifteenAll()
        {
            PlayerOneScoreTime(1);
            PlayerTwoScoreTime(1);
            AssertScoreShouldBe("FifteenAll");
        }

        [TestMethod]
        public void Deuce()
        {
            PlayerOneScoreTime(3);
            PlayerTwoScoreTime(3);
            AssertScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void DeuceWith4()
        {
            PlayerOneScoreTime(4);
            PlayerTwoScoreTime(4);
            AssertScoreShouldBe("Deuce");
        }

        [TestMethod]
        public void PlayerOneAdv()
        {
            PlayerOneScoreTime(4);
            PlayerTwoScoreTime(3);
            AssertScoreShouldBe("PlayerOneAdv");
        }

        [TestMethod]
        public void PlayerTwoAdv()
        {
            PlayerOneScoreTime(3);
            PlayerTwoScoreTime(4);
            AssertScoreShouldBe("PlayerTwoAdv");
        }

        [TestMethod]
        public void PlayerOneWin()
        {
            PlayerOneScoreTime(5);
            PlayerTwoScoreTime(3);
            AssertScoreShouldBe("PlayerOneWin");
        }

        [TestMethod]
        public void PlayerTwoWin()
        {
            PlayerOneScoreTime(3);
            PlayerTwoScoreTime(5);
            AssertScoreShouldBe("PlayerTwoWin");
        }

        private void PlayerTwoScoreTime(int time)
        {
            for (int i = 0; i < time; i++)
            {
                tennisGame.PlayerTwoScore();
            }
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
            {0, "Love"},
            {1, "Fifteen"},
            {2, "Thirty"},
            {3, "Forty"},
        };

        private int playerTwoScore;

        public string Score()
        {
            if (playerOneScore != playerTwoScore)
            {
                if (playerOneScore > 3 || playerTwoScore > 3)
                {
                    var advPlayer = playerOneScore > playerTwoScore ? "PlayerOne" : "PlayerTwo";
                    if (Math.Abs(playerOneScore - playerTwoScore) == 1)
                    {
                        return advPlayer + "Adv";
                    }
                    return advPlayer + "Win";
                }
                if (playerTwoScore > 3)
                {
                    return "PlayerTwoAdv";
                }
                return mapping[playerOneScore] + mapping[playerTwoScore];
            }
            if (playerOneScore >= 3)
            {
                return "Deuce";
            }
            return mapping[playerOneScore] + "All";
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