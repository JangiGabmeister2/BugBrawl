using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    #region first try
    //    public ScoreCell[] cells = new ScoreCell[9];
    //    public GameObject orignalCellPrefab; //the original scoreboard cell prefab
    //    private List<GameObject> _clones = new List<GameObject>(); //clones of the prefab

    //    public Transform scoreBoard; //the scoreboard where the prefabs will be parented
    //    public Button button1, button2, button3; //the buttons to input the player name
    //    public Button submit; //the button to submit a new score cell

    //    string _playerName; //name of player, assigned by the three buttons above

    //    public Timer timer;

    //    private void Start()
    //    {
    //        button1.name = "A"; //reset the text of the inut buttons
    //        button2.name = "A";
    //        button3.name = "A";
    //    }

    //    public void Submit()
    //    {
    //        MenuHandler.menuHandlerInstance.panels[3].SetActive(false); //sets the input panel to false

    //        MenuHandler.menuHandlerInstance.gameState = GameStates.Hiscores; //sets the gamestate to highscores
    //        MenuHandler.menuHandlerInstance.NextState();

    //        SetName(); //sets the name of player
    //    }

    //    private void SetName()
    //    {
    //        if (button1.name == "K" && button2.name == "K" && button3.name == "K") //if all THREE buttons are the letter K
    //        {
    //            _playerName = "---";
    //        }

    //        _playerName = button1.name + button2.name + button3.name; //else name will be 3 other letters

    //        FillBoard(); //fills up scoreboard of cells
    //    }

    //    public void FillBoard()
    //    {
    //        for (int i = 0; i < cells.Length; i++)
    //        {
    //            ScoreCell newCell = CreateCells();

    //            _clones[i].gameObject.transform.Find("Name").GetComponent<Text>().text = newCell.name;
    //            _clones[i].gameObject.transform.Find("Time").GetComponent<Text>().text = newCell.time;
    //            _clones[i].gameObject.transform.Find("Score").GetComponent<Text>().text = newCell.score.ToString();
    //        }

    //        foreach (GameObject cellClone in _clones)
    //        {
    //            Destroy(cellClone);
    //            _clones.Clear();
    //        }
    //    }

    //    ScoreCell CreateCells()
    //    {
    //        GameObject clone = Instantiate(orignalCellPrefab, new Vector3(0, 0, 0), Quaternion.identity, scoreBoard);
    //        _clones.Add(clone);

    //        cells[i] = new ScoreCell(_playerName, MinutesSeconds(timer.timer), timer.score);

    //        return clone;
    //    }

    //    string MinutesSeconds(float time)
    //    {
    //        int secs = (int)time % 60;
    //        int mins = (int)time / 60;

    //        string secString = $"{secs}";
    //        string minString = $"{mins}";
    //        if (secs < 10)
    //        {
    //            secString = $"0{secs}";
    //        }
    //        if (mins < 10)
    //        {
    //            minString = $"0{mins}";
    //        }

    //        string timeText = $"{minString}:{secString}";

    //        return timeText;
    //    }
    #endregion

    #region variables to save
    public GameObject originalPrefab;
    List<GameObject> _clones = new List<GameObject>();

    public Transform scoreBoard; //the scoreboard where the prefabs will be parented
    public Button button1, button2, button3; //the buttons to input the player name
    public Button submit; //the button to submit a new score cell

    string _playerName; //name of player, assigned by the three buttons above

    public Timer timer;
    #endregion

    private string savedString;

    public List<ScoreCell> cells = new List<ScoreCell>();
    public string[] splitter;
    public string[] loadedScores;

    public string path = "Assets/Game Systems/Resources/Save/TextSaveFile.txt";

    private void Start()
    {
        _playerName = button1.name + button2.name + button3.name;

        Read();
    }

    public void OnSubmitButton()
    {
        MenuHandler.menuHandlerInstance.panels[3].SetActive(false); //sets the input panel to false
        MenuHandler.menuHandlerInstance.gameState = GameStates.Hiscores; //sets the gamestate to highscores
        MenuHandler.menuHandlerInstance.NextState();

        float timeInSeconds = timer.timeElapsed;
        string newTime = MinutesSeconds(timeInSeconds);
        savedString = CreateString(_playerName, newTime, timer.score);

        cells[10] = new ScoreCell(savedString);

        Read();
    }

    public void Write()
    {
        StreamWriter writer = new StreamWriter(path, false);

        //for (int i = 0; i < cells.Count; i++)
        //{
        //    GameObject clone = Instantiate(originalPrefab, new Vector3(0, 0, 0), Quaternion.identity, scoreBoard);
        //    _clones.Add(clone);
        //
        //    _clones[i].gameObject.transform.Find("Name").GetComponent<Text>().text =
        //                      _clones[i].gameObject.transform.Find("Time").GetComponent<Text>().text =
        //                       _clones[i].gameObject.transform.Find("Score").GetComponent<Text>().text =
        //}

        for (int i = 0; i < cells.Count; i++)
        {
            if (i < cells.Count - 1)
            {
                writer.Write(cells[i] + "/");
            }
            else
            {
                writer.Write(cells[i]);
            }
        }
        writer.Close();

        AssetDatabase.ImportAsset(path);
    }

    public void Read()
    {
        StreamReader reader = new StreamReader(path);

        string tempRead = reader.ReadLine();

        splitter = tempRead.Split("/");

        loadedScores = new string[splitter.Length];

        for (int i = 0; i < loadedScores.Length; i++)
        {
            loadedScores[i] = splitter[i];
            Debug.Log(splitter[i]);
        }

        reader.Close();
    }

    string CreateString(string playerName, string time, int score)
    {
        string newString = $"{playerName}|{time}|{score}";

        return newString;
    }

    string MinutesSeconds(float time)
    {
        int secs = (int)time % 60;
        int mins = (int)time / 60;

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

        string timeText = $"{minString}:{secString}";

        return timeText;
    }
}