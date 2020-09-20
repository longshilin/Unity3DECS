using Entitas;

namespace Sources._01_Hello_World1.Systems
{
    public class CleanupDebugMessageSystem : ICleanupSystem
    {
        readonly GameContext _context;
        readonly IGroup<GameEntity> _debugMessages;

        public CleanupDebugMessageSystem(Contexts contexts)
        {
            _context = contexts.game;
            _debugMessages = _context.GetGroup(GameMatcher.Sources_01_Hello_World1ComponentsDebugMessage);
        }

        public void Cleanup()
        {
            // group.GetEntities() always gives us an up to date list
            foreach (var e in _debugMessages.GetEntities())
            {
                e.Destroy();
            }
        }
    }
}