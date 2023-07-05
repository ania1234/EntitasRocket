public class RootSystem : Feature
{
    public RootSystem(Contexts contexts)
    {
        //spawn entities
        Add(new SetGlobalsSystem(contexts));
        Add(new SpawnPlayerSystem(contexts));
        Add(new SpawnAsteroidSystem(contexts));
        
        //generate views
        Add(new AddViewSystem(contexts));

        //process movement
        Add(new ProcessSineMovementSystem(contexts));
        Add(new ProcessLinearMovementSystem(contexts));

        //gather input
        Add(new GatherAxisInputSystem(contexts));
        Add(new GatherShootingInputSystem(contexts));

        //process input
        Add(new ProcessAxisInputSystem(contexts));
        Add(new ProcessShootingInputSystem(contexts));
        //Those two inputs are gathered from physics2D collisions, rather than user input, but still seemed better suited for Input category
        Add(new ProcessSpeedInputSystem(contexts));
        Add(new ProcessScaleInputSystem(contexts));

        //process win-loose conditions
        Add(new ProcessWinLooseSystem(contexts));
        //process events (generated)
        Add(new GameEventSystems(contexts));
        //destroy
        Add(new DestroyEntitesSytem(contexts));
        Add(new DestroyAxisInputSystem(contexts));
        Add(new DestroySpeedInputSystem(contexts));
        Add(new DestroyScaleInputSystem(contexts));
        Add(new DestroyShootingInputSystem(contexts));
    }
}
