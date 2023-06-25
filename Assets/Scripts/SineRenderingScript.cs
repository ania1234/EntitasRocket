using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SineRenderingScript : MonoBehaviour {

    public float a;
    public float b;
    public int vertexCount;
    public List<Vector3> points = new List<Vector3>();
    public LineRenderer lineRenderer;
    float duration;
	// Use this for initialization
	void Start () {
        lineRenderer = (LineRenderer)gameObject.GetComponent<Renderer>();
        lineRenderer.SetVertexCount(vertexCount);
        computePoints();
        duration = Mathf.PI * 2 * b;
        lineRenderer.SetPositions(points.ToArray());
        
	}
	
	// Update is called once per frame
	void Update () {

	}


    void computePoints()
    {
        points.Clear();
        for (float i = 0; i < vertexCount; i += 1)
        {
            points.Add(new Vector3(((i - 10) / 4 + Time.time), 0));
        }
    }

}
