﻿using UnityEngine;
using System.Collections;

public class SlowAsteroidScript : OnCollisionScript {

    public override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            {
                PersistentScript.instance.rocket.callDecreaseSpeed();
                Destroy(gameObject);
            }
        }
        if (coll.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }


    }
}

