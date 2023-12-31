﻿using UnityEngine;
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
        MainScore.text = PersistentScript.instance.score.ScorePoints.ToString();
        HealthBonus.text = "+ " + PersistentScript.instance.score.multiplyLife.ToString() + " x " + PersistentScript.instance.score.Life.ToString();
        ShootBonus.text = "+ " + PersistentScript.instance.score.multiplyAmmo.ToString() + " x " + PersistentScript.instance.score.Ammo.ToString();
        GoldBonus.text = "+ " + PersistentScript.instance.score.multiplyGold.ToString() + " x " + PersistentScript.instance.score.Gold.ToString();

        Summary.text = "= " + PersistentScript.instance.score.CalculateScore().ToString();

        HighScore.text = "( Highscore : " + PersistentScript.instance.highScores[PersistentScript.instance.currentLevelNumber-1].ToString() + " )";
	}
}
