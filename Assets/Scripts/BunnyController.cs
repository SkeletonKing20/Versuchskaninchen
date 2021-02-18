using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class BunnyController : MonoBehaviour
{
    Rigidbody2D rb2d;
    BoxCollider2D boxC2d;
    SpriteRenderer spriteR;

    RaycastHit2D hit;

    public UnityEvent turnEvent;
    public AudioClip clip;
    public AudioClip whoosh;
    public GameObject box;
    public GameObject death;
    public GameObject electrocution;
    public GameObject pitFall;
    public GameObject blueUICard;
    public GameObject yellowUICard;
    public GameObject spriteBunny;
    public Sprite pushHorizontal_1;
    public Sprite pushHorizontal_2;
    public Sprite pushHorizontal_3;
    public Sprite pushUp_1;
    public Sprite pushUp_2;
    public Sprite pushUp_3;
    public Sprite pushDown_1;
    public Sprite pushDown_2;
    public Sprite pushDown_3;
    public Text UIText;
    public LayerMask boxMask;
    public ButtonController button;
    public bool isHolding;
    bool isGameOver = false;
    bool onTrapdoor;

    private int killCount;
    private float movementSpeed = 250f;
    public float rayDistance;

    public Vector3 faceDirection;
    Vector3 startPosition;

    IEnumerator deathAnim(float seconds, GameObject death, AudioClip clip)
    {
        if(isGameOver)
        {
            spriteR.enabled = false;
            boxC2d.enabled = false;
            Instantiate(death, transform.position, Quaternion.identity);
            AudioSource.PlayClipAtPoint(clip, transform.position);
            yield return null;
        }
        yield return new WaitForSeconds(seconds);
        transform.position = startPosition;
        spriteR.enabled = true;
        boxC2d.enabled = true;
        rb2d.constraints = RigidbodyConstraints2D.None | RigidbodyConstraints2D.FreezeRotation;
        isGameOver = false;
    }
    void Awake()
    {
        rb2d = GetComponentInChildren<Rigidbody2D>();
        boxC2d = GetComponentInChildren<BoxCollider2D>();
        spriteR = GetComponentInChildren<SpriteRenderer>();
    }
    private void Start()
    {
        startPosition = transform.position;
    }
    private void Update()
    {
        UIText.text = killCount.ToString();
        if (Input.GetKeyDown(KeyCode.K))
        {
            gameOver();
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
    }
    void FixedUpdate()
    {
        rb2d.WakeUp();
        movePlayer();
    }
    public void gameOver()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        isGameOver = true;
        StartCoroutine(deathAnim(1f, death, clip));
        killCount++;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        calcDirection();
        hit = Physics2D.Raycast(transform.position, faceDirection.normalized, rayDistance, boxMask);
        if (Input.GetButton("Jump") && hit.collider != null)
        {
            hit.collider.gameObject.GetComponentInParent<FixedJoint2D>().enabled = true;
            hit.collider.gameObject.GetComponentInParent<FixedJoint2D>().connectedBody = this.GetComponent<Rigidbody2D>();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            gameOver();
        }
        if (collision.gameObject.CompareTag("Door"))
        {
            electrocute();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("LoadNextScene"))
        {
            SceneManager.LoadScene(2);
        }
        if (collision.gameObject.CompareTag("Trapdoor"))
        {
            onTrapdoor = true;
        }
        if (collision.gameObject.CompareTag("Button"))
        {
            button.SetPressed(1);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Pitfall") && !onTrapdoor)
        {
            isGameOver = true;
            rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
            transform.position = collision.transform.position;
            StartCoroutine(deathAnim(2f, pitFall, whoosh));
            killCount++;
        }
    }
    private void calcDirection()
    {
        if (spriteR.sprite == pushUp_1 || spriteR.sprite == pushUp_2 || spriteR.sprite == pushUp_3)
        {
            Debug.Log("Up");
            faceDirection = transform.up;
        }
        else if (spriteR.sprite == pushDown_1 || spriteR.sprite == pushDown_2 || spriteR.sprite == pushDown_3)
        {
            Debug.Log("Down");
            faceDirection = new Vector3(0, -1, 0);
        }
        else if ((spriteR.sprite == pushHorizontal_1 || spriteR.sprite == pushHorizontal_2 || spriteR.sprite == pushHorizontal_3) && spriteR.flipX == true)
        {
            Debug.Log("Left");
            faceDirection = new Vector3(-1, 0, 0);
        }
        else if((spriteR.sprite == pushHorizontal_1 || spriteR.sprite == pushHorizontal_2 || spriteR.sprite == pushHorizontal_3) && spriteR.flipX == false)
        {
            Debug.Log("Right");
            faceDirection = transform.right;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trapdoor"))
        {
            onTrapdoor = false;
        }
        if (collision.gameObject.CompareTag("Button"))
        {
            button.SetPressed(1 * -1);
        }
    }

    public void electrocute()
    {
        rb2d.constraints = RigidbodyConstraints2D.FreezeAll;
        isGameOver = true;
        StartCoroutine(deathAnim(1f, electrocution, clip));
        killCount++;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + faceDirection * transform.localScale.x * rayDistance);
    }

    private void Reset()
    {
        SceneManager.LoadScene(0);
    }

    private void movePlayer()
    {
        if (isGameOver == false)
        {
            rb2d.velocity = Vector2.right * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Horizontal") + Vector2.up * movementSpeed * Time.deltaTime * Input.GetAxisRaw("Vertical");
        }
    }

    public void setOnTrapdoor()
    {
        onTrapdoor = false;
    }
}
