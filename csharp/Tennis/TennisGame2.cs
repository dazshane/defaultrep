namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int m_score1;
        private int m_score2;

        private string score;
        private string p1res = "";
        private string p2res = "";

        public TennisGame2(string player1Name, string player2Name)
        {
            m_score1 = 0;
        }

        public string GetScore()
        {
            initScore();

            if (isTie() && m_score1 < 3)
            {
                setScore1();
                score = p1res + "-All";
            }

            else if (isDeuce())
            {
                setDeuce();
            }

            else
            {
                setScore1();
                setScore2();
                score = p1res + "-" + p2res;
            }

            if (advantagePlayer1())
            {
                setAdvantage(1);
            }

            if (advantagePlayer2())
            {
                setAdvantage(2);
            }

            if (winPlayer1())
            {
                setWinner(1);
            }

            if(winPlayer2())
            {
                setWinner(2);
            }

            return score;
        }

        public void SetP1Score(int number)
        {
            for (int i = 0; i < number; i++)
            {
                P1Score();
            }
        }

        public void SetP2Score(int number)
        {
            for (var i = 0; i < number; i++)
            {
                P2Score();
            }
        }

        private void P1Score()
        {
            m_score1++;
        }

        private void P2Score()
        {
            m_score2++;
        }

        public void WonPoint(string player)
        {
            if (player == "player1")
                P1Score();
            else
                P2Score();
        }

        private bool isTie()
        {
            return m_score1 == m_score2;
        }

        private void initScore()
        {
            score = "";
        }

        private bool isDeuce()
        {
            return isTie() && m_score1 > 2;
        }

        private void setDeuce()
        {
            score = "Deuce";
        }

        private void setScore1()
        {
            if (m_score1 == 0)
                p1res = "Love";
            if (m_score1 == 1)
                p1res = "Fifteen";
            if (m_score1 == 2)
                p1res = "Thirty";
            if (m_score1 == 3)
                p1res = "Forty";
        }

        private void setScore2()
        {
            if (m_score2 == 0)
                p2res = "Love";
            if (m_score2 == 1)
                p2res = "Fifteen";
            if (m_score2 == 2)
                p2res = "Thirty";
            if (m_score2 == 3)
                p2res = "Forty";
        }

        private bool advantagePlayer1()
        {
            return m_score1 > m_score2 && m_score2 >= 3;
        }

        private bool advantagePlayer2()
        {
            return m_score2 > m_score1 && m_score1 >= 3;
        }

        private void setAdvantage(int player)
        {
            score = "Advantage player" + player;
        }

        private bool winPlayer1()
        {
            return m_score1 >= 4 && (m_score1 - m_score2) >= 2;
        }

        private bool winPlayer2()
        {
            return m_score2 >= 4 && (m_score2 - m_score1) >= 2;
        }

        private void setWinner(int player)
        {
            score = "Win for player" + player;
        }

    }
}


