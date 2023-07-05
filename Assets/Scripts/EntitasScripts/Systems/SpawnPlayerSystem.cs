using Entitas;
using UnityEngine;

public class SpawnPlayerSystem : IInitializeSystem
{
    readonly Contexts _contexts;

    public SpawnPlayerSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        var e = _contexts.game.CreateEntity();
        e.AddHealth(Constants.MAX_HEALTH);
        e.AddAsset(Constants.PLAYER_ID, false);
        e.AddPosition(new UnityEngine.Vector3(0, 0, 0));
        e.AddSineMovement(1, 1, 0, Time.time);
        e.AddId(Constants.PLAYER_ID);
        e.AddAmmo(0);
        e.AddScore(0);
    }
}
