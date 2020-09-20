using Entitas;

namespace Sources._01_Hello_World1.Components
{
    /// <summary>
    /// a component to hold the message data
    /// </summary>
    [Game]
    public class DebugMessageComponent : IComponent
    {
        public string message;
    }
}