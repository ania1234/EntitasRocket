using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MidLevelScript : MonoBehaviour {

    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;
    public GameObject Level8;
	// Use this for initialization
	void Start () {
        switch(PersistentScript.instance.currentLevelNumber)
        {
            case 1:
                Level1.SetActive(true);
                break;
            case 2:
                Level2.SetActive(true);
                break;
            case 3:
                Level3.SetActive(true);
                break;
            case 4:
                Level4.SetActive(true);
                break;
            case 8:
                Level8.SetActive(true);
                break;
            default:
                ContinueButtonClick();
                break;
        }
	}
	

    public void ContinueButtonClick()
    {
        SceneManager.LoadScene(Constants.SceneNames.GameScene, LoadSceneMode.Single);
    }
}
