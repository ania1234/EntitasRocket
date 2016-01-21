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
        print("Sine rendering start" + Time.time.ToString());
        lineRenderer = (LineRenderer)gameObject.GetComponent<Renderer>();
        lineRenderer.SetVertexCount(vertexCount);
        computePoints();
        duration = Mathf.PI * 2 * b;
        lineRenderer.SetPositions(points.ToArray());
        
	}
	
	// Update is called once per frame
	void Update () {

	}

    internal void UpdateA(float A)
    {
        a = A;
        duration = Mathf.PI * 2 * b;
    }

    internal void UpdateB(float B)
    {
        b = B;
        duration = Mathf.PI * 2 * b;
    }


    void computePoints()
    {
        points.Clear();
        for (float i = 0; i < vertexCount; i += 1)
        {                                                  
            points.Add(new Vector3(((i+Time.time-10) / 4), 0));
        }
    }

    internal void UpdateSine(float deltaTime)
    {
        //timeToSubstract2 = timeToSubstract + deltaTime;
        //print("Sine time to substract" + timeToSubstract2.ToString());
        //if (timeToSubstract < duration && timeToSubstract2 > duration)
        //{
        //    timeToSubstract = 0;
        //}
        //else
        //{
        //    timeToSubstract = timeToSubstract2;
        //}
        //lineRenderer.SetPositions(points.Select((x) => Vector3.right * x.x / b + Vector3.up * a * (x.y) + Vector3.left * timeToSubstract / b).ToArray());
    }
}
