using UnityEngine;
using System.Collections;

public class MainCameraScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    internal void MoveCamera(float p)
    {
        transform.Translate(new Vector3(p, 0));
    }
}
