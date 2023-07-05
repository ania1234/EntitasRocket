using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public class HealthComponent : IComponent
{
    public int value;
}
