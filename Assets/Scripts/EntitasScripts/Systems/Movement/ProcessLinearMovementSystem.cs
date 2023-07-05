using Entitas;
using UnityEngine;

public class ProcessLinearMovementSystem : IExecuteSystem
{
    private IGroup<GameEntity> _movableEntities;

    public ProcessLinearMovementSystem(Contexts contexts)
    {
        _movableEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.LinearSpeedMovement, GameMatcher.Position));
    }
    public void Execute()
    {
        foreach(var movableEntity in _movableEntities)
        {
            movableEntity.ReplacePosition(new Vector3(movableEntity.position.value.x + movableEntity.linearSpeedMovement.speed*Time.deltaTime, movableEntity.position.value.y, movableEntity.position.value.z));
        }
    }
}
