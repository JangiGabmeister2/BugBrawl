using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameStates { Menu, Game }

public enum Panels { MainMenu, GameHUD, HighScores }

public class MenuHandler : MonoBehaviour
{
    public GameObject[] panels;

    private static MenuHandler _menuManager;
    public static MenuHandler menuHandlerInstance
    {
        get => _menuManager;
        private set
        {
            if (_menuManager == null)
            {
                _menuManager = value;
            }
            else if (_menuManager != value)
            {
                //Debug.Log($"{nameof(MenuHandler)} instance already exists. Destroy duplicate. [insert Highlander quote]");
                Destroy(value);
            }
        }
    }

    private void Awake()
    {
        menuHandlerInstance = this;
    }

    public GameStates gameState;
    public Panels panelState;

    public void NextState()
    {
        switch (gameState)
        {
            case GameStates.Menu:
                StartCoroutine(MenuState());
                break;
            case GameStates.Game:
                StartCoroutine(GameState());
                break;
            default:
                StartCoroutine(MenuState());
                break;
        }
    }

    public void NextPanel(int value)
    {
        panelState = (Panels)value;

        switch (panelState)
        {
            case Panels.MainMenu:
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[0].SetActive(true);
                break;
            case Panels.GameHUD:
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[1].SetActive(true);
                break;
            case Panels.HighScores:
                panels[2].SetActive(true);
                StartCoroutine(Highscores());
                break;
            default:
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[0].SetActive(true);
                break;
        }
    }

    public void PlayButton()
    {
        gameState = GameStates.Game;

        NextState();
    }

    public void QuitButton()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    public void HighScore()
    {
        NextPanel(2);
    }

    private IEnumerator MenuState()
    {
        NextPanel(0);

        yield return null;
    }

    private IEnumerator GameState()
    {
        NextPanel(1);

        yield return null;
    }

    private IEnumerator Highscores()
    {
        yield return new WaitForSeconds(5f);

        NextPanel(0);
    }

    private void Start()
    {
        gameState = GameStates.Menu;

        NextPanel(0);
        NextState();
    }
}
