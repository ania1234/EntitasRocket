using Entitas;
using System.Collections.Generic;

public class ProcessLooseSystem : ReactiveSystem<GameStateEntity>
{
    private Contexts _contexts;
    public ProcessLooseSystem(Contexts contexts) : base(contexts.gameState)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<GameStateEntity> entities)
    {
        var allGameEntities = _contexts.game.GetEntities();
        foreach (var e in allGameEntities)
        {
            e.Destroy();
        }
        var allInputEntities = _contexts.input.GetEntities();
        foreach (var e in allInputEntities)
        {
            e.Destroy();
        }
        var allGameStateEntities = _contexts.gameState.GetEntities();
        foreach (var e in allGameStateEntities)
        {
            e.Destroy();
        }
        if (PersistentScript.instance != null)
        {
            PersistentScript.instance.LoadLooseScene();
        }
    }

    protected override bool Filter(GameStateEntity entity)
    {
        return entity.isLooseGameState;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
    {
        return context.CreateCollector<GameStateEntity>(GameStateMatcher.LooseGameState);
    }
}