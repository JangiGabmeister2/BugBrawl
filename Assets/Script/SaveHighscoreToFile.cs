using System.IO;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class SaveHighscoreToFile
{
    #region old ways
    //public void Save(HighscoreData data)
    //{
    //    string json = JsonUtility.ToJson(data); //converts data to JSON format
    //    string path = Application.dataPath + "/highscores.txt"; //gets the file path to save the data in

    //    StreamWriter writer = new StreamWriter(path, true); //the class that will write the text file
    //    //false = replaces, true = adds/writes new line

    //    writer.Write(json); //writes save data onto json file

    //    writer.Close(); //closes writer
    //}

    //public HighscoreData Load()
    //{
    //    string path = Application.dataPath + "/highscores.txt"; //get the file from the file path

    //    StreamReader reader = new StreamReader(path); //the class that will read the text file
    //    string fileData = reader.ReadToEnd(); //read the whole json at once from start to end

    //    HighscoreData data = JsonUtility.FromJson<HighscoreData>(fileData); //read the data and store it into something usable by us

    //    reader.Close(); //close reader

    //    return data;
    //}
    #endregion

    string path = Application.dataPath + "/highscores.txt";

    public void CreateText(HighscoreData data)
    {
        if (!File.Exists(path))
        {
            File.WriteAllText(path, "");
        }

        string content = $"{data.score}";

        File.AppendAllText(path, content);
    }

    public string LoadScores()
    {
        string content = File.ReadAllText(path);
        return content;
    }

    public void ClearScores()
    {
        File.WriteAllText(path, string.Empty);
    }
}
