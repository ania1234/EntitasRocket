using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class UpdateScoreScript : MonoBehaviour {

    public Text scoreText;
    public Image health;
    public Image shots;
    Stack<Image> healthSpirits = new Stack<Image>();
    Stack<Image> shotSpirits = new Stack<Image>();
    
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void InitializeDisplay()
    {
        scoreText.text = "S c o r e : " + PersistingScript.persistingScript.score.score.ToString();
        for (int i = 0; i < PersistingScript.persistingScript.score.life; i++)
        {
            Image image = (Image)Instantiate(health, new Vector3(-350 + i * 40, 210, 0), new Quaternion(0, 0, 0, 0));
            image.transform.SetParent(gameObject.transform, false);
            healthSpirits.Push(image);
        }
        for (int i = 0; i < PersistingScript.persistingScript.score.ammo; i++)
        {
            Image image = (Image)Instantiate(shots, new Vector3(-186 + i * 43, 207, 0), new Quaternion(0, 0, 0, 0));
            image.transform.SetParent(gameObject.transform, false);
            shotSpirits.Push(image);
        }
    }

    public void UpdateScore()
    {
        scoreText.text = "S c o r e : " + PersistingScript.persistingScript.score.score.ToString();
    }


    internal void UpdateAmmo()
    {
        if (shotSpirits.Count > PersistingScript.persistingScript.score.ammo)
        {
            Image image = shotSpirits.Pop();
            Destroy(image.gameObject);
        }

        if (shotSpirits.Count < PersistingScript.persistingScript.score.ammo)
        {
            Image image = (Image)Instantiate(shots, new Vector3(-186 + (PersistingScript.persistingScript.score.ammo-1) * 43, 207, 0), new Quaternion(0, 0, 0, 0));
            image.transform.SetParent(gameObject.transform, false);
            shotSpirits.Push(image);
        }
    }

    internal void UpdateLife()
    {
        if (healthSpirits.Count > PersistingScript.persistingScript.score.life)
        {
            Image image = healthSpirits.Pop();
            print(image);
            Destroy(image.gameObject);
        }

        if (healthSpirits.Count < PersistingScript.persistingScript.score.life)
        {
            Image image = (Image)Instantiate(health, new Vector3(-350 + (PersistingScript.persistingScript.score.life-1) * 40, 207, 0), new Quaternion(0, 0, 0, 0));
            image.transform.SetParent(gameObject.transform, false);
            healthSpirits.Push(image);
        }
    }

    internal void setText(string text)
    {
        scoreText.text = text;
    }
}
