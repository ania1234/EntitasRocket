using Entitas;

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
        e.AddHealth(100);
        e.AddAsset("Player", false);
        e.AddPosition(new UnityEngine.Vector3(0, 0, 0));
    }
}
