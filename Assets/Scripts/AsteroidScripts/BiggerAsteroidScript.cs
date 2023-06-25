using UnityEngine;
using System.Collections;

public class BiggerAsteroidScript : OnCollisionScript {


    public override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

                PersistingScript.persistingScript.rocket.callIncreaseSize();
                Destroy(gameObject);
        }
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }
}

