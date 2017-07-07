using Microsoft.VisualStudio.TestTools.UnitTesting;
using TennisKata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisKata.Tests
{
    [TestClass()]
    public class GameTests
    {
        private Game game;

        [TestInitialize]
        public void Initialize()
        {
            game = new Game();
        }

        private void Player1WinsConsecutivePoints(int points)
        {
            for (int index = 1; index <= points; index++)
            {
                game.Player1WinsPoint();
            }
        }

        private void Player2WinsConsecutivePoints(int points)
        {
            for (int index = 1; index <= points; index++)
            {
                game.Player2WinsPoint();
            }
        }

        [TestMethod()]
        public void should_return_player1_wins_game()
        {
            //setup

            //act
            Player1WinsConsecutivePoints(4);

            //assert
            Assert.AreEqual(true, game.Player1Wins());
        }

        [TestMethod()]
        public void should_return_player1_wins_game_by_2_clear_points()
        {
            //setup

            //act
            Player1WinsConsecutivePoints(3);
            Player2WinsConsecutivePoints(2);
            game.Player1WinsPoint();

            //assert
            Assert.AreEqual(true, game.Player1Wins());
        }

        [TestMethod()]
        public void should_return_player2_wins_game_by_2_clear_points()
        {
            //setup

            //act
            Player1WinsConsecutivePoints(2);
            Player2WinsConsecutivePoints(4);

            //assert
            Assert.AreEqual(true, game.Player2Wins());
        }

        [TestMethod()]
        public void should_return_game_score_using_tennis_terms()
        {
            //setup

            //act
            Player1WinsConsecutivePoints(2);
            Player2WinsConsecutivePoints(3);

            //assert
            Assert.AreEqual("30-40", game.Score());
        }

        [TestMethod()]
        public void should_return_deuce_when_both_players_score_3_points()
        {
            //setup

            //act
            Player1WinsConsecutivePoints(3);
            Player2WinsConsecutivePoints(3);

            //assert
            Assert.AreEqual("deuce", game.Score());
        }

        [TestMethod()]
        public void should_return_player1_advantage_when_score_is_4_3()
        {
            //setup

            //act
            Player1WinsConsecutivePoints(3);
            Player2WinsConsecutivePoints(3);
            game.Player1WinsPoint();

            //assert
            Assert.AreEqual("advantage player 1", game.Score());
        }

        [TestMethod()]
        public void should_return_player2_advantage_when_score_is_3_4()
        {
            //setup

            //act
            Player1WinsConsecutivePoints(3);
            Player2WinsConsecutivePoints(3);
            game.Player2WinsPoint();
            game.Player1WinsPoint();
            game.Player2WinsPoint();

            //assert
            Assert.AreEqual("advantage player 2", game.Score());
        }

        [TestMethod()]
        public void should_return_deuce_from_advantage_when_3_point_player_wins_point()
        {
            //setup

            //act
            Player1WinsConsecutivePoints(3);
            Player2WinsConsecutivePoints(3);
            game.Player2WinsPoint();
            game.Player1WinsPoint();

            //assert
            Assert.AreEqual("deuce", game.Score());
        }
    }
}