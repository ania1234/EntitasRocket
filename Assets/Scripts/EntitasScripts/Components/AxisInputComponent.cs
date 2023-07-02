using Entitas;
using Entitas.CodeGeneration.Attributes;
using UnityEngine;

[Input, Unique, Cleanup(CleanupMode.DestroyEntity)]
public class AxisInputComponent : IComponent
{
    public Vector2Int value;
}
