using UnityEngine;
using System.Collections;
using Entitas;

namespace InteractDemo
{
    /// <summary>
    /// 表现层组件
    /// </summary>
    public class ViewComponent : IComponent
    {
        public Transform ViewTransform;
    }
}