using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Player controller responsible for player physics and position through out
 * the session. 
 */

public class Player : MonoBehaviour
{
    [SerializeField]
    private Rigidbody2D rb;

    private Vector3 originalPosition;

    public void Start()
    {
        originalPosition = transform.position;
    }

    public void DropDown()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void LoadStartPosition()
    {
        rb.bodyType = RigidbodyType2D.Static;
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = originalPosition;
    }
}

