using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeHealthCollisionHandler : PlayerCollisionHandler
{
    [SerializeField]
    private int _healthChange;
    protected override void OnCollisionLogic(GameEntity otherEntity)
    {
        otherEntity.ReplaceHealth(otherEntity.health.value + _healthChange);
    }
}
