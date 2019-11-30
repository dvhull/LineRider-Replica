using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Camera : MonoBehaviour
{
    private bool running;
    private bool moving;

    public Transform playerTransform;
    private Vector3 originalPosition;
    private Vector3 dragOrigin;
    public float dragSpeed = 2;


    private void Start()
    {
        originalPosition = transform.position;
        running = false;
        moving = false;

    }
    void Update()
    {
        if (running)
        {
            FollowRider();
        }

        if (moving)
        {
            if (!(EventSystem.current.IsPointerOverGameObject())) {
                if (Input.GetMouseButtonDown(0))
                {
                    dragOrigin = Input.mousePosition;
                    return;
                }

                if (!Input.GetMouseButton(0))
                {
                    return;
                }

                Vector3 pos = UnityEngine.Camera.main.ScreenToViewportPoint(Input.mousePosition - dragOrigin);
                Vector3 move = new Vector3(pos.x * dragSpeed, pos.y * dragSpeed, 0);

                transform.Translate(move, Space.World);
            }

        }
    }

    public void EnableMoveMode()
    {
        moving = true;
    }
    public void DisableMoveMode()
    {
        moving = false;
    }
    public void EnableRunningMode()
    {
        running = true;
    }

    public void DisableRunningMode()
    {
        running = false;
        ResetCamera();
    }

    public void ResetCamera()
    {
        transform.position = originalPosition;
    }

    private void FollowRider()
    {
        var pos = transform.position;
        pos.x = playerTransform.position.x;
        pos.y = playerTransform.position.y;
        transform.position = pos;
    }
}
