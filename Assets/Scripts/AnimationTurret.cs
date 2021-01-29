using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationTurret : MonoBehaviour
{
    Animator animator;
    Turret turret;
    int paramIDShot;
    void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    private void Start()
    {
        paramIDShot = Animator.StringToHash("Shot");
    }
    // Update is called once per frame
    void Update()
    {
        if(turret.shotsFired())
        {
            animator.SetTrigger(paramIDShot);
        }
    }
}
