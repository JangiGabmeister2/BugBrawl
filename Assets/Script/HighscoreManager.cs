//using UnityEngine;
//using UnityEngine.UI;

//public class HighscoreManager : MonoBehaviour
//{
//    Timer timer = new Timer();
//    SaveHighscoreToFile saveSystem = new SaveHighscoreToFile();

//    public Text leaderboardDisplay;
//    public Button btn1, btn2, btn3;

//    private string userName;
//    private string timeElapsed;
//    private int scoreEarned;

//    public void DisplayScores()
//    {
//        saveSystem.LoadScores(leaderboardDisplay);
//    }

//    public void SubmitScores()
//    {
//        userName = btn1.name + btn2.name + btn3.name;
//        timeElapsed = timer.GetTime();
//        scoreEarned = timer.GetScore();

//        HighscoreData newData = new HighscoreData();
//        newData.playerName = userName;
//        newData.time = timeElapsed;
//        newData.score = scoreEarned;

//        saveSystem.CreateText(newData);
//    }
//}
