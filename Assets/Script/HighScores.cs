using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HighScores : MonoBehaviour
{
    public GameObject orignalCellPrefab; //the original scoreboard cell prefab
    private List<GameObject> _clones = new List<GameObject>(); //clones of the prefab

    public Transform scoreBoard; //the scoreboard where the prefabs will be parented
    public Button button1, button2, button3; //the buttons to input the player name
    public Button submit; //the button to submit a new score cell

    string _playerName; //name of player, assigned by the three buttons above
    int cells = 10; //the number of cells in the scoreboard

    public Timer timer;

    private void Start()
    {
        button1.name = "A"; //reset the text of the inut buttons
        button2.name = "A";
        button3.name = "A";
    }
    public void Submit()
    {
        MenuHandler.menuHandlerInstance.panels[3].SetActive(false); //sets the input panel to false

        MenuHandler.menuHandlerInstance.gameState = GameStates.Hiscores; //sets the gamestate to highscores
        MenuHandler.menuHandlerInstance.NextState();

        SetName(); //sets the name of player
    }

    private void SetName()
    {
        if (button1.name == "K" && button2.name == "K" && button3.name == "K") //if all THREE buttons are the letter K
        {
            _playerName = "---";
        }

        _playerName = button1.name + button2.name + button3.name; //else name will be 3 other letters

        FillBoard(); //fills up scoreboard of cells
    }

    public void FillBoard()
    {
        for (int i = 0; i < cells; i++)
        {
            ScoreCell newCell = CreateCells();

            _clones[i].gameObject.transform.Find("Name").GetComponent<Text>().text = newCell.name;
            _clones[i].gameObject.transform.Find("Time").GetComponent<Text>().text = newCell.time;
            _clones[i].gameObject.transform.Find("Score").GetComponent<Text>().text = newCell.score.ToString();
        }

        foreach (GameObject cellClone in _clones)
        {
            Destroy(cellClone);
            _clones.Clear();
        }
    }

    //https://www.youtube.com/watch?v=E2jAMc_Zk1U
    ScoreCell CreateCells()
    {
        GameObject clone = Instantiate(orignalCellPrefab, new Vector3(0, 0, 0), Quaternion.identity, scoreBoard);
        _clones.Add(clone);

        ScoreCell newCell = clone.GetComponent<ScoreCell>();
        newCell.cell = orignalCellPrefab;
        newCell.name = _playerName;
        newCell.time = MinutesSeconds(timer.timeElapsed);
        newCell.score = timer.score;

        return newCell;
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
