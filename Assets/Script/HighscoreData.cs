using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HighscoreData
{
    public string playerName;
    public string time;
    public int score;

    public HighscoreData()
    {
        playerName = "";
        time = "";
        score = 0000000;
    }

    public HighscoreData(string newName, string newTime, int newScore)
    {
        playerName = newName;
        time = newTime;
        score = newScore;
    }

    public HighscoreData(int oldHighscore)
    {
        score = oldHighscore;
    }
}
