using Entitas;
using System.Collections.Generic;

public class ProcessScaleInputSystem : ReactiveSystem<InputEntity>
{
    private IGroup<GameEntity> _scalableEntities;

    public ProcessScaleInputSystem(Contexts contexts) : base(contexts.input)
    {
        _scalableEntities = contexts.game.GetGroup(GameMatcher.Scale);
    }
    protected override void Execute(List<InputEntity> entities)
    {
        //more than one scale change in frame possible
        foreach (var entity in entities)
        {
            foreach (var scale in _scalableEntities)
            {
                scale.ReplaceScale(scale.scale.scale + entity.scaleInput.scaleChange);
            }
        }
    }

    protected override bool Filter(InputEntity entity)
    {
        return entity.hasSpeedInput;
    }

    protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context)
    {
        return context.CreateCollector<InputEntity>(InputMatcher.ScaleInput);
    }
}
