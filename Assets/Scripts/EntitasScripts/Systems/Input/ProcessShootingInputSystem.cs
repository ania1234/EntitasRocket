using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class ProcessShootingInputSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;
    public ProcessShootingInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<InputEntity> entities)
    {
        var player = _contexts.game.GetEntityWithId(Constants.PLAYER_ID);
        if (player.ammo.value > 0)
        {
            Debug.LogError("Shoot");
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.isShootInput;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector<InputEntity>(InputMatcher.ShootInput);
    }
}
