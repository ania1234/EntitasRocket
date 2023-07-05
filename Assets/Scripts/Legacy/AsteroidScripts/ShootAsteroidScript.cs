using UnityEngine;
using System.Collections;

public class ShootAsteroidScript : OnCollisionScript {


    public override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            {
                PersistentScript.instance.rocket.callIncreaseAmmo();
            }
        }
        Destroy(gameObject);

    }
}

