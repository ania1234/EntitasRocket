using Entitas;
using System.Collections.Generic;
using UnityEngine;

public class LogHealthSystem : ReactiveSystem<GameEntity>
{
    readonly IGroup<GameEntity> _healthComponents;
    public LogHealthSystem(Contexts contexts):base(contexts.game)
    {
        _healthComponents = contexts.game.GetGroup(GameMatcher.Health);
    }

    protected override void Execute(List<GameEntity> entities)
    {
        foreach(var e in entities)
        {
            Debug.Log(e.health.value);
        }
    }

    protected override bool Filter(GameEntity entity)
    {
        return entity.hasHealth;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector<GameEntity>(GameMatcher.Health);
    }

}
