using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBunny : MonoBehaviour
{
    Animator animator;
    private int paramIDHorizontal, paramIDVertical, paramIDPush, paramIDDied;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        paramIDHorizontal = Animator.StringToHash("horizontalMovement");
        paramIDVertical = Animator.StringToHash("verticalMovement");
        paramIDPush = Animator.StringToHash("isMovingAnObject");
        paramIDDied = Animator.StringToHash("Died");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(paramIDHorizontal, Input.GetAxisRaw("Horizontal"));
        animator.SetFloat(paramIDVertical, Input.GetAxisRaw("Vertical"));
        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool(paramIDPush, true);
        }
        if (Input.GetButtonUp("Jump"))
        {
            animator.SetBool(paramIDPush, false);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Bullet"))
        {
            animator.SetTrigger(paramIDDied);
        }
    }
}
