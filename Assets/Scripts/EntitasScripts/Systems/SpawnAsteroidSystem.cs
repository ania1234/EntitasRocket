using Entitas;
using UnityEngine;

public class SpawnAsteroidSystem : IExecuteSystem
{
    readonly Contexts _contexts;
    int currentWave = 0;
    private float _lastTimeSystemUpdated = 0;
    public SpawnAsteroidSystem(Contexts contexts)
    {
        _contexts = contexts;
        _lastTimeSystemUpdated = Time.time;
    }

    public void Execute()
    {
        if (!_contexts.game.hasGlobalSpeed)
        {
            return;
        }

        if(Time.time - _lastTimeSystemUpdated < 1 / _contexts.game.globalSpeed.globalSpeed)
        {
            return;
        }

        if (currentWave < LevelsContainer.width)
        {
            _lastTimeSystemUpdated = Time.time;
            var data = LevelsContainer.GetAsteroidsData(currentWave);
            foreach(var asteroidData in data)
            {
                var e = _contexts.game.CreateEntity();
                e.AddAsset(asteroidData.typeKey, false);
                e.AddPosition(new Vector3(Constants.FARTHEST_X_POSITION, -1 * (asteroidData.height - 2), 0));
                e.isLinearSpeedMovement = true;
            }
            currentWave++;
        }

        if (currentWave >= LevelsContainer.width && currentWave < LevelsContainer.width + 3)
        {
            currentWave++;
            _lastTimeSystemUpdated = Time.time;
        }

        if (currentWave == LevelsContainer.width + 3)
        {
            var e = _contexts.game.CreateEntity();
            e.AddAsset("backWall", false);
            e.AddPosition(new Vector3(Constants.FARTHEST_X_POSITION, 0, 0));
            e.isLinearSpeedMovement = true;
            _lastTimeSystemUpdated = Time.time;
            currentWave++;
        }
    }
}
