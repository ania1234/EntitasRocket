﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReplayScript : MonoBehaviour {
     public void OnLevelListClick()
    {
        SceneManager.LoadScene(Constants.SceneNames.LevelSelectionScene, LoadSceneMode.Single);
    }

    public void OnReplayClick()
    {
        SceneManager.LoadScene(Constants.SceneNames.GameScene, LoadSceneMode.Single);
    }
}
