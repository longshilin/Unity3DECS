//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.EventSystemGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed class AnyBurstModeEventSystem : Entitas.ReactiveSystem<InputEntity> {

    readonly Entitas.IGroup<InputEntity> _listeners;
    readonly System.Collections.Generic.List<InputEntity> _entityBuffer;
    readonly System.Collections.Generic.List<IAnyBurstModeListener> _listenerBuffer;

    public AnyBurstModeEventSystem(Contexts contexts) : base(contexts.input) {
        _listeners = contexts.input.GetGroup(InputMatcher.AnyBurstModeListener);
        _entityBuffer = new System.Collections.Generic.List<InputEntity>();
        _listenerBuffer = new System.Collections.Generic.List<IAnyBurstModeListener>();
    }

    protected override Entitas.ICollector<InputEntity> GetTrigger(Entitas.IContext<InputEntity> context) {
        return Entitas.CollectorContextExtension.CreateCollector(
            context, Entitas.TriggerOnEventMatcherExtension.Added(InputMatcher.BurstMode)
        );
    }

    protected override bool Filter(InputEntity entity) {
        return entity.isBurstMode;
    }

    protected override void Execute(System.Collections.Generic.List<InputEntity> entities) {
        foreach (var e in entities) {
            
            foreach (var listenerEntity in _listeners.GetEntities(_entityBuffer)) {
                _listenerBuffer.Clear();
                _listenerBuffer.AddRange(listenerEntity.anyBurstModeListener.value);
                foreach (var listener in _listenerBuffer) {
                    listener.OnAnyBurstMode(e);
                }
            }
        }
    }
}
