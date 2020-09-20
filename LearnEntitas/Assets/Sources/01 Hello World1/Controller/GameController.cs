using System.Collections;
using System.Collections.Generic;
using Entitas;
using Sources._01_Hello_World1.Components;
using UnityEngine;
using Sources._01_Hello_World1.Systems;

namespace Sources._01_Hello_World1.Controller
{
    /// <summary>
    /// 第五步：全部脚本放在一起整合
    /// </summary>
    public class GameController : MonoBehaviour
    {
        private Entitas.Systems _system;

        void Start()
        {
            // 获取一个contexts的引用
            var contexts = Contexts.sharedInstance;

            // 通过创建单个功能来创建系统
            _system = new Feature("Systems").Add(new TutorialSystems(contexts));

            // 所有System初始化
            _system.Initialize();
        }

        void Update()
        {
            // 在最后一帧触发的所有IExecuteSystems和ReactiveSystems上调用Execute()
            _system.Execute();

            // 在所有ICleanupSystems上调用cleanup()
            _system.Cleanup();
            
        }
    }
}