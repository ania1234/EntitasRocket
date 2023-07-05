using Entitas;

public class CheckLooseDueToHealthSystem : IExecuteSystem
{
    private Contexts _contexts;
    public CheckLooseDueToHealthSystem(Contexts contexts)
    {
        _contexts = contexts;
    }
    public void Execute()
    {
        var player = _contexts.game.GetEntityWithId(Constants.PLAYER_ID);
        if (player==null || player.health.value <= 0)
        {
            _contexts.gameState.CreateEntity().isLooseGameState = true;
        }
    }
}
