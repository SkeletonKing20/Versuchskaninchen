using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public int length;
    public float speed;
    Vector3 initialPosition;
    public Vector3 targetPosition;
    Rigidbody2D rb2D;
    public int trapDoorNumber;
    private void Start()
    {
        initialPosition = transform.position;
        rb2D = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        if (trapDoorNumber == 1)
        {
            if (transform.position.x > targetPosition.x)
            {
                rb2D.velocity = transform.right * speed * Time.deltaTime;
            }
            else
            {
                Reset();
            }
        }

        if (trapDoorNumber == 2)
        {
            if (transform.position.y > targetPosition.y)
            {
                rb2D.velocity = transform.right * speed * Time.deltaTime;
            }
            else
            {
                Reset();
            }
        }
    }

    private void Reset()
    {
        transform.position = initialPosition;
    }
}
