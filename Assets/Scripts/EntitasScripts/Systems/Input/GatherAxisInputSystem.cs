using Entitas;
using UnityEngine;

public class GatherAxisInputSystem : IExecuteSystem
{
    private Contexts _contexts;

    public GatherAxisInputSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        Vector2Int result = Vector2Int.zero;
        if (Input.GetKey(KeyCode.W))
        {
            result.y += 1;
        }
        if (Input.GetKey(KeyCode.S))
        {
            result.y -= 1;
        }
        if (Input.GetKey(KeyCode.A))
        {
            result.x -= 1;
        }
        if (Input.GetKey(KeyCode.D))
        {
            result.x += 1;
        }

        if(result.x!=0 || result.y != 0)
        {
            _contexts.input.CreateEntity().AddAxisInput(result);
        }
    }
}
