//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public InteractDemo.DirComponent interactDemoDir { get { return (InteractDemo.DirComponent)GetComponent(GameComponentsLookup.InteractDemoDir); } }
    public bool hasInteractDemoDir { get { return HasComponent(GameComponentsLookup.InteractDemoDir); } }

    public void AddInteractDemoDir(float newRotation) {
        var index = GameComponentsLookup.InteractDemoDir;
        var component = (InteractDemo.DirComponent)CreateComponent(index, typeof(InteractDemo.DirComponent));
        component.Rotation = newRotation;
        AddComponent(index, component);
    }

    public void ReplaceInteractDemoDir(float newRotation) {
        var index = GameComponentsLookup.InteractDemoDir;
        var component = (InteractDemo.DirComponent)CreateComponent(index, typeof(InteractDemo.DirComponent));
        component.Rotation = newRotation;
        ReplaceComponent(index, component);
    }

    public void RemoveInteractDemoDir() {
        RemoveComponent(GameComponentsLookup.InteractDemoDir);
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

    static Entitas.IMatcher<GameEntity> _matcherInteractDemoDir;

    public static Entitas.IMatcher<GameEntity> InteractDemoDir {
        get {
            if (_matcherInteractDemoDir == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.InteractDemoDir);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherInteractDemoDir = matcher;
            }

            return _matcherInteractDemoDir;
        }
    }
}