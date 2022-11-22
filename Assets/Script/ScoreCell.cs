using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class ScoreCell : MonoBehaviour
{
    public GameObject cell;
    public string name;
    public string time;
    public int score;

    public ScoreCell(GameObject cell, string name, string time, int score)
    {
        this.cell = cell;
        this.name = name;
        this.time = time;
        this.score = score;
    }
}