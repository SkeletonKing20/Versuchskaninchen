﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Bullet bullet;
    float coolDown;
    public TurretHead turretHead;
    int paramIDShot;
    Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        paramIDShot = Animator.StringToHash("Shot");
    }
    public void shoot()
    {
        if(Time.time > coolDown)
        {
            coolDown += 0.5f;
            animator.SetTrigger(paramIDShot);
            Instantiate(bullet, turretHead.transform.position, turretHead.getRotation());
        }
    }

    // Update is called once per frame
    public bool shotsFired()
    {
        return true;
    }

    private void Update()
    {
        shoot();
    }
}
