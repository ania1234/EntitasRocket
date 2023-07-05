using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEntitesSytem : ICleanupSystem
{

    readonly IGroup<GameEntity> _group;
    readonly List<GameEntity> _buffer = new List<GameEntity>();

    public DestroyEntitesSytem(Contexts contexts)
    {
        _group = contexts.game.GetGroup(GameMatcher.Destroyed);
    }

    public void Cleanup()
    {
        foreach (var e in _group.GetEntities(_buffer))
        {
            e.Destroy();
        }
    }
}