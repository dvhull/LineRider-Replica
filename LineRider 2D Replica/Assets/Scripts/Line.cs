using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

/*
 * Line controller responsible for creating a line segment.
 */

public class Line : MonoBehaviour
{
    [SerializeField]
    private LineRenderer lineRenderer;
    [SerializeField]
    private EdgeCollider2D edgeCollider;

    private List<Vector2> points;

    public void UpdateLine(Vector2 mousePosition)
    {
        // No line created yet. 
        if (points == null)
        {
            points = new List<Vector2>();
            SetPoint(mousePosition);
            return;
        }

        // Distance from the last point is greater than .1f create a new point.
        if (Vector2.Distance(points.Last(), mousePosition) > .1f)
        {
            SetPoint(mousePosition);
            return;
        }
    }

    // Set new point in line.
    private void SetPoint(Vector2 point)
    {
        points.Add(point);
        lineRenderer.positionCount = points.Count;
        lineRenderer.SetPosition(points.Count - 1, point);

        // EdgeColliders require two points.
        if (points.Count > 1)
        {
            edgeCollider.points = points.ToArray();
        }

    }
}
