using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreManager : MonoBehaviour
{
    private HighscoreData[] highscores;
    private HighscoreData highscore;
    private SaveHighscoreToFile saveSystem;

    public Text playerNameText, timeElapsedText, scoreText;
    public GameObject inputPanel;

    private float[] scoreOrder = new float[9];

    void Start()
    {
        //HighscoreData data = new HighscoreData();
        //data.score = 400f;
        //data.time = "3:45";
        //data.userName = "Michael";
        //saveSystem.Save(data);
        //HighscoreData loadedData = saveSystem.Load();
        //Debug.Log($"Username: {loadedData.userName}, Time: {loadedData.time}pm, {loadedData.score}pts");

        //highscore = saveSystem.Load();
        string[] loadedNames = new string[9];
        string[] loadedTimes = new string[9];
        float[] loadedScore = new float[9];




        playerNameText.text = "\n";
        timeElapsedText.text = "\n";
        scoreText.text = "\n";
    }

    public void OnSubmitButton()
    {
        inputPanel.SetActive(false);
    }
}
