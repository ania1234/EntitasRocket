using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Cleanup(CleanupMode.DestroyEntity)]
public class ScaleInputComponent : IComponent
{
    public float scaleChange;
}
