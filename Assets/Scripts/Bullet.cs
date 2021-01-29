using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb2d;
    float movementSpeed = 10000f;
    private void Awake()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        rb2d.velocity = transform.up * movementSpeed * Time.deltaTime;
    }
}
