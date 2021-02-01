using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BunnyController : MonoBehaviour
{
    Rigidbody2D rb2d;
    public bool isHolding;
    public UnityEvent turnEvent;
    private float movementSpeed = 100f;
    void Awake()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
    }
    private void Start()
    {
        isHolding = false;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb2d.velocity = Vector2.right * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal") + Vector2.up * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Turret") || collision.gameObject.CompareTag("Box")) && Input.GetButton("Jump"))
        {
            isHolding = true;
        }
        else if((collision.gameObject.CompareTag("Turret") || collision.gameObject.CompareTag("Box")) && Input.GetButtonUp("Jump"))
        {
            isHolding = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Turret"))
        {
            Debug.Log("Why");
            turnEvent.Invoke();
        }
    }
}
