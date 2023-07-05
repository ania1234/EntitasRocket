using Entitas.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackWallCollisionHandler : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
            var otherEntity = collision.collider.gameObject.GetEntityLink()?.entity as GameEntity;
            if (otherEntity != null )
            {
                if (otherEntity.hasId)
                {
                    if (otherEntity.id.id == Constants.PLAYER_ID)
                    {
                        Contexts.sharedInstance.gameState.CreateEntity().isWinGameState = true;
                    }
                }
                if (collision.collider.CompareTag(Constants.Tags.Gold))
                {
                    Debug.LogError("LOOSE");
                    Contexts.sharedInstance.gameState.CreateEntity().isLooseGameState = true;
                }
                otherEntity.isDestroyed = true;
            }
    }
}
