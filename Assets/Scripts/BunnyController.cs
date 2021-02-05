using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BunnyController : MonoBehaviour
{
    Rigidbody2D rb2d;

    RaycastHit2D hit;

    public UnityEvent turnEvent;

    public GameObject box;
    public GameObject death;
    public GameObject blueUICard;
    public GameObject yellowUICard;
    public Text UIText;
    public LayerMask boxMask;

    public bool isHolding;

    private int killCount;
    private float movementSpeed = 250f;
    public float rayDistance;

    Vector3 faceDirection;
    Vector3 startPosition;
    void Awake()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
    }
    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        UIText.text = killCount.ToString();
        faceDirection = transform.right * Input.GetAxisRaw("Horizontal") + transform.up * Input.GetAxisRaw("Vertical");
        if (Input.GetKey(KeyCode.K))
        {
            gameOver();
        }

        hit = Physics2D.Raycast(transform.position, faceDirection, rayDistance, boxMask);
        if (Input.GetButton("Jump") && hit.collider != null)
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
    public void gameOver()
    {
            Instantiate(death, transform.position, Quaternion.identity);
            transform.position = startPosition;
            killCount++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LoadNextScene"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
