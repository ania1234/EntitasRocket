using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public class AmmoComponent : IComponent
{
    public int value;
}
