using Entitas;
using UnityEngine;

public class ProcessSineMovementSystem : IExecuteSystem
{
    private IGroup<GameEntity> _movableEntities;

    public ProcessSineMovementSystem(Contexts contexts)
    {
        _movableEntities = contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.SineMovement, GameMatcher.Position));
    }
    public void Execute()
    {
        foreach(var movableEntity in _movableEntities)
        {
            var A = movableEntity.sineMovement.A;
            var B = movableEntity.sineMovement.B;
            var C = movableEntity.sineMovement.C;
            //Debug.LogError($"{A}, {B}, {C}");
            movableEntity.ReplacePosition(new Vector3(movableEntity.position.value.x, A * Mathf.Sin(B * Time.time - C), movableEntity.position.value.z));
        }
    }
}
