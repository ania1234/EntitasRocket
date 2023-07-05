using Entitas;
using System.Collections.Generic;

public class DestroySpeedInputSystem : ICleanupSystem
{

    readonly IGroup<InputEntity> _group;
    readonly List<InputEntity> _buffer = new List<InputEntity>();

    public DestroySpeedInputSystem(Contexts contexts)
    {
        _group = contexts.input.GetGroup(InputMatcher.SpeedInput);
    }

    public void Cleanup()
    {
        foreach (var e in _group.GetEntities(_buffer))
        {
            e.Destroy();
        }
    }
}