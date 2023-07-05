using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddSpeedInputCollisionHandler : PlayerCollisionHandler
{
    [SerializeField]
    private float _speedChange;

    protected override void OnCollisionLogic(GameEntity otherEntity)
    {
        var speedInput = Contexts.sharedInstance.input.CreateEntity();
        speedInput.AddSpeedInput(_speedChange);
    }
}
