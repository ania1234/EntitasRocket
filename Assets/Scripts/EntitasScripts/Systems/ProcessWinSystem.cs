using Entitas;
using System.Collections.Generic;

public class ProcessWinSystem : ReactiveSystem<GameStateEntity>
{
    private Contexts _contexts;
    public ProcessWinSystem(Contexts contexts):base(contexts.gameState)
    {
        _contexts = contexts;
    }
    protected override void Execute(List<GameStateEntity> entities)
    {

        if (PersistentScript.instance != null)
        {
            PersistentScript.instance.NoteMaxLevel();
            PersistentScript.instance.NoteHighScore();
            PersistentScript.instance.Save();
        }
        var allGameEntities = _contexts.game.GetEntities();
        foreach (var e in allGameEntities)
        {
            e.isDestroyed = true;
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
            PersistentScript.instance.LoadWinScene();
        }
    }

    protected override bool Filter(GameStateEntity entity)
    {
        return entity.isWinGameState;
    }

    protected override ICollector<GameStateEntity> GetTrigger(IContext<GameStateEntity> context)
    {
        return context.CreateCollector<GameStateEntity>(GameStateMatcher.WinGameState);
    }
}
