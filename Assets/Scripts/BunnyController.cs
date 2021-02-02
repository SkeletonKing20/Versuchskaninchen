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
    bool gameOver;
    public DeathController death;
    Vector3 position;
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
        position = transform.position;
        rb2d.velocity = Vector2.right * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal") + Vector2.up * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if ((collision.gameObject.CompareTag("Turret") || collision.gameObject.CompareTag("Box")) && Input.GetButton("Jump"))
        {
            if(Input.GetAxisRaw("Horizontal") != 0)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.right * Input.GetAxisRaw("Horizontal"));
            }
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameOver = true;
        }
    }
    private void LateUpdate()
    {
        if (gameOver)
        {
            Instantiate(death, transform.position, Quaternion.identity);
            transform.position = Vector3.zero;
            gameOver = false;
        }
    }

    public Vector3 getPosition()
    {
        return position;
    }
}
