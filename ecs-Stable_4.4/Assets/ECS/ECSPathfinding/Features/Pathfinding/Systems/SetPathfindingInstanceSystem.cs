﻿
namespace ME.ECS.Pathfinding.Features.Pathfinding.Systems {

    #pragma warning disable
    using Components; using Modules; using Systems; using Markers;
    #pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class SetPathfindingInstanceSystem : ISystemFilter {

        private PathfindingFeature pathfindingFeature;
        
        public World world { get; set; }

        void ISystemBase.OnConstruct() {
            
            this.pathfindingFeature = this.world.GetFeature<PathfindingFeature>();

        }
        
        void ISystemBase.OnDeconstruct() {}
        
        bool ISystemFilter.jobs => false;
        int ISystemFilter.jobsBatchCount => 64;
        Filter ISystemFilter.filter { get; set; }
        Filter ISystemFilter.CreateFilter() {
            
            return Filter.Create("Filter-SetPathfindingInstanceSystem")
                         .WithStructComponent<IsPathfinding>()
                         .WithoutStructComponent<HasPathfindingInstance>()
                         .Push();
            
        }

        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime) {

            var instance = this.pathfindingFeature.GetInstance();
            if (instance != null) {

                var pInstance = entity.AddComponent<PathfindingInstance>();
                pInstance.pathfinding = instance.Clone();

                entity.SetData(new HasPathfindingInstance());
                entity.SetData(new BuildAllGraphs());

            }

        }
    
    }
    
}