using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BunnyController : MonoBehaviour
{
    Rigidbody2D rb2d;

    RaycastHit2D hit;

    public LayerMask boxMask;

    public UnityEvent turnEvent;

    public GameObject death;
    public GameObject box;

    public bool isHolding;
    bool gameOver;

    private float movementSpeed = 100f;
    public float rayDistance;

    int killCount;

    Vector3 faceDirection;

    void Awake()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
    }

    private void Start()
    {
        killCount = 0;
    }

    private void Update()
    {
        if(rb2d.velocity != Vector2.zero)
        {
            faceDirection = transform.right * Input.GetAxisRaw("Horizontal") + transform.up * Input.GetAxisRaw("Vertical");
        }
        else
        {
            faceDirection = transform.right;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameOver = true;
        }

        hit = Physics2D.Raycast(transform.position, faceDirection, rayDistance, boxMask);
        if (Input.GetButtonDown("Jump") && hit.collider != null)
        {
            Debug.Log("HIT!");
            hit.collider.gameObject.GetComponentInParent<FixedJoint2D>().enabled = true;
            hit.collider.gameObject.GetComponentInParent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
    }

    void FixedUpdate()
    {
        rb2d.velocity = Vector2.right * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal") + Vector2.up * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
    }
    private void LateUpdate()
    {
        if (gameOver)
        {
            Instantiate(death, transform.position, Quaternion.identity);
            transform.position = Vector3.zero;
            killCount++;
            gameOver = false;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(transform.position, transform.position + faceDirection * rayDistance);
    }
}
