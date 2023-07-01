using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButtonScript : MonoBehaviour 
{
    public void OnClick()
    {
        SceneManager.LoadScene(Constants.SceneNames.LevelSelectionScene);
    }
}
