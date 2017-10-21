using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Scoreboard : MonoBehaviour {

    [SerializeField] private List<Text> lineItems;

    private ScoreKeeper scores;

    // Use this for initialization
    void Start()
    {
        scores = ScoreKeeper.instance;
        UpdateText();
    }

    public void UpdateText()
    {
        List<Score> stuff = scores.GetScores();

        for (int i = 0; i < stuff.Count; i++)
        {
            lineItems[i].text = i+1 + " " + stuff[i].name + ": " + stuff[i].score;
        }
        for (int i = stuff.Count; i < lineItems.Count; i++)
        {
            lineItems[i].text = i+1 + ": THIS COULD BE YOU!";
        }

    }
}
