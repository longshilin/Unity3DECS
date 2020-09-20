using System.Collections;
using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using UnityEngine;

namespace Sources.InteractDemo.Systems
{
    /// <summary>
    /// system：a system to print debug message
    /// </summary>
    public class AddViewSystem : ReactiveSystem<GameEntity>
    {
        private Contexts _contexts;
        private Transform _parentTransform;

        public AddViewSystem(Contexts context) : base(context.game)
        {
            _contexts = context;
            _parentTransform = new GameObject("ViewParent").transform;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            // 只关心包含DebugMessageComponent组件的实体
            return context.CreateCollector(GameMatcher.InteractDemoSprite);
        }

        /// <summary>
        /// 筛选GameEntity
        /// </summary>
        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractDemoSprite && !entity.hasInteractDemoView;
        }

        /// <summary>
        /// 执行GameEntity
        /// </summary>
        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var e in entities)
            {
                // 对entity进行操作
                GameObject go = new GameObject("View");
                go.transform.SetParent(_parentTransform);
                go.Link(e); // Todo ??
                e.AddInteractDemoView(go.transform);
                e.isInteractDemoMoveComplete = true; // Todo ??
                // e.hasInteractDemoSprite
            }
        }
    }
}