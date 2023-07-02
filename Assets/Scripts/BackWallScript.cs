using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class BackWallScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case Constants.Tags.Player:

                if (PersistingScript.persistingScript.maxLevelNumber == PersistingScript.persistingScript.currentLevelNumber)
                {
                    PersistingScript.persistingScript.maxLevelNumber = Mathf.Min(PersistingScript.persistingScript.maxLevelNumber + 1, 8);
                }
                PersistingScript.persistingScript.highScores[PersistingScript.persistingScript.currentLevelNumber - 1] =
                Mathf.Max(PersistingScript.persistingScript.highScores[PersistingScript.persistingScript.currentLevelNumber - 1], PersistingScript.persistingScript.score.CalculateScore());
                PersistingScript.persistingScript.Save();
                SceneManager.LoadScene(Constants.SceneNames.WinScene, LoadSceneMode.Single);
                break;
            case Constants.Tags.Gold:
                if (PersistingScript.persistingScript.currentLevelNumber == Constants.LevelsNumber)
                {
                    PersistingScript.persistingScript.highScores[PersistingScript.persistingScript.currentLevelNumber - 1] =
                    Mathf.Max(PersistingScript.persistingScript.highScores[PersistingScript.persistingScript.currentLevelNumber - 1], PersistingScript.persistingScript.score.CalculateScore());
                    PersistingScript.persistingScript.Save();
                    SceneManager.LoadScene(Constants.SceneNames.WinScene, LoadSceneMode.Single);
                }
                else
                {
                    SceneManager.LoadScene(Constants.SceneNames.LooseScene, LoadSceneMode.Single);
                }
                break;
            default:
                Destroy(coll.gameObject);
                break;
        }
    }
}
