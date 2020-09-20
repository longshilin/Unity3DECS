using Entitas;

namespace Sources._01_Hello_World1.Systems
{
    /// <summary>
    /// 第三步：a system to generate the "Hello World!" message
    /// </summary>
    public class HelloWorldSystem : IInitializeSystem
    {
        // 总是方便参考上下文context
        // 我们将与之互动
        private GameContext _context;

        public HelloWorldSystem(Contexts contexts)
        {
            // 从构造器中获取上下文context
            _context = contexts.game;
        }

        public void Initialize()
        {
            // 创建一个实体，并给它一个带有文本“Hello World!”的DebugMessageComponent作为其数据。
            _context.CreateEntity().AddSources_01_Hello_World1ComponentsDebugMessage("Hello World!");
        }
    }
}