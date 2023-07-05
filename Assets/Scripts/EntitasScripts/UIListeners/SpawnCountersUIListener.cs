using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnCountersUIListener : UIListener
{
    [SerializeField]
    private GameObject _counterPrefab;

    private List<GameObject> _spawnedCounters = new List<GameObject>();

    protected virtual void SetValue(int value)
    {
        for (int i = _spawnedCounters.Count - 1; i >= Mathf.Max(value, 0); i--)
        {
            GameObject.Destroy(_spawnedCounters[i]);
            _spawnedCounters.RemoveAt(i);
        }

        for (int i = _spawnedCounters.Count; i < value; i++)
        {
            var spawned = GameObject.Instantiate(_counterPrefab, this.transform);
            _spawnedCounters.Add(spawned);
        }
    }
}
