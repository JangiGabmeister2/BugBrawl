using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum GameStates { Menu, Game, Hiscores, Input }

public enum Panels { MainMenu, GameHUD, HighScores, Input }

public class MenuHandler : MonoBehaviour
{
    #region MenuHandler Instance
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
    #endregion

    [SerializeField] private Timer timer;

    public GameObject[] panels;

    public GameStates gameState;
    public Panels panelState;

    public GameObject menuFirstSelect;
    public GameObject scoresFirstSelect;
    public GameObject inputFirstSelect;

    #region Switch States/Panels
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
            case GameStates.Hiscores:
                StartCoroutine(Highscores());
                break;
            case GameStates.Input:
                StartCoroutine(InputState());
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
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(false);
                }
                panels[0].SetActive(true);
                panels[2].SetActive(true);
                break;
            case Panels.Input:
                for (int i = 0; i < panels.Length; i++)
                {
                    panels[i].SetActive(true);
                }
                panels[1].SetActive(false);
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
    #endregion

    #region Button Functions
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
        gameState = GameStates.Hiscores;

        NextState();
    }

    public void Return()
    {
        gameState = GameStates.Menu;

        NextState();
    }
    #endregion

    #region PanelStates
    private IEnumerator MenuState()
    {
        NextPanel(0);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(menuFirstSelect);

        yield return null;
    }

    private IEnumerator GameState()
    {
        NextPanel(1);

        yield return null;
    }

    private IEnumerator Highscores()
    {
        NextPanel(2);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(scoresFirstSelect);

        yield return null;
    }
    private IEnumerator InputState()
    {
        NextPanel(3);

        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(inputFirstSelect);

        yield return null;
    }
    #endregion

    private void Update()
    {
        if (gameState == GameStates.Game)
        {
            if (timer.timer <= 0)
            {
                gameState = GameStates.Input;

                Invoke(nameof(NextState), 2f);
            }
        }
    }
    private void Start()
    {
        gameState = GameStates.Menu;
        timer.timer = 65f;
        timer.score = -1;

        NextPanel(0);
        NextState();
    }
}
