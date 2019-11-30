using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.EventSystems;

/*
 * Line manager responsible for managing and creating line segments.
 */

public class DrawManager : MonoBehaviour
{
    [SerializeField]
    private GameObject linePrefab;

    // List of all lines created in scene from least recent to most recent.
    private List<GameObject> lines;

    // Current drawing mode. 
    private bool brushMode;
    private bool lineMode;

    // Current active line being drawn. 
    private Line activeLine;

    private void Awake()
    {
        lines = new List<GameObject>();
        brushMode = false;
        lineMode = false;
    }

    private void Update()
    {
        if (brushMode) {
            if (Input.GetMouseButtonDown(0))
            {
                // Mouse is not over UI element. 
                if (!(EventSystem.current.IsPointerOverGameObject()))
                {
                    StartLine();
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                StopLine();
            }

            if (activeLine != null)
            {
                UpdateLine();
            }
        }
    }

    public void EnableBrushMode()
    {
        brushMode = true;
    }

    public void EnableLineMode()
    {
        lineMode = true;
    }

    public void DisableBrushMode()
    {
        brushMode = false;
    }

    public void DisableLineMode()
    {
        lineMode = false;
    }

    private void StartLine()
    {
        // Instantiate line game object.
        GameObject line = Instantiate(linePrefab);
        lines.Add(line);
        // Access script to draw the line
        activeLine = lines.Last().GetComponent<Line>();
    }

    private void UpdateLine()
    {
        Vector2 mousePos = UnityEngine.Camera.main.ScreenToWorldPoint(Input.mousePosition);
        activeLine.UpdateLine(mousePos);
    }

    private void StopLine()
    {
        activeLine = null;
    }

    public void UndoLastLine()
    {
        if (lines.Count != 0)
        {
            Destroy(lines.Last());
            lines.RemoveAt(lines.Count - 1);
        }
    }
}