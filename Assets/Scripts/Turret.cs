using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    Bullet bullet;
    public void shoot()
    {
        Instantiate(bullet, this.transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    public bool shotsFired()
    {
        return true;
    }
}
