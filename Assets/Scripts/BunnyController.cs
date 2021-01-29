using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunnyController : MonoBehaviour
{
    Rigidbody2D rb2d;
    private float movementSpeed = 10f;
    void Awake()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = Vector2.right * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal") + Vector2.up * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
    }
}
