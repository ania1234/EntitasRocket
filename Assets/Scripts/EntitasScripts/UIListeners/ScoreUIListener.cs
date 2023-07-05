using UnityEngine;
using UnityEngine.UI;

public class ScoreUIListener : UIListener, IScoreListener
{
    [SerializeField]
    private Text _text;
    public void OnScore(GameEntity entity, int score)
    {
        _text.text = $"Score: {score}";
    }

    public override void Subscribe()
    {
        var listener = Contexts.sharedInstance.game.GetEntityWithId(Constants.PLAYER_ID);
        listener.AddScoreListener(this);
    }
}
