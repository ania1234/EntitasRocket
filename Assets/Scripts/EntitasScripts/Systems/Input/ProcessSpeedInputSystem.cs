using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessSpeedInputSystem : ReactiveSystem<InputEntity>
{
    private IGroup<GameEntity> _linearMovements;

    public ProcessSpeedInputSystem(Contexts contexts) : base(contexts.input)
        {
        _linearMovements = contexts.game.GetGroup(GameMatcher.LinearSpeedMovement);
    }
    protected override void Execute(List<InputEntity> entities)
    {
        //more than one speed change in frame possible
        foreach (var entity in entities)
        {
            foreach (var linearMovement in _linearMovements)
            {
                linearMovement.ReplaceLinearSpeedMovement(linearMovement.linearSpeedMovement.speed+entity.speedInput.speedChange);
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasSpeedInput;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector<InputEntity>(InputMatcher.SpeedInput);
    }
}
