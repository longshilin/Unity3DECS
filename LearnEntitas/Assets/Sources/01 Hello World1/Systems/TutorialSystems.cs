using Entitas;

namespace Sources._01_Hello_World1.Systems
{
/// <summary>
/// 第四步：整合所有System到一个功能Feature中
/// </summary>
public class TutorialSystems : Feature
{
    public TutorialSystems(Contexts contexts) : base("Tutorial Systems")
    {
        Add(new HelloWorldSystem(contexts)); // debug message
        Add(new LogMouseClickSystem(contexts)); // debug message
        Add(new DebugMessageSystem(contexts)); // print all debug message
        Add(new CleanupDebugMessageSystem(contexts)); // clean
    }
}
}