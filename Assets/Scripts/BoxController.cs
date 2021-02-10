using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxController : MonoBehaviour
{
    Rigidbody2D rb2d;
    FixedJoint2D fixJ2d;
    public ButtonController button;
    public int weight;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        fixJ2d = GetComponent<FixedJoint2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rb2d.velocity = Vector3.zero;
        if (Input.GetButtonUp("Jump"))
        {
            fixJ2d.enabled = false;
            rb2d.mass = 2000;
        }

        if(fixJ2d.enabled == true)
        {
            rb2d.mass = 1;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            button.SetPressed(weight);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            button.SetPressed(-1 * weight);
        }
    }
}
