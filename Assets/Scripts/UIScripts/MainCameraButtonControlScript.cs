using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainCameraButtonControlScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
        for (int i = 1; i <= PersistentScript.instance.maxLevelNumber; i++)
        {
            GameObject.Find("Button" + i.ToString()).GetComponent<Button>().interactable = true;
        }
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene(Constants.SceneNames.StartScene, LoadSceneMode.Single);
        }
	}

    public void StartGame(int level)
    {
        PersistentScript.instance.currentLevelNumber = level;
        SceneManager.LoadScene(Constants.SceneNames.MiddleScene, LoadSceneMode.Single);
    }
}
