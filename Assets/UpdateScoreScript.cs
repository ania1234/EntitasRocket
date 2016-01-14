using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UpdateScoreScript : MonoBehaviour {

    Text component;
    int score;
	// Use this for initialization
	void Start () {
        component = GetComponent<Text>();
        score = 0;
        component.text = "S c o r e : " + score.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void UpdateScore(string enemyTag)
    {
        score++;
        component.text = "S c o r e : " + score.ToString();
    }
}
