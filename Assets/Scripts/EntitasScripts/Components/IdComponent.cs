using Entitas;
using Entitas.CodeGeneration.Attributes;

public class IdComponent : IComponent
{
    [PrimaryEntityIndexAttribute]
    public string id;
}
