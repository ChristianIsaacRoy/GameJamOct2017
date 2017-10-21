using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct Score
{
    public string name;
    public int score;

    public Score(string name, int score)
    {
        this.name = name;
        this.score = score;
    }
}

public class ScoreKeeper : MonoBehaviour
{
    public static ScoreKeeper instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public List<Score> GetScores()
    {
        List<Score> ret = new List<Score>();
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                ret.Add(new Score(PlayerPrefs.GetString(i + "HScoreName"), PlayerPrefs.GetInt(i + "HScore")));
            }
        }
        return ret;
    }

    private void AddScore(string name, int score)
    {
        int oldScore = score;
        string oldName = name;
        for (int i = 0; i < 10; i++)
        {
            if (PlayerPrefs.HasKey(i + "HScore"))
            {
                if (PlayerPrefs.GetInt(i + "HScore") < score)
                {
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetInt(i + "HScore");
                    oldName = PlayerPrefs.GetString(i + "HScoreName");
                    PlayerPrefs.SetInt(i + "HScore", score);
                    PlayerPrefs.SetString(i + "HScoreName", name);
                    score = oldScore;
                    name = oldName;
                }
            }
            else
            {
                PlayerPrefs.SetInt(i + "HScore", score);
                PlayerPrefs.SetString(i + "HScoreName", name);
                score = 0;
                name = "";
            }
        }
    }
}
