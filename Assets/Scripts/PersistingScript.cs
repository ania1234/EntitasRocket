using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System;
using System.Collections.Generic;

public class PersistingScript : MonoBehaviour {

    public int maxLevelNumber;
    public int currentLevelNumber;
    public List<int> highScores;

    public static PersistingScript persistingScript;

    public GameScript rocket;
    public Score score;

	// Use this for initialization
	void Start () {
        if (persistingScript == null)
        {
            score = new Score();
            //DontDestroyOnLoad(gameObject);
            persistingScript = this;
        }
        else if (persistingScript != this)
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update () {
	
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
                    for (int i = 0; i < Constants.LevelsNumber; i++)
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
                for (int i = 0; i < Constants.LevelsNumber; i++)
                {
                    highScores.Add(0);
                }
            }

        if (highScores == null || highScores.Count != Constants.LevelsNumber)
        {
            highScores = new List<int>();
            for (int i = 0; i < Constants.LevelsNumber; i++)
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
