using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Bullet bullet;
    int coolDown;
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
