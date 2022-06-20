using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Progression
{
    public Dictionary<int, GameResult> records;

    public Progression()
    {
        records = new Dictionary<int, GameResult>();
    }
    public class GameResult
    {
        public int highScore;
        public int maxHighScore;

        public GameResult(int score, int high)
        {
            highScore = score;
            maxHighScore = Mathf.Max(score, high);
        }
    }

    public bool RegisterHighScore(GameResult result)
    {
        //Method don't checked
        var beat = result.highScore > result.maxHighScore;
        if (beat)
        {
          //  records[max] = result;
        }
        return beat;
    }
}

