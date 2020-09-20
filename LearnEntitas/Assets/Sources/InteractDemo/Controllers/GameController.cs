using System;
using Entitas;
using UnityEngine;

namespace InteractDemo
{
    /// <summary>
    /// 控制器：
    /// 这是一个交互的Entitas Demo项目， 旨在通过Entitas的API进行实体的创建交互和销毁操作，以达到熟悉使用Entitas的目的。
    /// 
    /// </summary>
    public class GameController : MonoBehaviour
    {
        private Systems _systems;
        private Contexts _contexts;

        private void Start()
        {
            _contexts = Contexts.sharedInstance;
            _systems = new Feature("Systems")
                .Add(new GameFeature(_contexts));
        }
    }

}