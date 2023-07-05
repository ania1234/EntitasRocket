using Entitas.Unity;
using UnityEngine;

public abstract class PlayerCollisionHandler : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var otherEntity = collision.collider.gameObject.GetEntityLink()?.entity as GameEntity;
        if (otherEntity != null && otherEntity.hasId && otherEntity.id.id==Constants.PLAYER_ID)
        {
            OnCollisionLogic(otherEntity);
        }
        (gameObject.GetEntityLink().entity as GameEntity).isDestroyed = true;
    }

    protected abstract void OnCollisionLogic(GameEntity otherEntity);
}
