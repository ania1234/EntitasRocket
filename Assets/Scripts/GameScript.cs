using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;


public class GameScript : MonoBehaviour {


    public Rigidbody2D greenAsteroid;
    public Rigidbody2D redAsteroid;
    public Rigidbody2D backWall;
    public float A;
    public float B;
    public float C;
    public UpdateScoreScript UI;
    public SineRenderingScript sine;
    public GameObject Background;
    
 
    bool coroutineStarted = false;
    bool hit;
    bool shooting = false;
    bool isClick;

    float size = 1.0f;
    public float speed;

    public const float MAX_A = 3.0f;
    public const float MIN_A = -3.0f;
    public const float MAX_B = 2.0f;
    public const float MIN_B = 0.2f;
    public const float MAX_SPEED = 15.0f;
    public const float MIN_SPEED = 1.0f;
    public const float MAX_HEALTH = 3.0f;
    public const float MIN_HEALTH = 0.0f;
    public const float MAX_SIZE = 3.0f;
    public const float MIN_SIZE = 0.5f;
    public const float MAX_AMMO = 3.0f;
    public const float MIN_AMMO = 0.5f;
    private Touch touch;

    float duration = 0;
    float sineTimeToSubstract = 0;

    int currentWave = 0;
	// Use this for initialization
	void Start () {
        Background.gameObject.GetComponent<Animator>().enabled = true;
        Background.gameObject.GetComponent<Animator>().speed = speed;
        PersistingScript.persistingScript.SetRocket(this);
        PersistingScript.persistingScript.score.ResetScore();
        UI.InitializeDisplay();
        sineTimeToSubstract = Time.time;
        LevelsContainer.LoadLevel(PersistingScript.persistingScript.currentLevelNumber);
	}

    IEnumerator AsteroidSpawn()
    {  
        while (currentWave<LevelsContainer.width)
        {
                LevelsContainer.getAsteroids(currentWave);
                currentWave++;
                yield return new WaitForSeconds(1/speed);
        }

        while (currentWave >= LevelsContainer.width && currentWave < LevelsContainer.width + 3)
        {
            currentWave++;
            yield return new WaitForSeconds(1/speed);
        }

        if (currentWave == LevelsContainer.width+3)
        {
            Rigidbody2D backWall2;
            backWall2 = (Rigidbody2D)Instantiate(backWall, new Vector3(14, 0, 0), Quaternion.Euler(new Vector3(0, 0, 0)));
            backWall2.velocity = new Vector2(-1 * speed, 0);
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

            if (finger1.phase == TouchPhase.Ended && finger1.tapCount == 1 && isClick)
            {
                StartCoroutine(Shoot());
            }
            else
            {


                if (finger1.phase == TouchPhase.Began)
                {
                    this.touch = finger1;
                    this.isClick = true;
                }
                if (finger1.phase == TouchPhase.Moved)
                {
                    this.isClick = false;
                    var distanceA = this.touch.position.y - finger1.position.y;
                    var distanceB = this.touch.position.x - finger1.position.x;
                    if (Mathf.Abs(distanceA) >= Mathf.Abs(distanceB))
                    {
                        if (Mathf.Sign(distanceA) > 0 && A < MAX_A)
                        {
                            A = A + distanceA*Time.deltaTime;
                        }
                        if (Mathf.Sign(distanceA) < 0 && A > MIN_A)
                        {
                            A = A + distanceA*Time.deltaTime;
                        }

                    }
                    else
                    {
                        if (Mathf.Sign(distanceB) > 0 && B + distanceB*Time.deltaTime < MAX_B)
                        {
                            B = B + distanceB *Time.deltaTime;
                            C = Time.time * distanceB * Time.deltaTime + C;
                        }
                        if (Mathf.Sign(distanceB) < 0 && B > MIN_A)
                        {
                            B = B + distanceB * Time.deltaTime;
                            C = Time.time * distanceB * Time.deltaTime + C;
                        }
                    }

                    this.touch = finger1;
                }
            }
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
            if (A < MAX_A)
            {
                A = A + Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.S))
        {
            if (A > MIN_A)
            {
                A = A - Time.deltaTime;
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            if (B > MIN_B)
            {
                B = B - Time.deltaTime;
                C = -Time.time * Time.deltaTime + C;
            }
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (B < MAX_B)
            {
                B = B + Time.deltaTime;
                C = Time.time * Time.deltaTime + C;
            }
        }
        if (Input.GetKey(KeyCode.Space))
        {
            StartCoroutine(Shoot());
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
        sine.UpdatePoints(A, B, C);
    }


    private IEnumerator UpdateHealth()
    {
        if (!hit)
        {
            hit = true;
            DecreaseLife();
            if (PersistingScript.persistingScript.score.life == MIN_HEALTH)
            {
                SceneManager.LoadScene(Constants.SceneNames.LooseScene, LoadSceneMode.Single);
            }
            gameObject.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(2);
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            hit = false;
        }
    }

    internal IEnumerator UpdateScore()
    {
        PersistingScript.persistingScript.score.score++;
        UI.UpdateScore();
        yield return null;
    }

    internal IEnumerator IncreaseSpeed()
    {
        if (speed < MAX_SPEED)
        {
            float oldSpeed = speed;
            speed+=2;
            //change background animation speed
            Background.gameObject.GetComponent<Animator>().speed = speed;
            //change velocity of existing asteroids
            foreach (Rigidbody2D o in GameObject.FindObjectsOfType<Rigidbody2D>())
            {
                if (o.velocity.magnitude == oldSpeed)
                {
                    o.velocity = new Vector2(-1.0f*speed, 0);
                }
            }

        }
        yield return null;
    }

    internal IEnumerator DecreaseSpeed()
    {
        if (speed > MIN_SPEED)
        {
            speed-=5;
            //change background animation speed
            Background.gameObject.GetComponent<Animator>().speed = speed;
            //change velocity of existing asteroids
        }
        yield return null;
    }

    internal IEnumerator IncreaseAmmo()
    {
        if (PersistingScript.persistingScript.score.ammo < MAX_AMMO)
        {
            PersistingScript.persistingScript.score.ammo++;
            UI.UpdateAmmo();
        }
        yield return null;
    }

    internal IEnumerator DecreaseAmmo()
    {
        PersistingScript.persistingScript.score.ammo--;
        UI.UpdateAmmo();
        yield return null;
    }

    internal IEnumerator IncreaseSize()
    {
        if (size < MAX_SIZE)
        {
            size += 0.5f;
            gameObject.transform.localScale = new Vector3(0.7f * size, 0.7f * size);
        }
        yield return null;
    }

    internal IEnumerator DecreaseSize()
    {
        if (size > MIN_SIZE)
        {
            size -= 0.5f;
            gameObject.transform.localScale = new Vector3(0.7f * size, 0.7f * size);
        }
        yield return null;
    }

    internal IEnumerator Shoot()
    {
        if (!shooting && PersistingScript.persistingScript.score.ammo > MIN_AMMO)
        {
            shooting = true;
            Rigidbody2D shootAsteroid = (Rigidbody2D)Instantiate(Constants.constants.bullet, new Vector3(gameObject.transform.position.x + 2, gameObject.transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0)));
            shootAsteroid.velocity = new Vector2(1.0f * speed, 0);
            StartCoroutine(DecreaseAmmo());
            yield return new WaitForSeconds(0.25f);
            shooting = false;

        }
        yield return null;
    }

    internal IEnumerator IncreaseLife()
    {
        if (PersistingScript.persistingScript.score.life < MAX_HEALTH)
        {
            PersistingScript.persistingScript.score.life++;
        }
        UI.UpdateLife();

        yield return null;
    }

    internal IEnumerator DecreaseLife()
    {
        if (!hit)
        {
            hit = true;
            if (PersistingScript.persistingScript.score.life > MIN_HEALTH)
            {
                PersistingScript.persistingScript.score.life--;
            }
            UI.UpdateLife();
            if (PersistingScript.persistingScript.score.life == MIN_HEALTH)
            {
                SceneManager.LoadScene(Constants.SceneNames.LooseScene, LoadSceneMode.Single);
            }
            gameObject.GetComponent<Animator>().enabled = true;
            yield return new WaitForSeconds(2);
            gameObject.GetComponent<Animator>().enabled = false;
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
            hit = false;
        }
        yield return null;
    }

    internal void callDecreaseHealth()
    {
        if (!hit)
        {
            StartCoroutine(UpdateHealth());
        }
    }

    internal void callUpdateScore()
    {
        StartCoroutine(UpdateScore());
    }

    internal void callIncreaseSpeed()
    {
        StartCoroutine(IncreaseSpeed());
    }

    internal void callDecreaseSpeed()
    {
        StartCoroutine(DecreaseSpeed());
    }

    internal void callIncreaseAmmo()
    {
        StartCoroutine(IncreaseAmmo());
    }

    internal void callDecreaseAmmo()
    {
        StartCoroutine(DecreaseAmmo());
    }

    internal void callIncreaseSize()
    {
        StartCoroutine(IncreaseSize());
    }

    internal void callDecreaseSize()
    {
        StartCoroutine(DecreaseSize());
    }

    internal void callIncreaseLife()
    {
        StartCoroutine(IncreaseLife());
    }

    internal void callDecreaseLife()
    {
        StartCoroutine(DecreaseLife());
    }

    internal void callSpecial(string tag)
    {
        if (tag == Constants.Tags.Gold)
        {
            PersistingScript.persistingScript.score.gold++;
        }
    }
}
