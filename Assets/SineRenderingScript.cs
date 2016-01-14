using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class SineRenderingScript : MonoBehaviour {

    public float a;
    public float b;
    public int vertexCount;
    List<Vector3> points = new List<Vector3>();
    private LineRenderer lineRenderer;
    float timeToSubstract = 0;
    float timeToSubstract2 = 0;
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
        timeToSubstract2 = timeToSubstract + Time.deltaTime;
        if (timeToSubstract<duration && timeToSubstract2>duration)
        {
            timeToSubstract = 0;
        }
        else
        {
            timeToSubstract = timeToSubstract2;
        }
        lineRenderer.SetPositions(points.Select((x) => Vector3.right*x.x/b + Vector3.up*a*(x.y) + Vector3.left * timeToSubstract/b).ToArray());
	}

    internal void UpdateA(float A)
    {
        a = A;
        duration = Mathf.PI * 2 * b;
       //computePoints();
    }

    internal void UpdateB(float B)
    {
        b = B;
        duration = Mathf.PI * 2 * b;
        //computePoints();
    }

    internal void ResetTime()
    {
        timeToSubstract = 0;
    }

    void computePoints()
    {
        points.Clear();
        for (float i = 0; i < vertexCount; i += 1)
        {                                                  
            print("vertexCount: " + vertexCount.ToString() + " i: " + i.ToString());
            points.Add(new Vector3(((i-10) / 2), a * Mathf.Sin(b * ((i-10) / 2))));
        }
    }
}
