using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ScoreCell : MonoBehaviour
{
    public string item;
    public string name;
    public string time;
    public int score;

    public ScoreCell(string name, string time, int score)
    {
        this.name = name;
        this.time = time;
        this.score = score;
    }

    public ScoreCell(string item)
    {
        this.item = item;
    }
}