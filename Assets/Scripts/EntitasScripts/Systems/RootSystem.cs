using Entitas;

public class RootSystem : Feature
{
    public RootSystem(Contexts contexts)
    {
        //spawn entities
        Add(new SpawnPlayerSystem(contexts));


        //generate views
        Add(new AddViewSystem(contexts));

        //gather input
        Add(new GatherAxisInputSystem(contexts));
        //Add(new GatherShootingInputSystem(contexts));

        //process input
        Add(new ProcessAxisInputSystem(contexts));
        //Add(new ProcessShootingSystem(contexts));

        //process collisions

        //process events (generated)
        Add(new GameEventSystems(contexts));

        //destroy input
        Add(new DestroyAxisInputSystem(contexts));
        //Add(new DestroyShootingInputSystem(contexts));

        //process win-loose conditions
        Add(new LogHealthSystem(contexts));
    }
}
