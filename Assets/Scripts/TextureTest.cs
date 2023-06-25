using UnityEngine;
using System.Collections;

public class TextureTest : MonoBehaviour {

    LineRenderer line;
	// Use this for initialization
	void Start () {
        line = (LineRenderer)gameObject.GetComponent<Renderer>();
        line.material.mainTextureScale = new Vector2(2f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
