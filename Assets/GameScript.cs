using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;


public class GameScript : MonoBehaviour {


	string Greeting = "hello, DUDE";
    float speed = 1.0f;
    public Rigidbody2D greenAsteroid;
    public Rigidbody2D redAsteroid;
    public float A;
    public float B;
    public float C;
    public UpdateScoreScript score;
    public SineRenderingScript sine;
 
    bool coroutineStarted = false;
    bool hit;
    private Touch touch;
    int health = 3;

    private const float MaxA = 3.0f;
    private const float MinA = -3.0f;
    private const float MaxB = 2.0f;
    private const float MinB = 0.2f;
    private const float StepA = 0.1f;
    private const float StepB = 0.025f;

    float duration = 0;
    float sineTimeToSubstract = 0;
    float sineTimeToSubstract2 = 0;

    int lastCount;
    int framesSkipped = 0;
	// Use this for initialization
	void Start () {
        sineTimeToSubstract = Time.time;
        lastCount = sine.vertexCount - 8;
	}

    IEnumerator Do()
    {
        print("Do now");
        yield return new WaitForSeconds(2);
        print("Do 2 seconds later");
    }

    IEnumerator AsteroidSpawn()
    {
        while (true)
        {
            Rigidbody2D asteroid;
            float rnd = Random.Range(0, 2);
            if (rnd <= 0.5f)
            {
                asteroid = (Rigidbody2D)Instantiate(redAsteroid, new Vector3(Random.Range(2, 8), Random.Range(-4, 4), 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            else
            {
                asteroid = (Rigidbody2D)Instantiate(greenAsteroid, new Vector3(Random.Range(2, 8), Random.Range(-4, 4), 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            }
            asteroid.velocity = new Vector2(-1*speed, 0);
            yield return new WaitForSeconds(1);
        }
    }
	// Update is called once per frame
	void Update () {
        MoveCharacter();
        if (!coroutineStarted)
        {
            coroutineStarted = true;
            StartCoroutine(AsteroidSpawn());
        }
	}

    private void MoveCharacter()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            MoveAndroid();
        }
        else
        {
            MoveKeyboard();
        }

        AnimateRocket();
        AnimateSine();

        
    }

    private void MoveAndroid()
    {
        if (Input.touchCount >= 1)
        {
            Touch finger1 = Input.GetTouch(0);

            if (finger1.phase == TouchPhase.Began)
            {
                this.touch = finger1;
            }

            var distanceA = this.touch.position.y-finger1.position.y;
            var distanceB = this.touch.position.x - finger1.position.x;
            if (Mathf.Abs(distanceA) >= Mathf.Abs(distanceB))
            {
                if (Mathf.Sign(distanceA) > 0 && A < MaxA)
                {
                    A = A + StepA;
                }
                if (Mathf.Sign(distanceA) < 0 && A > MinA)
                {
                    A = A - StepA;
                }

            }
            else
            {
                if (Mathf.Sign(distanceB) > 0 && B < MaxB)
                {
                    B = B + StepB;
                    C = Time.time * StepB + C;
                }
                if (Mathf.Sign(distanceB) < 0 && B > MinA)
                {
                    B = B - StepB;
                    C = -Time.time * StepB + C;
                }
            }

            this.touch = finger1;
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }
    }

    private void MoveKeyboard()
    {
        if (Input.GetKey(KeyCode.W))
        {
            if (A < MaxA)
            {
                A = A + StepA;
                sine.UpdateA(A);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (A > MinA)
            {
                A = A - StepA;
                sine.UpdateA(A);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (B > MinB)
            {
                B = B - StepB;
                C = -Time.time * StepB + C;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (B < MaxB)
            {
                B = B + StepB;
                C = Time.time * StepB + C;
            }
        }

        if (Input.GetKey(KeyCode.Escape))
        {
            SceneManager.LoadScene("MenuScene", LoadSceneMode.Single);
        }
    }

    private void AnimateRocket()
    {
        transform.position = new Vector3(0, A * Mathf.Sin(B * Time.time - C));
    }

    private void AnimateSine()
    {
        if (framesSkipped >= 0.25f/Time.deltaTime)
        {
            lastCount++;
            sine.points.RemoveAt(0);
            sine.points.Add(new Vector3(((float)lastCount+sineTimeToSubstract) / 4.0f, 0));
            framesSkipped = 0;
        }
        else
        {
            framesSkipped++;
        }
            
        sine.lineRenderer.SetPositions(sine.points.Select((x) => Vector3.right * (x.x - Time.time) + Vector3.up * A * Mathf.Sin(B * (x.x) - C)).ToArray());
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "red")
        {
            if (!hit)
            {
                StartCoroutine(LoseHealth());
                Destroy(coll.gameObject);
            }
        }
        if (coll.gameObject.tag == "green")
        {
            score.UpdateScore(tag);
            Destroy(coll.gameObject);
        }
        
    }

    IEnumerator LoseHealth()
    {
        hit = true;
        health--;
        if (health == 2)
        {
            GameObject.Find("Health3").GetComponent<Image>().enabled = false;
        }
        if (health == 1)
        {
            GameObject.Find("Health2").GetComponent<Image>().enabled = false;
        }
        if (health == 0)
        {
            GameObject.Find("Health1").GetComponent<Image>().enabled = false;
            //todo: game over
        }
        gameObject.GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(2);
        gameObject.GetComponent<Animator>().enabled = false;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        hit = false;
    }
}
