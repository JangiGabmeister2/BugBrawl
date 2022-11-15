using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float timer = 305;
    public int score = 0;

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
        if (MenuHandler.menuHandlerInstance.gameState == GameStates.Game)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                MenuHandler.menuHandlerInstance.NextPanel(1);

                MenuHandler.menuHandlerInstance.gameState = GameStates.Menu;
                MenuHandler.menuHandlerInstance.NextState();
            }

            int secs = (int)timer % 60;
            int mins = (int)timer / 60;

            string secString = $"{secs}";
            string minString = $"{mins}";
            if (secs < 10)
            {
                secString = $"0{secs}";
            }
            if (mins < 10)
            {
                minString = $"0{mins}";
            }

            string time = $"Time:\n{minString}:{secString}";
            timerDisplay.text = time;
        }
    }

    private void ScoreBoard()
    {
        if (MenuHandler.menuHandlerInstance.gameState == GameStates.Game)
        {
            score++;
            string scoreText = score.ToString("0000000");
            scoreDisplay.text = $"Score:\n{scoreText}";
        }
    }

    public void AddPoints(int value)
    {
        score += value;
    }

    public void AddTime(float timeInSeconds)
    {
        timer += timeInSeconds;
    }
}
