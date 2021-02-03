using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    int coolDown;
    public Bullet bullet;
    public TurretHead turretHead;
    private void Awake()
    {
        
    }
    public void shoot()
    {
        if(Time.time > coolDown)
        {
            coolDown += 2;
            Instantiate(bullet, turretHead.transform.position, turretHead.getRotation());
        }
    }
    private void Update()
    {
        shoot();
        if (Input.GetButtonUp("Jump"))
        {
            GetComponent<FixedJoint2D>().enabled = false;
        }
    }
}
