using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisKata
{
    public class Game
    {
        private int player1Points;
        private int player2Points;
        private const int twoPointsClear = 2;
        private const int threePointsDeuce = 3;
        private const int fourPointsWinsGame = 4;

        public void Player1WinsPoint()
        {
            if (IsPlayer2Advantage())
            {
                player2Points--;
            }
            else
            {
                player1Points++;
            }
        }

        public void Player2WinsPoint()
        {
            if (IsPlayer1Advantage())
            {
                player1Points--;
            }
            else
            {
                player2Points++;
            }
        }

        public bool Player1Wins()
        {
            return (player1Points >= fourPointsWinsGame) && (player1Points - player2Points >= twoPointsClear);
        }

        public bool Player2Wins()
        {
            return (player2Points >= fourPointsWinsGame) && (player2Points - player1Points >= twoPointsClear);
        }

        public string Score()
        {
            if (IsDeuce())
            {
                return "deuce";
            }
            else if (IsPlayer1Advantage())
            {
                return "advantage player 1";
            }
            else if (IsPlayer2Advantage())
            {
                return "advantage player 2";
            }
            else
            {
                return string.Format("{0}-{1}", TennisFormatScore(player1Points), TennisFormatScore(player2Points));
            }
        }

        private bool IsPlayer1Advantage()
        {
            return player1Points > threePointsDeuce && player2Points == threePointsDeuce;
        }

        private bool IsPlayer2Advantage()
        {
            return player2Points > threePointsDeuce && player1Points == threePointsDeuce;
        }

        private bool IsDeuce()
        {
            return player1Points == threePointsDeuce && player2Points == threePointsDeuce;
        }

        private string TennisFormatScore(int points)
        {
            switch (points)
            {
                case 1:
                    return "15";
                case 2:
                    return "30";
                case 3:
                    return "40";
                default:
                    return "0";
            }
        }
    }
}
