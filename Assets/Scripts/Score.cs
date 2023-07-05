using UnityEngine;
using System.Collections;

public class Score {
    public int Gold { get; private set; } = 0;
    public int ScorePoints { get; private set; } = 0;
    public int Life { get; private set; } = 0;
    public int Ammo { get; private set; } = 0;

    public int multiplyGold = 100;
    public int multiplyLife = 50;
    public int multiplyAmmo = 200;

    public int CalculateScore()
    {
        var player = Contexts.sharedInstance.game.GetEntityWithId(Constants.PLAYER_ID);
        if (player != null)
        {
            ScorePoints = player.score.score;
            Life = player.health.value;
            Ammo = player.ammo.value;
        }

        int result = ScorePoints + multiplyAmmo * Ammo + multiplyGold * Gold + multiplyLife * Life;
        return result;
    }

    internal void ResetScore()
    {
        Gold = 0;
        ScorePoints = 0;
        Life = 3;
        if (PersistentScript.instance.currentLevelNumber < Constants.FirstLevelWithShots)
        {
            Ammo = 0;
        }
        else
        {
            Ammo = 3;
        }
        multiplyGold = 100;
        multiplyLife = 50;
        multiplyAmmo = 200;
    }
}
