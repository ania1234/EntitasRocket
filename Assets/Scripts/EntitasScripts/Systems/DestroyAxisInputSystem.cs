using Entitas;
using System.Collections.Generic;

public class DestroyAxisInputSystem : ICleanupSystem
{

    readonly IGroup<InputEntity> _group;
    readonly List<InputEntity> _buffer = new List<InputEntity>();

    public DestroyAxisInputSystem(Contexts contexts)
    {
        _group = contexts.input.GetGroup(InputMatcher.AxisInput);
    }

    public void Cleanup()
    {
        foreach (var e in _group.GetEntities(_buffer))
        {
            e.Destroy();
        }
    }
}
