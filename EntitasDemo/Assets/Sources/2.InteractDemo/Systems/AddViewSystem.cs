using System;
using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;
using Entitas.Unity;

namespace InteractDemo
{
    /// <summary>
    /// 对于符合Filter筛选条件的实体创建view节点
    /// </summary>
    public class AddViewSystem : ReactiveSystem<GameEntity>
    {
        private Transform _parenTransform;
        private Contexts _contexts;

        public AddViewSystem(Contexts contexts) : base(contexts.game)
        {
            _contexts = contexts;
            _parenTransform = new GameObject("ViewParent").transform;
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var entity in entities)
            {
                GameObject go = new GameObject("View");
                go.transform.SetParent(_parenTransform);
                go.Link(entity);
                entity.AddInteractDemoView(go.transform); // add view comp
                entity.isInteractDemoMoveComplete = true; // movecomplete  comp, 没有属性字段，因此用的是isInteractDemoMoveComplete，有属性字段的用的是has...
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractDemoSprite && !entity.hasInteractDemoView; // 同时包含sprite和view组件的实体
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractDemoSprite); // 包含Sprite组件时触发
        }
    }
}