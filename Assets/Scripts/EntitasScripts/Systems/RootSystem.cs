using Entitas;

public class RootSystem : Feature
{
    public RootSystem(Contexts contexts)
    {
        Add(new SpawnPlayerSystem(contexts));
        Add(new LogHealthSystem(contexts));
    }
}
