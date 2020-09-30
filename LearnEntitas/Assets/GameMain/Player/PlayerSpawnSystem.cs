using System.Collections.Generic;
using Entitas;

public class PlayerSpawnSystem : ReactiveSystem<GameEntity>
{
    private readonly Contexts _contexts;

    public PlayerSpawnSystem(Contexts contexts) : base(contexts.game)
    {
        _contexts = contexts;
    }

    protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
    {
        return context.CreateCollector(GameMatcher.GameStarted);
        throw new System.NotImplementedException();
    }

    protected override bool Filter(GameEntity entity)
    {
        throw new System.NotImplementedException();
    }

    protected override void Execute(List<GameEntity> entities)
    {
        throw new System.NotImplementedException();
    }
}