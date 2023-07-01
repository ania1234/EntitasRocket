using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Event(EventTarget.Self), Cleanup(CleanupMode.DestroyEntity)]
public class DestroyedComponent : IComponent
{

}
