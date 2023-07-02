using Entitas;
using UnityEngine;

public class DebugConstantMovementSystem : IExecuteSystem
{
    readonly Contexts _contexts;

    public DebugConstantMovementSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    void IExecuteSystem.Execute()
    {
        var allPositionEntities = _contexts.game.GetEntities(GameMatcher.Position);
        foreach(var entity in allPositionEntities)
        {
            entity.ReplacePosition(entity.position.value + new Vector3(1, 1, 0) * Time.deltaTime);
        }
    }
}
