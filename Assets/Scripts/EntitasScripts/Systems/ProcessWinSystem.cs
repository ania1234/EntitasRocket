using Entitas;
using System.Collections.Generic;

public class ProcessWinSystem : ReactiveSystem<GameEntity>
{
    public ProcessWinSystem(Contexts contexts):base(contexts.game)
    {

    }
    protected override void Execute(List<GameEntity> entities)
    {
        throw new System.NotImplementedException();
    }

    protected override bool Filter(GameEntity entity)
    {
        throw new System.NotImplementedException();
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        throw new System.NotImplementedException();
    }
}
