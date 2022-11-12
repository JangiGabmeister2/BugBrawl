using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(MenuHandler))]
public class Timer : MonoBehaviour
{
    public float timer = 300;
    public static int score = 0;

    public Text scoreDisplay;
    public Text timerDisplay;


    private void Start()
    {
        InvokeRepeating(nameof(ScoreBoard), 1f, 1f);
    }

    private void Update()
    {
        TimerTick();
    }

    private void TimerTick()
    {
        timer -= Time.deltaTime;

        if (timer == 0)
        {
            timer = 0;
        }

        int secs = (int)timer % 60;
        int mins = (int)timer / 60;
        string time = "Time:\n0" + mins + ":" + secs;
        timerDisplay.text = time;
    }

    private void ScoreBoard()
    {
        score++;
        string scoreText = score.ToString("0000000");
        scoreDisplay.text = $"Score:\n{scoreText}";
    }
}
