using UnityEngine;
using System.Collections;

public class GoldenAsteroidScript : OnCollisionScript {

    public override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            {
                PersistingScript.persistingScript.rocket.callSpecial(gameObject.tag);
                Destroy(gameObject);
            }
        }

        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }

    }
}

