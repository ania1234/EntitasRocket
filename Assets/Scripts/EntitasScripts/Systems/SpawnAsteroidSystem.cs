using Entitas;
using UnityEngine;

public class SpawnAsteroidSystem : IExecuteSystem
{
    readonly Contexts _contexts;
    int currentWave = 0;
    float speed = 2;
    private float _lastTimeSystemUpdated = 0;
    public SpawnAsteroidSystem(Contexts contexts)
    {
        _contexts = contexts;
        _lastTimeSystemUpdated = Time.time;
    }

    public void Execute()
    {
        if(Time.time - _lastTimeSystemUpdated < 1 / speed)
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
                e.AddLinearSpeedMovement(-speed);
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
            e.AddLinearSpeedMovement(-speed);
            _lastTimeSystemUpdated = Time.time;
            currentWave++;
        }
    }
}
