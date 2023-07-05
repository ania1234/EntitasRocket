using Entitas;
using System.Collections.Generic;

public class ProcessLooseSystem : ReactiveSystem<GameEntity>
{
    public ProcessLooseSystem(Contexts contexts) : base(contexts.game)
    {

    }
    protected override void Execute(List<GameEntity> entities)
    {
        //throw new System.NotImplementedException();
    }

    protected override bool Filter(GameEntity entity)
    {
        return false;
        //throw new System.NotImplementedException();
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return null;
        //throw new System.NotImplementedException();
    }
}