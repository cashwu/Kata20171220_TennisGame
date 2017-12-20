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
            if (IsDiffScore())
            {
                if (IsReadyToWin())
                {
                    return AdvPlayer() + (IsAdv() ? "Adv" : "Win");
                }
                return NormalScore();
            }
            return IsDeuce() ? Deuce() : SameScore();
        }

        private bool IsReadyToWin()
        {
            return playerOneScore > 3 || playerTwoScore > 3;
        }

        private bool IsAdv()
        {
            return Math.Abs(playerOneScore - playerTwoScore) == 1;
        }

        private string NormalScore()
        {
            return mapping[playerOneScore] + mapping[playerTwoScore];
        }

        private string SameScore()
        {
            return mapping[playerOneScore] + "All";
        }

        private static string Deuce()
        {
            return "Deuce";
        }

        private bool IsDeuce()
        {
            return playerOneScore >= 3;
        }

        private bool IsDiffScore()
        {
            return playerOneScore != playerTwoScore;
        }

        private string AdvPlayer()
        {
            var advPlayer = playerOneScore > playerTwoScore ? "PlayerOne" : "PlayerTwo";
            return advPlayer;
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