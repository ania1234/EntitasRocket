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
    

    public void InitializeDisplay()
    {
        scoreText.text = "S c o r e : " + PersistentScript.instance.score.score.ToString();
        for (int i = 0; i < PersistentScript.instance.score.life; i++)
        {
            Image image = (Image)Instantiate(health, new Vector3(-350 + i * 40, 210, 0), new Quaternion(0, 0, 0, 0));
            image.transform.SetParent(gameObject.transform, false);
            healthSpirits.Push(image);
        }
        for (int i = 0; i < PersistentScript.instance.score.ammo; i++)
        {
            Image image = (Image)Instantiate(shots, new Vector3(-186 + i * 43, 207, 0), new Quaternion(0, 0, 0, 0));
            image.transform.SetParent(gameObject.transform, false);
            shotSpirits.Push(image);
        }
    }

    public void UpdateScore()
    {
        scoreText.text = "S c o r e : " + PersistentScript.instance.score.score.ToString();
    }


    internal void UpdateAmmo()
    {
        if (shotSpirits.Count > PersistentScript.instance.score.ammo)
        {
            Image image = shotSpirits.Pop();
            Destroy(image.gameObject);
        }

        if (shotSpirits.Count < PersistentScript.instance.score.ammo)
        {
            Image image = (Image)Instantiate(shots, new Vector3(-186 + (PersistentScript.instance.score.ammo-1) * 43, 207, 0), new Quaternion(0, 0, 0, 0));
            image.transform.SetParent(gameObject.transform, false);
            shotSpirits.Push(image);
        }
    }

    internal void UpdateLife()
    {
        if (healthSpirits.Count > PersistentScript.instance.score.life)
        {
            Image image = healthSpirits.Pop();
            print(image);
            Destroy(image.gameObject);
        }

        if (healthSpirits.Count < PersistentScript.instance.score.life)
        {
            Image image = (Image)Instantiate(health, new Vector3(-350 + (PersistentScript.instance.score.life-1) * 40, 207, 0), new Quaternion(0, 0, 0, 0));
            image.transform.SetParent(gameObject.transform, false);
            healthSpirits.Push(image);
        }
    }

    internal void setText(string text)
    {
        scoreText.text = text;
    }
}
