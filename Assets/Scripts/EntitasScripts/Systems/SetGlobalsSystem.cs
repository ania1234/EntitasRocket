using Entitas;
using UnityEngine;

public class SetGlobalsSystem : IInitializeSystem
{
    readonly Contexts _contexts;

    public SetGlobalsSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Initialize()
    {
        _contexts.game.SetGlobalSpeed(2);
    }
}
