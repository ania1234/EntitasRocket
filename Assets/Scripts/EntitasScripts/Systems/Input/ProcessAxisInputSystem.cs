using Entitas;
using System.Collections.Generic;
using UnityEngine;
using static Constants;

public class ProcessAxisInputSystem : ReactiveSystem<InputEntity>
{
    private IGroup<GameEntity> _sineMovements;

    public ProcessAxisInputSystem(Contexts contexts) : base(contexts.input)
    {
        _sineMovements = contexts.game.GetGroup(GameMatcher.SineMovement);
    }
    protected override void Execute(List<InputEntity> entities)
    {
        var input = entities[entities.Count - 1];
        foreach(var sineMovement in _sineMovements)
        {
            var A = sineMovement.sineMovement.A;
            var B = sineMovement.sineMovement.B;
            var C = sineMovement.sineMovement.C;

            if (input.axisInput.value.y > 0)
            {
                if (A < MAX_A)
                {
                    A = A + Time.deltaTime;
                }
            }
            if (input.axisInput.value.y<0)
            {
                if (A > MIN_A)
                {
                    A = A - Time.deltaTime;
                }
            }
            if (input.axisInput.value.x<0)
            {
                if (B > MIN_B)
                {
                    B = B - Time.deltaTime;
                    C = -Time.time * Time.deltaTime + C;
                }
            }
            if (input.axisInput.value.x > 0)
            {
                if (B < MAX_B)
                {
                    B = B + Time.deltaTime;
                    C = Time.time * Time.deltaTime + C;
                }
            }

            sineMovement.ReplaceSineMovement(A, B, C, sineMovement.sineMovement.timeStarted);
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
