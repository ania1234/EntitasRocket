using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public class ScaleComponent : IComponent
{
    public float scale;
}
