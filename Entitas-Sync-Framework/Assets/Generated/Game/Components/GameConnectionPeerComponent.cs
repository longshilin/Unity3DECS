//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public ConnectionPeer connectionPeer { get { return (ConnectionPeer)GetComponent(GameComponentsLookup.ConnectionPeer); } }
    public bool hasConnectionPeer { get { return HasComponent(GameComponentsLookup.ConnectionPeer); } }

    public void AddConnectionPeer(ENet.Peer newValue) {
        var index = GameComponentsLookup.ConnectionPeer;
        var component = (ConnectionPeer)CreateComponent(index, typeof(ConnectionPeer));
        component.Value = newValue;
        AddComponent(index, component);
    }

    public void ReplaceConnectionPeer(ENet.Peer newValue) {
        var index = GameComponentsLookup.ConnectionPeer;
        var component = (ConnectionPeer)CreateComponent(index, typeof(ConnectionPeer));
        component.Value = newValue;
        ReplaceComponent(index, component);
    }

    public void RemoveConnectionPeer() {
        RemoveComponent(GameComponentsLookup.ConnectionPeer);
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

    static Entitas.IMatcher<GameEntity> _matcherConnectionPeer;

    public static Entitas.IMatcher<GameEntity> ConnectionPeer {
        get {
            if (_matcherConnectionPeer == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.ConnectionPeer);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherConnectionPeer = matcher;
            }

            return _matcherConnectionPeer;
        }
    }
}
