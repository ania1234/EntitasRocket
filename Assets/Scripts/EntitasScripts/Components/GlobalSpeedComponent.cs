using Entitas;
using Entitas.CodeGeneration.Attributes;

[Unique, Cleanup(CleanupMode.DestroyEntity), Event(EventTarget.Any)]
public class GlobalSpeedComponent : IComponent
{
    public float globalSpeed;
}
