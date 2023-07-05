//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameEntity {

    public LinearSpeedMovementComponent linearSpeedMovement { get { return (LinearSpeedMovementComponent)GetComponent(GameComponentsLookup.LinearSpeedMovement); } }
    public bool hasLinearSpeedMovement { get { return HasComponent(GameComponentsLookup.LinearSpeedMovement); } }

    public void AddLinearSpeedMovement(float newSpeed) {
        var index = GameComponentsLookup.LinearSpeedMovement;
        var component = (LinearSpeedMovementComponent)CreateComponent(index, typeof(LinearSpeedMovementComponent));
        component.speed = newSpeed;
        AddComponent(index, component);
    }

    public void ReplaceLinearSpeedMovement(float newSpeed) {
        var index = GameComponentsLookup.LinearSpeedMovement;
        var component = (LinearSpeedMovementComponent)CreateComponent(index, typeof(LinearSpeedMovementComponent));
        component.speed = newSpeed;
        ReplaceComponent(index, component);
    }

    public void RemoveLinearSpeedMovement() {
        RemoveComponent(GameComponentsLookup.LinearSpeedMovement);
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

    static Entitas.IMatcher<GameEntity> _matcherLinearSpeedMovement;

    public static Entitas.IMatcher<GameEntity> LinearSpeedMovement {
        get {
            if (_matcherLinearSpeedMovement == null) {
                var matcher = (Entitas.Matcher<GameEntity>)Entitas.Matcher<GameEntity>.AllOf(GameComponentsLookup.LinearSpeedMovement);
                matcher.componentNames = GameComponentsLookup.componentNames;
                _matcherLinearSpeedMovement = matcher;
            }

            return _matcherLinearSpeedMovement;
        }
    }
}