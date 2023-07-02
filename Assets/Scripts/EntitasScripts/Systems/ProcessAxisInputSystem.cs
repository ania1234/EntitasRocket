using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class ProcessAxisInputSystem : ReactiveSystem<InputEntity>
{
    private IGroup<GameEntity> _movableUpDownComponents;

    public ProcessAxisInputSystem(Contexts contexts) : base(contexts.input)
    {
        _movableUpDownComponents = contexts.game.GetGroup(GameMatcher.Position);
    }
    protected override void Execute(List<InputEntity> entities)
    {
        var input = entities[entities.Count - 1];
        foreach(var movableUpDown in _movableUpDownComponents)
        {
            movableUpDown.ReplacePosition(movableUpDown.position.value + new Vector3(input.axisInput.value.x, input.axisInput.value.y)*Time.deltaTime);
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasAxisInput;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector<InputEntity>(InputMatcher.AxisInput);
    }
}
