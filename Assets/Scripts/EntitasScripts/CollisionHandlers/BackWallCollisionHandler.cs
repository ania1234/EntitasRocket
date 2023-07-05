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
                        if (PersistentScript.instance != null)
                        {
                            if (PersistentScript.instance.maxLevelNumber == PersistentScript.instance.currentLevelNumber)
                            {
                                PersistentScript.instance.maxLevelNumber = Mathf.Min(PersistentScript.instance.maxLevelNumber + 1, Constants.MAX_LEVELS);
                            }
                            PersistentScript.instance.highScores[PersistentScript.instance.currentLevelNumber - 1] =
                            Mathf.Max(PersistentScript.instance.highScores[PersistentScript.instance.currentLevelNumber - 1], PersistentScript.instance.score.CalculateScore());
                            PersistentScript.instance.Save();
                        }
                        SceneManager.LoadScene(Constants.SceneNames.WinScene, LoadSceneMode.Single);
                        return;
                    }
                    if(otherEntity.id.id == Constants.Tags.Gold)
                    {
                        SceneManager.LoadScene(Constants.SceneNames.LooseScene, LoadSceneMode.Single);
                    }
                }
                otherEntity.isDestroyed = true;
            }
    }
}
