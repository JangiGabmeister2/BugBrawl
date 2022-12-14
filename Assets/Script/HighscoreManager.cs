using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
    [SerializeField] Timer timer;
    SaveHighscoreToFile saveSystem;

    [SerializeField] Text previousScoreDisplay;

    int scoreEarned;

    private void Start()
    {
        saveSystem = new SaveHighscoreToFile();
    }

    private void Update()
    {
        scoreEarned = timer.GetScore();

        DisplayScores();

        if (timer.timer <= 0)
        {
            SubmitScores();
        }
    }

    public void DisplayScores()
    {
        string temp = saveSystem.LoadScores();

        int previousScore;

        bool parse = int.TryParse(temp, out previousScore);

        if (parse)
        {
            previousScoreDisplay.text = $"Current Highscore:\n{previousScore:0000000}";
        }
    }

    public void SubmitScores()
    {
        CheckNewScore(scoreEarned);
    }

    public void CheckNewScore(int newScore)
    {
        string temp = saveSystem.LoadScores();

        bool parse = int.TryParse(temp, out int previousScore);

        if (parse)
        {
            if (newScore > previousScore)
            {
                saveSystem.ClearScores();

                previousScore = scoreEarned;

                HighscoreData newData = new HighscoreData();

                newData.score = previousScore;

                saveSystem.CreateText(newData);
            }
        }
    }
}
