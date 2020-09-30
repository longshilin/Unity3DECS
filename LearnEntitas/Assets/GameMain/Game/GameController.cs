using Entitas;

public class GameController
{
    private readonly Systems _system;
    private readonly Contexts _contexts;

    public GameController(Contexts contexts)
    {
        _contexts = contexts;
        _system = new GameSystems(contexts);
    }

    public void Initialize()
    {
        _system.Initialize();
    }

    public void Execute()
    {
        _system.Execute();
        _system.Cleanup();
    }
}