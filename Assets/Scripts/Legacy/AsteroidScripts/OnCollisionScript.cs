using UnityEngine;
using System.Collections;

public abstract class OnCollisionScript : MonoBehaviour {

    internal bool moving;
    internal int A;
    void Start()
    {
    }
    void Update()
    {
        if (moving)
        {
            transform.Translate(new Vector3(0, A*Mathf.Sin(Time.time) - A*Mathf.Sin(Time.time - Time.deltaTime)));
        }
    }
    void OnDestroy()
    {
    }

    public abstract void OnCollisionEnter2D(Collision2D coll);


}
