using Entitas;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : View
{
    [SerializeField]
    private SineRenderingScript _sine;

    private void Update()
    {
        _sine.UpdatePoints(_linkedEntity.sineMovement.A, _linkedEntity.sineMovement.B, _linkedEntity.sineMovement.C);
    }
}
