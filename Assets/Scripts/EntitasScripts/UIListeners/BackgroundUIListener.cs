using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundUIListener : UIListener, IAnyGlobalSpeedListener
{
    [SerializeField]
    private Animator _background;
    public override void Subscribe()
    {
        Contexts.sharedInstance.game.CreateEntity().AddAnyGlobalSpeedListener(this);
    }

    public void OnAnyGlobalSpeed(GameEntity entity, float globalSpeed)
    {
        _background.speed = globalSpeed*0.5f;
    }

}
