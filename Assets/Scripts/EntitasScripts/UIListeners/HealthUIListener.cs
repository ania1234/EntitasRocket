using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIListener : SpawnCountersUIListener, IHealthListener
{
    private List<GameObject> _spawnedHealthCounters = new List<GameObject>();

    public override void Subscribe()
    {
        var listener = Contexts.sharedInstance.game.GetEntityWithId(Constants.PLAYER_ID);
        listener.AddHealthListener(this);
    }

    public void OnHealth(GameEntity entity, int value)
    {
        var health = entity.health.value;
        SetValue(health);
    }
}
