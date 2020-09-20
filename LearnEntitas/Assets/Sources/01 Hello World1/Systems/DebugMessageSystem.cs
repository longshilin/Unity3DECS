using System.Collections;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources._01_Hello_World1.Systems
{
    /// <summary>
    /// 第二步：a system to print debug message
    /// </summary>
    public class DebugMessageSystem : ReactiveSystem<GameEntity>
    {
        public DebugMessageSystem(Contexts context) : base(context.game)
        {
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            // 只关心包含DebugMessageComponent组件的实体
            return context.CreateCollector(GameMatcher.InteractDemoDir);
        }

        /// <summary>
        /// 筛选GameEntity
        /// </summary>
        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractDemoDir;
        }

        /// <summary>
        /// 执行GameEntity
        /// </summary>
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                Debug.Log(e.interactDemoDir.Rotation);
            }
        }
    }
}