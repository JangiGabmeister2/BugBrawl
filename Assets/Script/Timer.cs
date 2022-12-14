using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public GameObject player; //the player game object

    public float timer;
    float timeElapsed;
    public int score = 0;
    string time;

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
            player.SetActive(true);

            timer -= Time.deltaTime;
            timeElapsed += Time.deltaTime;

            if (timer <= 0)
            {
                timer = 0;
                player.SetActive(false);
            }

            if (timer >= 300)
            {
                timer = 300;
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

            time = $"{minString}:{secString}";
            timerDisplay.text = $"Time:\n{time}";
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

    public void NewGame()
    {
        timer = 65f;
        score = 0;
        timeElapsed = 0f;

        player.SetActive(true);
    }

    public void AddPoints(int value)
    {
        score += value;
    }

    public void AddTime(float timeInSeconds)
    {
        timer += timeInSeconds;
        timeElapsed += timeInSeconds;
    }

    public string GetTime()
    {
        return time;
    }

    public int GetScore()
    {
        return score;
    }
}
