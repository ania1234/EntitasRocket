using Entitas;
using Entitas.CodeGeneration.Attributes;

[Input, Cleanup(CleanupMode.DestroyEntity)]
public class ShootInputComponent : IComponent
{

}
