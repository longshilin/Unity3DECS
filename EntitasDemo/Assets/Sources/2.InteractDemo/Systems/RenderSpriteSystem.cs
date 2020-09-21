using System;
using UnityEngine;
using System.Collections;
using Entitas;
using System.Collections.Generic;

namespace InteractDemo
{
    /// <summary>
    /// 针对执行AddViewSystem的实体，添加SpriteRenderer，指定贴图资源
    /// </summary>
    public class RenderSpriteSystem : ReactiveSystem<GameEntity>
    {
        public RenderSpriteSystem(Contexts contexts) : base(contexts.game)
        {
        }

        protected override void Execute(List<GameEntity> entities)
        {
            foreach (var gameEntity in entities)
            {
                Transform trans = gameEntity.interactDemoView.ViewTransform; // 由于在RenderSpriteSystem之前，已经执行了AddViewSystem，所以ViewTransform已经有值了。
                SpriteRenderer sr = trans.GetComponent<SpriteRenderer>();
                if (sr == null)
                    sr = trans.gameObject.AddComponent<SpriteRenderer>();
                sr.sprite = Resources.Load<Sprite>(gameEntity.interactDemoSprite.SpriteName);
            }
        }

        protected override bool Filter(GameEntity entity)
        {
            return entity.hasInteractDemoSprite && entity.hasInteractDemoView;
        }

        protected override ICollector<GameEntity> GetTrigger(IContext<GameEntity> context)
        {
            return context.CreateCollector(GameMatcher.InteractDemoSprite);
        }
    }
}