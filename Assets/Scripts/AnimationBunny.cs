using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationBunny : MonoBehaviour
{
    Animator animator;
    private int paramIDHorizontal, paramIDVertical;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        paramIDHorizontal = Animator.StringToHash("horizontalMovement");
        paramIDVertical = Animator.StringToHash("verticalMovement");
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat(paramIDHorizontal, Input.GetAxisRaw("Horizontal"));
        animator.SetFloat(paramIDVertical, Input.GetAxisRaw("Vertical"));
    }
}
