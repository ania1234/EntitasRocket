using UnityEngine;
using System.Collections;

public class OnCollisionScript : MonoBehaviour {

    bool hit = false;
    public UpdateScoreScript ScoreText;
    void Start()
    {
    }
    void Update()
    {
        //Fading();
    }
    void OnDestroy()
    {
    }
    //void Fading()
    //{
    //    for (float f = 1.0f; f >= 0; f -= 0.1f)
    //    {
    //        var colour = renderer.material.color;
    //        colour.a = f;
    //        renderer.material.color = colour;
    //    }
    //}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            ScoreText.UpdateScore(tag);
        }
        hit = true;
        Destroy(gameObject);
    }
}
