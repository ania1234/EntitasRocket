using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreDisplayScript : MonoBehaviour {
    public Text MainScore;
    public Text HealthBonus;
    public Text ShootBonus;
    public Text GoldBonus;
    public Text Summary;
    public Text HighScore;

	// Use this for initialization
	void Start () {
        MainScore.text = PersistingScript.persistingScript.score.score.ToString();
        HealthBonus.text = "+ " + PersistingScript.persistingScript.score.multiplyLife.ToString() + " x " + PersistingScript.persistingScript.score.life.ToString();
        ShootBonus.text = "+ " + PersistingScript.persistingScript.score.multiplyAmmo.ToString() + " x " + PersistingScript.persistingScript.score.ammo.ToString();
        GoldBonus.text = "+ " + PersistingScript.persistingScript.score.multiplyGold.ToString() + " x " + PersistingScript.persistingScript.score.gold.ToString();

        Summary.text = "= " + PersistingScript.persistingScript.score.CalculateScore().ToString();

        HighScore.text = "( Highscore : " + PersistingScript.persistingScript.highScores[PersistingScript.persistingScript.currentLevelNumber-1].ToString() + " )";
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
