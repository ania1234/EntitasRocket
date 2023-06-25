using UnityEngine;
using System.Collections;

public class Score {
    public int gold = 0;
    public int score = 0;
    public int life = 3;
    public int ammo = 3;

    public int multiplyGold = 100;
    public int multiplyLife = 50;
    public int multiplyAmmo = 200;

    public int CalculateScore()
    {
        int result = score + multiplyAmmo * ammo + multiplyGold * gold + multiplyLife * life;
        return result;
    }

    internal void ResetScore()
    {
        gold = 0;
        score = 0;
        life = 3;
        if (PersistingScript.persistingScript.currentLevelNumber < Constants.FirstLevelWithShots)
        {
            ammo = 0;
        }
        else
        {
            ammo = 3;
        }
        multiplyGold = 100;
        multiplyLife = 50;
        multiplyAmmo = 200;
    }
}
