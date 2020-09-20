using Entitas;
using UnityEngine;

namespace Sources._01_Hello_World1.Systems
{
    public class LogMouseClickSystem : IExecuteSystem
    {
        readonly GameContext _context;

        public LogMouseClickSystem(Contexts contexts)
        {
            _context = contexts.game;
        }

        public void Execute()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _context.CreateEntity().AddSources_01_Hello_World1ComponentsDebugMessage("Left Mouse Button Clicked");
            }

            if (Input.GetMouseButtonDown(1))
            {
                _context.CreateEntity().AddSources_01_Hello_World1ComponentsDebugMessage("Right Mouse Button Clicked");
            }
        }
    }
}