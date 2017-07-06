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
        private const int threePoints = 3;

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
            return (player1Points >= 4) && (player1Points - player2Points >= 2);
        }

        public bool Player2Wins()
        {
            return (player2Points >= 4) && (player2Points - player1Points >= 2);
        }

        public string Score()
        {
            if (IsDeuce())
            {
                return "deuce";
            }
            else if (IsAdvantage())
            {
                return "advantage";
            }
            else
            {
                return string.Format("{0}-{1}", TennisFormatScore(player1Points), TennisFormatScore(player2Points));
            }
        }

        private bool IsAdvantage()
        {
            return IsPlayer1Advantage() || IsPlayer2Advantage();
        }

        private bool IsPlayer1Advantage()
        {
            return player1Points > threePoints && player2Points == threePoints;
        }

        private bool IsPlayer2Advantage()
        {
            return player2Points > threePoints && player1Points == threePoints;
        }

        private bool IsDeuce()
        {
            return player1Points == threePoints && player2Points == threePoints;
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
