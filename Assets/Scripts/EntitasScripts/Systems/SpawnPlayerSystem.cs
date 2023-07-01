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
    }
}
