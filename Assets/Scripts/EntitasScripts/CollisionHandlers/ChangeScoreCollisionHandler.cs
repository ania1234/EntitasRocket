using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScoreCollisionHandler : PlayerCollisionHandler
{
    [SerializeField]
    private int _scoreChange;
    protected override void OnCollisionLogic(GameEntity otherEntity)
    {
        otherEntity.ReplaceScore(otherEntity.score.score + _scoreChange);
    }
}
