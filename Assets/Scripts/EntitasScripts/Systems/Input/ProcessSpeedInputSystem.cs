using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProcessSpeedInputSystem : ReactiveSystem<InputEntity>
{
    private Contexts _contexts;
    public ProcessSpeedInputSystem(Contexts contexts) : base(contexts.input)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<InputEntity> entities)
    {
        //more than one speed change in frame possible
        foreach (var entity in entities)
        {
            _contexts.game.ReplaceGlobalSpeed(_contexts.game.globalSpeed.globalSpeed + entity.speedInput.speedChange);
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
