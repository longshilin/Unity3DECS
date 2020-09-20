//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    static readonly RequiresWorldState requiresWorldStateComponent = new RequiresWorldState();

    public bool isRequiresWorldState {
        get { return HasComponent(GameComponentsLookup.RequiresWorldState); }
        set {
            if (value != isRequiresWorldState) {
                var index = GameComponentsLookup.RequiresWorldState;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : requiresWorldStateComponent;

                    AddComponent(index, component);
                } else {
                    RemoveComponent(index);
                }
            }
        }
    }
}

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentMatcherApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public sealed partial class GameMatcher {

    static Entitas.IMatcher<GameEntity> _matcherRequiresWorldState;

    public static Entitas.IMatcher<GameEntity> RequiresWorldState {
        get {
            if (_matcherRequiresWorldState == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.RequiresWorldState);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherRequiresWorldState = matcher;
            }

            return _matcherRequiresWorldState;
        }
    }
}
