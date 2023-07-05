using Entitas;
using System.Collections.Generic;

public class DestroyShootingInputSystem : ICleanupSystem
{

    readonly IGroup<InputEntity> _group;
    readonly List<InputEntity> _buffer = new List<InputEntity>();

    public DestroyShootingInputSystem(Contexts contexts)
    {
        _group = contexts.input.GetGroup(InputMatcher.ShootInput);
    }

    public void Cleanup()
    {
        foreach (var e in _group.GetEntities(_buffer))
        {
            e.Destroy();
        }
    }
}
