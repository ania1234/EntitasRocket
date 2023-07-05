using UnityEngine;

public class ChangeAmmoCollisionHandler : PlayerCollisionHandler
{
    [SerializeField]
    private int _ammoChange = 1;
    protected override void OnCollisionLogic(GameEntity otherEntity)
    {
        otherEntity.ReplaceAmmo(otherEntity.ammo.value + _ammoChange);
    }
}
