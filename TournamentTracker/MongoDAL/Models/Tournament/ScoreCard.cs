using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDAL.Model
{
    public class ScoreCard
    {
        public ScoreCard()
        {
            RoundAndScores = new List<KeyValuePair<int, int>>();
        }

        public List<KeyValuePair<int, int>> RoundAndScores { get; set; }

        public void AddScore(int round, int wins, int losses)
        {
            RoundAndScores.Add(new KeyValuePair<int, int>(round, (wins * 100 + losses)/(wins+losses)));
        }

        public int Score()
        {
            int score = 0;
            RoundAndScores.ForEach(p => score += p.Value);

            return score;
        }
    }
}
