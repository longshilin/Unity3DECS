using Entitas;

namespace InteractDemo
{
    /// <summary>
    /// 鼠标组件（存储鼠标点击类型）
    /// </summary>
    public class MouseComponent:IComponent
    {
        public Enums.MouseButton MouseButton;
        public Enums.MouseButtonEvent MouseButtonEvent;
    }
}