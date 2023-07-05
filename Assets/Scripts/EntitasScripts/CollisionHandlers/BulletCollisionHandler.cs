using Entitas.Unity;
using UnityEngine;

public class BulletCollisionHandler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        var otherEntity = collision.collider.gameObject.GetEntityLink()?.entity as GameEntity;
        if (otherEntity != null)
        {
            if (otherEntity.isAsteroid)
            {
                otherEntity.isDestroyed = true;
                ((GameEntity)this.gameObject.GetEntityLink().entity).isDestroyed = true;
            }
        }
    }
}
