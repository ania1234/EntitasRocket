using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUIListener : SpawnCountersUIListener, IHealthListener
{
    [SerializeField]
    private GameObject _healthCounterPrefab;

    private List<GameObject> _spawnedHealthCounters = new List<GameObject>();

    public override void Subscribe()
    {
        var listener = Contexts.sharedInstance.game.GetEntityWithId(Constants.PLAYER_ID);
        listener.AddHealthListener(this);
    }

    public void OnHealth(GameEntity entity, int value)
    {
        var health = entity.health.value;

        for(int i =_spawnedHealthCounters.Count-1; i>=Mathf.Max(health, 0); i--)
        {
            GameObject.Destroy(_spawnedHealthCounters[i]);
            _spawnedHealthCounters.RemoveAt(i);
        }

        for(int i = _spawnedHealthCounters.Count; i<health; i++)
        {
            var spawned = GameObject.Instantiate(_healthCounterPrefab, this.transform);
            _spawnedHealthCounters.Add(spawned);
        }
    }
}
