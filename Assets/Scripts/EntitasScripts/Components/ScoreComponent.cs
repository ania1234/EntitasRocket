using Entitas;
using Entitas.CodeGeneration.Attributes;

[Event(EventTarget.Self)]
public class ScoreComponent : IComponent
{
    public int score;
}
