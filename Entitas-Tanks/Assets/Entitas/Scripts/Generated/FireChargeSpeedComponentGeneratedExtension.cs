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
        public FireChargeSpeedComponent fireChargeSpeed { get { return (FireChargeSpeedComponent)GetComponent(ComponentIds.FireChargeSpeed); } }

        public bool hasFireChargeSpeed { get { return HasComponent(ComponentIds.FireChargeSpeed); } }

        public Entity AddFireChargeSpeed(float newValue) {
            var component = CreateComponent<FireChargeSpeedComponent>(ComponentIds.FireChargeSpeed);
            component.value = newValue;
            return AddComponent(ComponentIds.FireChargeSpeed, component);
        }

        public Entity ReplaceFireChargeSpeed(float newValue) {
            var component = CreateComponent<FireChargeSpeedComponent>(ComponentIds.FireChargeSpeed);
            component.value = newValue;
            ReplaceComponent(ComponentIds.FireChargeSpeed, component);
            return this;
        }

        public Entity RemoveFireChargeSpeed() {
            return RemoveComponent(ComponentIds.FireChargeSpeed);
        }
    }

    public partial class Matcher {
        static IMatcher _matcherFireChargeSpeed;

        public static IMatcher FireChargeSpeed {
            get {
                if (_matcherFireChargeSpeed == null) {
                    var matcher = (Matcher)Matcher.AllOf(ComponentIds.FireChargeSpeed);
                    matcher.componentNames = ComponentIds.componentNames;
                    _matcherFireChargeSpeed = matcher;
                }

                return _matcherFireChargeSpeed;
            }
        }
    }
}
