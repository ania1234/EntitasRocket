using Entitas;
using System.Collections.Generic;

public class DestroyScaleInputSystem : ICleanupSystem
{

    readonly IGroup<InputEntity> _group;
    readonly List<InputEntity> _buffer = new List<InputEntity>();

    public DestroyScaleInputSystem(Contexts contexts)
    {
        _group = contexts.input.GetGroup(InputMatcher.ScaleInput);
    }

    public void Cleanup()
    {
        foreach (var e in _group.GetEntities(_buffer))
        {
            e.Destroy();
        }
    }
}