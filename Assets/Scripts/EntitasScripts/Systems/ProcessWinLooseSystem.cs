public class ProcessWinLooseSystem : Feature
{
    public ProcessWinLooseSystem(Contexts contexts)
    {
        //Add(new CheckLooseDueToHealthSystem(contexts));
        Add(new ProcessWinSystem(contexts));
        Add(new ProcessLooseSystem(contexts));
    }
}
