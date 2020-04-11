namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private int p2;
        private int p1;
        private string p1N;
        private string p2N;
        private string[] p = { "Love", "Fifteen", "Thirty", "Forty" };

        public TennisGame3(string player1Name, string player2Name)
        {
            this.p1N = player1Name;
            this.p2N = player2Name;
        }

        public string GetScore()
        {
            string s;

            if ((p1 < 4 && p2 < 4) && (p1 + p2 < 6))
            {
                if (isTie())
                {
                    s = p[p1] + "-All";
                }
                else
                {
                    s = p[p1] + "-" + p[p2];
                }
            }
            else
            {
                if (isDeuce())
                {
                    s = "Deuce";
                }
                else
                {
                    if ((p1 - p2) * (p1 - p2) == 1)
                    {
                        s = p1 > p2 ? p1N : p2N;
                        s = "Advantage " + s;
                    }
                    else
                    {
                        s = p1 > p2 ? p1N : p2N;
                        s = "Win for " + s;
                    }
                }
            }

            return s;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                this.p1 += 1;
            else
                this.p2 += 1;
        }

        private bool isTie()
        {
            return p1 == p2;
        }

        private bool isDeuce()
        {
            return isTie() && p1 > 2;
        }

    }
}

