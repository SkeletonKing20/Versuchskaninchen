using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBunny : MonoBehaviour
{
    Animator animator;
    private int paramIDHorizontal, paramIDVertical, paramIDPush;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        paramIDHorizontal = Animator.StringToHash("horizontalMovement");
        paramIDVertical = Animator.StringToHash("verticalMovement");
        paramIDPush = Animator.StringToHash("isMovingAnObject");
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
}
