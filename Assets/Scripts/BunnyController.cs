using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BunnyController : MonoBehaviour
{
    Rigidbody2D rb2d;
    RaycastHit2D hit;
    public bool isHolding;
    public UnityEvent turnEvent;
    private float movementSpeed = 100f;
    bool gameOver;
    public GameObject death;
    Vector3 position;
    public LayerMask boxMask;
    public float rayDistance;
    public GameObject box;
    Vector3 faceDirection;
    bool isAttached;
    void Awake()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
    }
    private void Start()
    {
        isAttached = false;
    }
    private void Update()
    {
        faceDirection = transform.right * Input.GetAxisRaw("Horizontal") + transform.up * Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameOver = true;
        }

        hit = Physics2D.Raycast(transform.position, faceDirection, rayDistance, boxMask);
        if (Input.GetButtonDown("Jump") && hit.collider != null)
        {
            Debug.Log("HIT!");
            hit.collider.gameObject.GetComponentInParent<FixedJoint2D>().enabled = true;
            isAttached = true;
            hit.collider.gameObject.GetComponentInParent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
    }
    void FixedUpdate()
    {
        position = transform.position;
        rb2d.velocity = Vector2.right * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal") + Vector2.up * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       
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

    private void OnDrawGizmos()
    {
        
    }
}
