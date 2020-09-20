//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGenerator.ComponentExtensionsGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace Entitas {
    public partial class Entity {
        public MoveSpeedComponent moveSpeed { get { return (MoveSpeedComponent)GetComponent(ComponentIds.MoveSpeed); } }

        public bool hasMoveSpeed { get { return HasComponent(ComponentIds.MoveSpeed); } }

        public Entity AddMoveSpeed(float newValue) {
            var component = CreateComponent<MoveSpeedComponent>(ComponentIds.MoveSpeed);
            component.value = newValue;
            return AddComponent(ComponentIds.MoveSpeed, component);
        }

        public Entity ReplaceMoveSpeed(float newValue) {
            var component = CreateComponent<MoveSpeedComponent>(ComponentIds.MoveSpeed);
            component.value = newValue;
            ReplaceComponent(ComponentIds.MoveSpeed, component);
            return this;
        }

        public Entity RemoveMoveSpeed() {
            return RemoveComponent(ComponentIds.MoveSpeed);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherMoveSpeed;

        public static IMatcher MoveSpeed {
            get {
                if (_matcherMoveSpeed == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.MoveSpeed);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherMoveSpeed = matcher;
                }

                return _matcherMoveSpeed;
            }
        }
    }
}
