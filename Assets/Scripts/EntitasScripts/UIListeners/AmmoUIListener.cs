using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoUIListener : SpawnCountersUIListener, IAmmoListener
{

    public override void Subscribe()
    {
        var listener = Contexts.sharedInstance.game.GetEntityWithId(Constants.PLAYER_ID);
        listener.AddAmmoListener(this);
    }
    public void OnAmmo(GameEntity entity, int value)
    {
        SetValue(entity.ammo.value);
    }
}
