using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;

public class SineRenderingScript : MonoBehaviour {

    public float a;
    public float b;
    public int vertexCount;
    public LineRenderer lineRenderer;


    private List<Vector3> _points = new List<Vector3>();
    private int _lastVertexCount;
    private float _timeSimulationStarted;

	// Use this for initialization
	void Start () {
        lineRenderer = (LineRenderer)gameObject.GetComponent<Renderer>();
        lineRenderer.positionCount = vertexCount;
        ComputeInitialPoints();
        lineRenderer.SetPositions(_points.ToArray());
        _lastVertexCount = vertexCount - 11;
        _timeSimulationStarted = Time.time;
	}

    void ComputeInitialPoints()
    {
        _points.Clear();
        for (float i = 0; i < vertexCount; i += 1)
        {
            _points.Add(new Vector3(((i - 10) / 4 + Time.time), 0));
        }
    }

    internal void UpdatePoints(float A, float B, float C)
    {
        if (_points[_points.Count / 4].x - Time.time < 0)
        {
            _lastVertexCount++;
            _points.RemoveAt(0);
            _points.Add(new Vector3(((float)_lastVertexCount) / 4.0f + _timeSimulationStarted, 0));
        }

        for(int i =0; i<_points.Count; i++)
        {
            var x = _points[i];
            lineRenderer.SetPosition(i, Vector3.right * (x.x - Time.time) + Vector3.up * A * Mathf.Sin(B * (x.x) - C));
        }
        //lineRenderer.SetPositions(_points.Select((x) => Vector3.right * (x.x - Time.time) + Vector3.up * A * Mathf.Sin(B * (x.x) - C)).ToArray());
    }
}
