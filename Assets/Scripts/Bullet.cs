using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody2D rb2d;
    CapsuleCollider2D capC2d;
    float movementSpeed = 1000f;
    public WallButton button;
    public Sprite pressed;
    private void Awake()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
        capC2d = GetComponentInChildren<CapsuleCollider2D>();
    }
    void FixedUpdate()
    {
        rb2d.velocity = transform.up * movementSpeed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null && collision.gameObject.tag != "WallButton")
        {
            Destroy(gameObject);
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null && collision.gameObject.tag == "WallButton")
        {
            WallButton.setPressed();
        }
    }
}
