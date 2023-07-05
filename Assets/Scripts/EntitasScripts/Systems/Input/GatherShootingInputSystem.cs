using Entitas;
using UnityEngine;

public class GatherShootingInputSystem : IExecuteSystem
{
    private Contexts _contexts;

    public GatherShootingInputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _contexts.input.CreateEntity().isShootInput = true;
        }
    }
}
