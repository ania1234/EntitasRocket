using UnityEngine;
using System.Collections;

public class GameScript : MonoBehaviour {


	string Greeting = "hello, DUDE";
    float speed = 1.0f;
    public Rigidbody2D greenAsteroid;
    public Rigidbody2D redAsteroid;
    public float A;
    public float B;
 
    bool coroutineStarted = false;
    public SineRenderingScript sine;

	// Use this for initialization
	void Start () {
		print (Greeting);
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
            Rigidbody2D asteroid = (Rigidbody2D)Instantiate(redAsteroid, new Vector3(Random.Range(2, 8), Random.Range(-4, 4), 0), Quaternion.Euler(new Vector3(0, 0, 0)));
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

    void OnGUI()
    {
       // GUI.Box(new Rect(10, 10, 100, 90), "Score: " + Time.time);
    }

    private void MoveCharacter()
    {
        //gameObject.GetComponent<Rigidbody2D>().rotation = Mathf.Cos(Time.time);
        //transform.Rotate(Vector3.back, Mathf.Atan(Mathf.Cos(Time.time)));
        
        //camera.MoveCamera(speed * Time.deltaTime);
        
        if (Input.GetKey(KeyCode.W))
        {
            if(A<3f){
                A = A+0.1f;
                sine.UpdateA(A);
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if(A>-3f){
                A = A- 0.1f;
                sine.UpdateA(A);
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (B > 0.2f)
            {
                B = B - 0.1f;
                sine.UpdateB(B);
                print("B: " + B.ToString());
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (B < 3f)
            {
                B = B + 0.1f;
                sine.UpdateB(B);
                print("B: " + B.ToString());
            }
        }
        transform.position = new Vector3(0, A * Mathf.Sin(B * Time.time));
        //transform.Translate(new Vector3(0, A * Mathf.Sin(B * Time.time) - A * Mathf.Sin(B * (Time.time - Time.deltaTime))));
        //if (Input.GetKey(KeyCode.W))
        //{
        //    transform.Translate(Vector3.up * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    transform.Translate(Vector3.down * speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.Q))
        //{
        //    transform.RotateAround(Vector3.back, speed * Time.deltaTime);
        //}
        //if (Input.GetKey(KeyCode.E))
        //{
        //    transform.RotateAround(Vector3.forward, speed * Time.deltaTime);
        //}
        //gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        //gameObject.GetComponent<Rigidbody2D>().rotation = 0;
    }
}
