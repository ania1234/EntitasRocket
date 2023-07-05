using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class BackWallScript : MonoBehaviour {

    void OnCollisionEnter2D(Collision2D coll)
    {
        switch (coll.gameObject.tag)
        {
            case Constants.Tags.Player:

                if (PersistentScript.instance.maxLevelNumber == PersistentScript.instance.currentLevelNumber)
                {
                    PersistentScript.instance.maxLevelNumber = Mathf.Min(PersistentScript.instance.maxLevelNumber + 1, 8);
                }
                PersistentScript.instance.highScores[PersistentScript.instance.currentLevelNumber - 1] =
                Mathf.Max(PersistentScript.instance.highScores[PersistentScript.instance.currentLevelNumber - 1], PersistentScript.instance.score.CalculateScore());
                PersistentScript.instance.Save();
                SceneManager.LoadScene(Constants.SceneNames.WinScene, LoadSceneMode.Single);
                break;
            case Constants.Tags.Gold:
                if (PersistentScript.instance.currentLevelNumber == Constants.MAX_LEVELS)
                {
                    PersistentScript.instance.highScores[PersistentScript.instance.currentLevelNumber - 1] =
                    Mathf.Max(PersistentScript.instance.highScores[PersistentScript.instance.currentLevelNumber - 1], PersistentScript.instance.score.CalculateScore());
                    PersistentScript.instance.Save();
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
