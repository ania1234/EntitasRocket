using UnityEngine;
using System.Collections;

public class TurboAsteroidScript : OnCollisionScript{

    public override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            {
                PersistentScript.instance.rocket.callIncreaseSpeed();
                Destroy(gameObject);
            }
        }
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

    }
}

