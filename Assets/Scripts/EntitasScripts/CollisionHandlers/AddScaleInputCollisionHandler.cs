using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScaleInputCollisionHandler : PlayerCollisionHandler
{
    [SerializeField]
    private float _scaleChange;
    protected override void OnCollisionLogic(GameEntity otherEntity)
    {
        var scaleInput = Contexts.sharedInstance.input.CreateEntity();
        scaleInput.AddScaleInput(_scaleChange);
    }
}
