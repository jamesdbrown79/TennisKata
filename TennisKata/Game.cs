using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TennisKata
{
    public class Game
    {
        private int player1points;
        private int player2points;

        public void Player1WinsPoint()
        {
            if (IsPlayer2Advantage())
            {
                player2points--;
            }
            else
            {
                player1points++;
            }
        }

        public void Player2WinsPoint()
        {
            if (IsPlayer1Advantage())
            {
                player1points--;
            }
            else
            {
                player2points++;
            }
        }

        public bool Player1Wins()
        {
            return (player1points >= 4) && (player1points - player2points >= 2);
        }

        public bool Player2Wins()
        {
            return (player2points >= 4) && (player2points - player1points >= 2);
        }

        public string Score()
        {
            if (IsDeuce())
            {
                return "deuce";
            }
            else if (IsAdvantage())
            {
                return ("advantage");
            }
            else
            {
                return TennisFormatScore(player1points) + "-" + TennisFormatScore(player2points);
            }
        }

        private bool IsAdvantage()
        {
            return IsPlayer1Advantage() || IsPlayer2Advantage();
        }

        private bool IsPlayer1Advantage()
        {
            return player1points == 4 && player2points == 3;
        }

        private bool IsPlayer2Advantage()
        {
            return player2points == 4 && player1points == 3;
        }

        private bool IsDeuce()
        {
            return player1points == 3 && player2points == 3;
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
