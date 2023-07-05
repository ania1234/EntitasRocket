using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class PersistentScript : MonoBehaviour {

    public int maxLevelNumber;
    public int currentLevelNumber;
    public List<int> highScores;

    public static PersistentScript instance;

    public GameScript rocket;
    public Score score;

    internal void NoteMaxLevel()
    {
        maxLevelNumber = Mathf.Min(maxLevelNumber + 1, Constants.MAX_LEVELS);
    }

    // Update is called once per frame
    void Awake () {
        if (instance == null)
        {
            score = new Score();
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            GameObject.Destroy(this.gameObject);
        }
	}

    internal void LoadLooseScene()
    {
        SceneManager.LoadScene(Constants.SceneNames.LooseScene, LoadSceneMode.Single);
    }

    internal void LoadWinScene()
    {
        SceneManager.LoadScene(Constants.SceneNames.WinScene, LoadSceneMode.Single);
    }

    internal void NoteHighScore()
    {
        highScores[currentLevelNumber - 1] = Mathf.Max(highScores[currentLevelNumber - 1], score.CalculateScore());
    }

    public void Save()
    {
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        FileStream file = File.Open(Application.persistentDataPath + "/" + Constants.persistentFileName, FileMode.OpenOrCreate);
        DataClass data = new DataClass();
        data.maxLevelNumber = maxLevelNumber;
        data.currentLevelNumber = currentLevelNumber;
        data.highScores = highScores;
        binaryFormatter.Serialize(file, data);
        file.Close();
    }

    void OnEnable()
    {

        if (File.Exists(Application.persistentDataPath + "/" + Constants.persistentFileName))
            {
                try
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    FileStream file = File.Open(Application.persistentDataPath + "/" + Constants.persistentFileName, FileMode.OpenOrCreate);
                    DataClass data = (DataClass)binaryFormatter.Deserialize(file);
                    file.Close();
                    currentLevelNumber = Mathf.Max(data.currentLevelNumber, 1);
                    maxLevelNumber = Mathf.Max(data.maxLevelNumber, 1);
                    highScores = data.highScores;
                }
                catch
                {
                    maxLevelNumber = 1;
                    currentLevelNumber = 1;
                    highScores = new List<int>();
                    for (int i = 0; i < Constants.MAX_LEVELS; i++)
                    {
                        highScores.Add(0);
                    }
                }
            }
            else
            {
                maxLevelNumber = 1;
                currentLevelNumber = 1;
                highScores = new List<int>();
                for (int i = 0; i < Constants.MAX_LEVELS; i++)
                {
                    highScores.Add(0);
                }
            }

        if (highScores == null || highScores.Count != Constants.MAX_LEVELS)
        {
            highScores = new List<int>();
            for (int i = 0; i < Constants.MAX_LEVELS; i++)
            {
                highScores.Add(0);
            }
        }
                   
    }

    internal void SetRocket(GameScript gameScript)
    {
        this.rocket = gameScript;
    }
}

[Serializable]
class DataClass
{
    public int maxLevelNumber;
    public int currentLevelNumber;
    public int versionNumber = Constants.VersionNumber;
    public List<int> highScores;
}
