//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by Entitas.CodeGeneration.Plugins.ComponentEntityApiGenerator.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
public partial class GameStateEntity {

    static readonly LooseGameStateComponent looseGameStateComponent = new LooseGameStateComponent();

    public bool isLooseGameState {
        get { return HasComponent(GameStateComponentsLookup.LooseGameState); }
        set {
            if (value != isLooseGameState) {
                var index = GameStateComponentsLookup.LooseGameState;
                if (value) {
                    var componentPool = GetComponentPool(index);
                    var component = componentPool.Count > 0
                            ? componentPool.Pop()
                            : looseGameStateComponent;

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
public sealed partial class GameStateMatcher {

    static Entitas.IMatcher<GameStateEntity> _matcherLooseGameState;

    public static Entitas.IMatcher<GameStateEntity> LooseGameState {
        get {
            if (_matcherLooseGameState == null) {
                var matcher = (Entitas.Matcher<GameStateEntity>)Entitas.Matcher<GameStateEntity>.AllOf(GameStateComponentsLookup.LooseGameState);
                matcher.componentNames = GameStateComponentsLookup.componentNames;
                _matcherLooseGameState = matcher;
            }

            return _matcherLooseGameState;
        }
    }
}
